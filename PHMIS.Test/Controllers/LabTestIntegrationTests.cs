using FluentAssertions;
using PHMIS.Application.Common;
using PHMIS.Application.DTO.Laboratory;
using PHMIS.Test.TestInfrastructure;
using PHMIS.Test.Extensions;
using System.Net;
using System.Net.Http.Json;
using Xunit;
using Xunit.Abstractions;

namespace PHMIS.Test.Controllers
{
    public class LabTestIntegrationTests : IClassFixture<CustomWebApplicationFactory>, IAsyncLifetime
    {
        private readonly CustomWebApplicationFactory _factory;
        private readonly HttpClient _client;
        private readonly ITestOutputHelper _output;

        public LabTestIntegrationTests(CustomWebApplicationFactory factory, ITestOutputHelper output)
        {
            _factory = factory;
            _client = factory.CreateClient();
            _output = output;
        }

        private async Task LogIfError(HttpResponseMessage response, string context = "")
        {
            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                _output.WriteLine($"[{context}] Status: {(int)response.StatusCode} {response.StatusCode}");
                _output.WriteLine($"[{context}] Error: {errorContent}");
            }
        }

        public async Task InitializeAsync()
        {
            // Clean up groups (and cascading lab tests) for isolation
            await _factory.CleanupLabTestGroupsAsync();
        }

        public Task DisposeAsync() => Task.CompletedTask;

        [Fact]
        public async Task Post_CreateLabTest_Works_And_Can_Get()
        {
            // Create group first
            var groupDto = new LabTestGroupCreateDto { Name = "Chemistry" };
            var groupResp = await _client.PostAsJsonAsync("/api/labtestgroup", groupDto);
            await LogIfError(groupResp, "CreateLabTestGroup");
            groupResp.EnsureSuccessStatusCode();
            var groupList = await _client.GetFromJsonAsync<PagedList<LabTestGroupDto>>("/api/labtestgroup?pageNumber=1&pageSize=10");
            var group = groupList!.Items.First(x => x.Name == groupDto.Name);

            var create = new LabTestCreateDto { Name = "Glucose", Description = "FBS", Price = 11, IsActive = true, LabTestGroupId = group.Id };
            var postResponse = await _client.PostAsJsonAsync("/api/labtest", create);
            await LogIfError(postResponse, "CreateLabTest");
            postResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var listResponse = await _client.GetAsync("/api/labtest?pageNumber=1&pageSize=50");
            await LogIfError(listResponse, "ListLabTests");
            listResponse.EnsureSuccessStatusCode();
            var paged = await listResponse.Content.ReadFromJsonAsync<PagedList<LabTestDto>>();
            paged!.Items.Should().Contain(x => x.Name == create.Name && x.Price == create.Price && x.LabTestGroupId == group.Id);

            var item = paged.Items.First(x => x.Name == create.Name);
            var byId = await _client.GetAsync($"/api/labtest/{item.Id}");
            await LogIfError(byId, "GetLabTestById");
            byId.StatusCode.Should().Be(HttpStatusCode.OK);
            var got = await byId.Content.ReadFromJsonAsync<LabTestDto>();
            got!.Name.Should().Be(create.Name);
            got.Price.Should().Be(create.Price);
            got.LabTestGroupId.Should().Be(group.Id);
        }

        [Fact]
        public async Task Get_ListLabTests_ReturnsPagedList()
        {
            // Prepare a group and one test
            var groupDto = new LabTestGroupCreateDto { Name = "Hematology" };
            var groupResp = await _client.PostAsJsonAsync("/api/labtestgroup", groupDto);
            await LogIfError(groupResp, "SeedLabTestGroup");
            groupResp.EnsureSuccessStatusCode();
            var groupList = await _client.GetFromJsonAsync<PagedList<LabTestGroupDto>>("/api/labtestgroup?pageNumber=1&pageSize=10");
            var group = groupList!.Items.First(x => x.Name == groupDto.Name);

            var create = new LabTestCreateDto { Name = "CBC", Description = "Complete Blood Count", Price = 20, IsActive = true, LabTestGroupId = group.Id };
            var post = await _client.PostAsJsonAsync("/api/labtest", create);
            await LogIfError(post, "SeedLabTest");
            post.EnsureSuccessStatusCode();

            var response = await _client.GetAsync("/api/labtest?pageNumber=1&pageSize=2");
            await LogIfError(response, "Get_ListLabTests");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var paged = await response.Content.ReadFromJsonAsync<PagedList<LabTestDto>>();
            paged.Should().NotBeNull();
            paged!.Items.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public async Task Get_ById_ReturnsNotFound_ForUnknownId()
        {
            var response = await _client.GetAsync("/api/labtest/999999");
            await LogIfError(response, "GetLabTestById_Unknown");
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task Put_UpdateLabTest_Works()
        {
            // Create group and test
            var groupDto = new LabTestGroupCreateDto { Name = "Microbiology" };
            var groupResp = await _client.PostAsJsonAsync("/api/labtestgroup", groupDto);
            await LogIfError(groupResp, "UpdateLabTestGroup");
            groupResp.EnsureSuccessStatusCode();
            var groupList = await _client.GetFromJsonAsync<PagedList<LabTestGroupDto>>("/api/labtestgroup?pageNumber=1&pageSize=10");
            var group = groupList!.Items.First(x => x.Name == groupDto.Name);

            var create = new LabTestCreateDto { Name = "Culture", Description = "Urine culture", Price = 50, IsActive = true, LabTestGroupId = group.Id };
            var post = await _client.PostAsJsonAsync("/api/labtest", create);
            await LogIfError(post, "UpdateLabTest_Seed");
            post.EnsureSuccessStatusCode();

            var listResponse = await _client.GetAsync("/api/labtest?pageNumber=1&pageSize=50");
            await LogIfError(listResponse, "UpdateLabTest_List");
            var list = await listResponse.Content.ReadFromJsonAsync<PagedList<LabTestDto>>();
            var existing = list!.Items.First(x => x.Name == create.Name);

            var updated = new LabTestCreateDto { Name = existing.Name, Description = existing.Description, Price = 60, IsActive = false, LabTestGroupId = group.Id };
            var updateResponse = await _client.PutAsJsonAsync($"/api/labtest/{existing.Id}", updated);
            await LogIfError(updateResponse, "UpdateLabTest_Update");
            updateResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            var updatedDto = await updateResponse.Content.ReadFromJsonAsync<LabTestDto>();
            updatedDto!.Price.Should().Be(60);
            updatedDto.IsActive.Should().BeFalse();
        }

        [Fact]
        public async Task Delete_LabTest_Works_And_ReturnsNotFound_WhenMissing()
        {
            // Create group and test
            var groupDto = new LabTestGroupCreateDto { Name = "Serology" };
            var groupResp = await _client.PostAsJsonAsync("/api/labtestgroup", groupDto);
            await LogIfError(groupResp, "DeleteLabTestGroup");
            groupResp.EnsureSuccessStatusCode();
            var groupList = await _client.GetFromJsonAsync<PagedList<LabTestGroupDto>>("/api/labtestgroup?pageNumber=1&pageSize=10");
            var group = groupList!.Items.First(x => x.Name == groupDto.Name);

            var create = new LabTestCreateDto { Name = "HIV", Description = "Rapid", Price = 15, IsActive = true, LabTestGroupId = group.Id };
            var post = await _client.PostAsJsonAsync("/api/labtest", create);
            await LogIfError(post, "DeleteLabTest_Seed");
            post.EnsureSuccessStatusCode();

            var listResponse = await _client.GetAsync("/api/labtest?pageNumber=1&pageSize=50");
            await LogIfError(listResponse, "DeleteLabTest_List");
            var list = await listResponse.Content.ReadFromJsonAsync<PagedList<LabTestDto>>();
            var existing = list!.Items.First(x => x.Name == create.Name);

            var deleteResponse = await _client.DeleteAsync($"/api/labtest/{existing.Id}");
            await LogIfError(deleteResponse, "DeleteLabTest_Delete");
            deleteResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var deleteAgain = await _client.DeleteAsync($"/api/labtest/{existing.Id}");
            await LogIfError(deleteAgain, "DeleteLabTest_DeleteAgain");
            deleteAgain.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
    }
}
