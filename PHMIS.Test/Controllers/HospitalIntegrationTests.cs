using FluentAssertions;
using PHMIS.Application.Common;
using PHMIS.Application.DTO.Hospitals;
using PHMIS.Test.TestInfrastructure;
using PHMIS.Test.Extensions;
using System.Net;
using System.Net.Http.Json;
using Xunit;
using Xunit.Abstractions;

namespace PHMIS.Test.Controllers
{
    public class HospitalIntegrationTests : IClassFixture<CustomWebApplicationFactory>, IAsyncLifetime
    {
        private readonly CustomWebApplicationFactory _factory;
        private readonly HttpClient _client;
        private readonly ITestOutputHelper _output;

        public HospitalIntegrationTests(CustomWebApplicationFactory factory, ITestOutputHelper output)
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
            await _factory.CleanupHospitalsAsync();
        }

        public Task DisposeAsync() => Task.CompletedTask;

        [Fact]
        public async Task Post_CreateHospital_ReturnsOk_And_ListContainsItem()
        {
            var dto = new HospitalCreateDto
            {
                Code = $"H-{Guid.NewGuid():N}",
                Phone = "111-222-3333",
                Email = $"h_{Guid.NewGuid():N}@test.local",
                Address = "Somewhere",
                IsActive = true
            };

            var post = await _client.PostAsJsonAsync("/api/hospital", dto);
            await LogIfError(post, "Post_CreateHospital");
            post.StatusCode.Should().Be(HttpStatusCode.OK);

            var listResponse = await _client.GetAsync("/api/hospital?pageNumber=1&pageSize=100");
            await LogIfError(listResponse, "ListHospitals");
            listResponse.EnsureSuccessStatusCode();
            var paged = await listResponse.Content.ReadFromJsonAsync<PagedList<HospitalDto>>();
            paged!.Items.Should().Contain(x => x.Code == dto.Code);
        }

        [Fact]
        public async Task Get_ById_ReturnsNotFound_ForUnknownId()
        {
            var response = await _client.GetAsync("/api/hospital/999999");
            await LogIfError(response, "GetHospitalById_Unknown");
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task Put_UpdateHospital_Works()
        {
            var dto = new HospitalCreateDto
            {
                Code = $"H-{Guid.NewGuid():N}",
                Phone = "111-222-3333",
                Email = $"h_{Guid.NewGuid():N}@test.local",
                Address = "Somewhere",
                IsActive = true
            };

            var post = await _client.PostAsJsonAsync("/api/hospital", dto);
            await LogIfError(post, "Put_UpdateHospital_Seed");
            post.EnsureSuccessStatusCode();

            var listResponse = await _client.GetAsync("/api/hospital?pageNumber=1&pageSize=200");
            await LogIfError(listResponse, "Put_UpdateHospital_List");
            var list = await listResponse.Content.ReadFromJsonAsync<PagedList<HospitalDto>>();
            var existing = list!.Items.Last(x => x.Code == dto.Code);

            var updated = new HospitalCreateDto
            {
                Code = existing.Code,
                Phone = existing.Phone,
                Email = existing.Email,
                Address = "Updated Address",
                IsActive = existing.IsActive
            };

            var put = await _client.PutAsJsonAsync($"/api/hospital/{existing.Id}", updated);
            await LogIfError(put, "Put_UpdateHospital_Update");
            put.StatusCode.Should().Be(HttpStatusCode.OK);
            var got = await put.Content.ReadFromJsonAsync<HospitalDto>();
            got!.Address.Should().Be("Updated Address");
        }

        [Fact]
        public async Task Delete_Hospital_Works_And_ThenNotFound()
        {
            var dto = new HospitalCreateDto
            {
                Code = $"H-{Guid.NewGuid():N}",
                Phone = "111-222-3333",
                Email = $"h_{Guid.NewGuid():N}@test.local",
                Address = "Somewhere",
                IsActive = true
            };

            var post = await _client.PostAsJsonAsync("/api/hospital", dto);
            await LogIfError(post, "Delete_Hospital_Seed");
            post.EnsureSuccessStatusCode();

            var listResponse = await _client.GetAsync("/api/hospital?pageNumber=1&pageSize=200");
            await LogIfError(listResponse, "Delete_Hospital_List");
            var list = await listResponse.Content.ReadFromJsonAsync<PagedList<HospitalDto>>();
            var existing = list!.Items.Last(x => x.Code == dto.Code);

            var delete = await _client.DeleteAsync($"/api/hospital/{existing.Id}");
            await LogIfError(delete, "Delete_Hospital_Delete");
            delete.StatusCode.Should().Be(HttpStatusCode.OK);

            var deleteAgain = await _client.DeleteAsync($"/api/hospital/{existing.Id}");
            await LogIfError(deleteAgain, "Delete_Hospital_DeleteAgain");
            deleteAgain.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
    }
}
