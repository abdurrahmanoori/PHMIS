using FluentAssertions;
using PHMIS.Application.Common;
using PHMIS.Application.DTO.Patients;
using PHMIS.Test.Builders;
using PHMIS.Test.TestInfrastructure;
using PHMIS.Test.Extensions;
using System.Net;
using System.Net.Http.Json;
using Xunit;
using Xunit.Abstractions;

namespace PHMIS.Test.Controllers
{
    public class PatientIntegrationTests : IClassFixture<CustomWebApplicationFactory>, IAsyncLifetime
    {
        private readonly CustomWebApplicationFactory _factory;
        private readonly HttpClient _client;
        private readonly ITestOutputHelper _output;

        public PatientIntegrationTests(CustomWebApplicationFactory factory, ITestOutputHelper output)
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
            // Clean up before each test
            await _factory.CleanupPatientsAsync();
        }

        public Task DisposeAsync() => Task.CompletedTask;

        [Fact]
        public async Task Post_CreatePatient_ReturnsOk_And_CanGetById()
        {
            // Arrange
            var dto = PatientBuilder.CreateValidPatient();
            dto.HospitalId = 1;

            // Act
            var postResponse = await _client.PostAsJsonAsync("/api/patient", dto);
            await LogIfError(postResponse, "Post_CreatePatient");
            // Assert
            postResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            var created = await postResponse.Content.ReadFromJsonAsync<PatientDto>();
            created.Should().NotBeNull();
            created!.Name.Should().Be(dto.Name);

            // Verify list contains the new patient
            var listResponse = await _client.GetAsync("/api/patient?pageNumber=1&pageSize=100");
            await LogIfError(listResponse, "ListPatients");
            listResponse.EnsureSuccessStatusCode();
            var paged = await listResponse.Content.ReadFromJsonAsync<PagedList<PatientDto>>();
            paged.Should().NotBeNull();
            paged!.Items.Should().NotBeNull();
            paged.Items.Should().Contain(x => x.Email == dto.Email);

            // Get by id
            var createdItem = paged.Items.Last(x => x.Email == dto.Email);
            var getById = await _client.GetAsync($"/api/patient/{createdItem.Id}");
            await LogIfError(getById, "GetById");
            getById.StatusCode.Should().Be(HttpStatusCode.OK);
            var got = await getById.Content.ReadFromJsonAsync<PatientDto>();
            got!.Email.Should().Be(dto.Email);
        }

        [Fact]
        public async Task Post_CreatePatient_Invalid_ReturnsBadRequest()
        {
            // Arrange
            var invalid = new PatientCreateDto
            {
                Name = "", // invalid
                LastName = "",
                DateOfBirth = DateTime.UtcNow.AddDays(1), // future date invalid
                Gender = "",
                PhoneNumber = "",
                Email = "not-an-email",
                Address = "",
                HospitalId = 1
            };

            // Act
            var response = await _client.PostAsJsonAsync("/api/patient", invalid);
            await LogIfError(response, "Post_CreatePatient_Invalid");
            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task Get_ListPatients_ReturnsPagedList()
        {
            // Arrange - Create some patients first
            for (int i = 0; i < 3; i++)
            {
                var dto = new PatientBuilder()
                    .WithEmail($"user{i}_{Guid.NewGuid():N}@test.local")
                    .WithHospitalId(1)
                    .BuildCreateDto();
                var postResponse = await _client.PostAsJsonAsync("/api/patient", dto);
                await LogIfError(postResponse, $"SeedPatient_{i}");
            }

            // Act
            var response = await _client.GetAsync("/api/patient?pageNumber=1&pageSize=2");
            await LogIfError(response, "Get_ListPatients");
            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var paged = await response.Content.ReadFromJsonAsync<PagedList<PatientDto>>();
            paged.Should().NotBeNull();
            paged!.Items.Count.Should().Be(2);
            paged.PageNumber.Should().Be(1);
            paged.PageSize.Should().Be(2);
            paged.TotalCount.Should().Be(3);
        }

        [Fact]
        public async Task Get_ById_ReturnsNotFound_ForUnknownId()
        {
            // Act
            var response = await _client.GetAsync("/api/patient/99999");
            await LogIfError(response, "Get_ById_Unknown");
            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task Put_UpdatePatient_Works()
        {
            // Arrange - Create a patient first
            var dto = PatientBuilder.CreateValidPatient();
            dto.HospitalId = 1;
            var createResponse = await _client.PostAsJsonAsync("/api/patient", dto);
            await LogIfError(createResponse, "Put_UpdatePatient_Create");
            createResponse.EnsureSuccessStatusCode();

            // Get the created patient
            var listResponse = await _client.GetAsync("/api/patient?pageNumber=1&pageSize=100");
            await LogIfError(listResponse, "Put_UpdatePatient_List");
            var list = await listResponse.Content.ReadFromJsonAsync<PagedList<PatientDto>>();
            var existing = list!.Items.Last(x => x.Email == dto.Email);

            var updated = new PatientCreateDto
            {
                Name = existing.Name,
                LastName = "Updated",
                DateOfBirth = existing.DateOfBirth,
                Gender = existing.Gender,
                PhoneNumber = existing.PhoneNumber,
                Email = existing.Email,
                Address = existing.Address,
                HospitalId = 1
            };

            // Act
            var updateResponse = await _client.PutAsJsonAsync($"/api/patient/{existing.Id}", updated);
            await LogIfError(updateResponse, "Put_UpdatePatient_Update");
            // Assert
            updateResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            var updatedDto = await updateResponse.Content.ReadFromJsonAsync<PatientDto>();
            updatedDto!.LastName.Should().Be("Updated");
        }

        [Fact]
        public async Task Delete_Patient_Works_And_ReturnsNotFound_WhenMissing()
        {
            // Arrange: Create a patient
            var dto = PatientBuilder.CreateValidPatient();
            dto.HospitalId = 1;
            var createResponse = await _client.PostAsJsonAsync("/api/patient", dto);
            await LogIfError(createResponse, "Delete_Patient_Create");
            createResponse.EnsureSuccessStatusCode();

            var listResponse = await _client.GetAsync("/api/patient?pageNumber=1&pageSize=200");
            await LogIfError(listResponse, "Delete_Patient_List");
            var list = await listResponse.Content.ReadFromJsonAsync<PagedList<PatientDto>>();
            var existing = list!.Items.Last(x => x.Email == dto.Email);

            // Act
            var deleteResponse = await _client.DeleteAsync($"/api/patient/{existing.Id}");
            await LogIfError(deleteResponse, "Delete_Patient_Delete");
            // Assert
            deleteResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            // Deleting again should yield NotFound
            var deleteAgain = await _client.DeleteAsync($"/api/patient/{existing.Id}");
            await LogIfError(deleteAgain, "Delete_Patient_DeleteAgain");
            deleteAgain.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
    }
}
