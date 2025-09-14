using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using PHMIS.Application.Identity.Models;
using PHMIS.Test.TestInfrastructure;
using Xunit;
using Xunit.Abstractions;

namespace PHMIS.Test.Controllers
{
    public class UsersIntegrationTests : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly HttpClient _client;
        private readonly ITestOutputHelper _output;

        public UsersIntegrationTests(CustomWebApplicationFactory factory, ITestOutputHelper output)
        {
            _client = factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });
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

        [Fact]
        public async Task CreateUser_Should_Create_And_Return_Id()
        {
            var dto = new UserCreateDto
            {
                UserName = $"testuser_{Guid.NewGuid():N}",
                Email = $"test_{Guid.NewGuid():N}@local",
                Password = "Pass@123",
                FirstName = "Test",
                LastName = "User",
                Roles = new[] { "User" },
                HospitalId = 1
            };

            var response = await _client.PostAsJsonAsync("/api/users", dto);
            await LogIfError(response, "CreateUser");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var id = await response.Content.ReadFromJsonAsync<int>();
            id.Should().BeGreaterThan(0);
        }

        [Fact]
        public async Task GetUsers_Should_Return_List()
        {
            var response = await _client.GetAsync("/api/users");
            await LogIfError(response, "GetUsers");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
