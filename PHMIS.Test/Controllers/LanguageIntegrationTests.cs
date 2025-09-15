using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using PHMIS.Application.Common;
using PHMIS.Application.DTO.Localization;
using PHMIS.Test.TestInfrastructure;
using Xunit;
using Xunit.Abstractions;

namespace PHMIS.Test.Controllers
{
    public class LanguageIntegrationTests : IClassFixture<CustomWebApplicationFactory>, IAsyncLifetime
    {
        private readonly CustomWebApplicationFactory _factory;
        private readonly HttpClient _client;
        private readonly ITestOutputHelper _output;

        public LanguageIntegrationTests(CustomWebApplicationFactory factory, ITestOutputHelper output)
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

        public Task InitializeAsync() => Task.CompletedTask;
        public Task DisposeAsync() => Task.CompletedTask;

        [Fact]
        public async Task Post_CreateLanguage_ReturnsOk_And_CanGetById()
        {
            var dto = new LanguageCreateDto { Name = "Spanish", Code = "es", IsActive = true };
            var postResponse = await _client.PostAsJsonAsync("/api/language", dto);
            await LogIfError(postResponse, "Post_CreateLanguage");
            postResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            var created = await postResponse.Content.ReadFromJsonAsync<LanguageDto>();
            created.Should().NotBeNull();
            created!.Name.Should().Be(dto.Name);
            created.Code.Should().Be(dto.Code);

            var getById = await _client.GetAsync($"/api/language/{created.Id}");
            await LogIfError(getById, "GetById");
            getById.StatusCode.Should().Be(HttpStatusCode.OK);
            var got = await getById.Content.ReadFromJsonAsync<LanguageDto>();
            got!.Name.Should().Be(dto.Name);
        }

        [Fact]
        public async Task Get_ListLanguages_ReturnsPagedList()
        {
            var response = await _client.GetAsync("/api/language?pageNumber=1&pageSize=10");
            await LogIfError(response, "Get_ListLanguages");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var paged = await response.Content.ReadFromJsonAsync<PagedList<LanguageDto>>();
            paged.Should().NotBeNull();
            paged!.Items.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public async Task Put_UpdateLanguage_Works()
        {
            var dto = new LanguageCreateDto { Name = "German", Code = "de", IsActive = true };
            var postResponse = await _client.PostAsJsonAsync("/api/language", dto);
            await LogIfError(postResponse, "Put_UpdateLanguage_Seed");
            postResponse.EnsureSuccessStatusCode();
            var created = await postResponse.Content.ReadFromJsonAsync<LanguageDto>();

            var updated = new LanguageCreateDto { Name = "German Updated", Code = "de", IsActive = false };
            var putResponse = await _client.PutAsJsonAsync($"/api/language/{created.Id}", updated);
            await LogIfError(putResponse, "Put_UpdateLanguage_Update");
            putResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            var got = await putResponse.Content.ReadFromJsonAsync<LanguageDto>();
            got!.Name.Should().Be("German Updated");
            got.IsActive.Should().BeFalse();
        }

        [Fact]
        public async Task Delete_Language_Works_And_ReturnsNotFound_WhenMissing()
        {
            var dto = new LanguageCreateDto { Name = "Italian", Code = "it", IsActive = true };
            var postResponse = await _client.PostAsJsonAsync("/api/language", dto);
            await LogIfError(postResponse, "Delete_Language_Seed");
            postResponse.EnsureSuccessStatusCode();
            var created = await postResponse.Content.ReadFromJsonAsync<LanguageDto>();

            var deleteResponse = await _client.DeleteAsync($"/api/language/{created.Id}");
            await LogIfError(deleteResponse, "Delete_Language_Delete");
            deleteResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var deleteAgain = await _client.DeleteAsync($"/api/language/{created.Id}");
            await LogIfError(deleteAgain, "Delete_Language_DeleteAgain");
            deleteAgain.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
    }
}
