using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using PHMIS.Application.Common;
using PHMIS.Application.DTO.Provinces;
using PHMIS.Test.TestInfrastructure;
using Xunit;
using Xunit.Abstractions;

namespace PHMIS.Test.Controllers
{
    public class ProvinceTranslationIntegrationTests : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly CustomWebApplicationFactory _factory;
        private readonly HttpClient _client;
        private readonly ITestOutputHelper _output;

        public ProvinceTranslationIntegrationTests(CustomWebApplicationFactory factory, ITestOutputHelper output)
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

        [Fact]
        public async Task Create_Update_Delete_ProvinceTranslation_Workflow()
        {
            // Create province first
            var provinceCreate = new ProvinceCreateDto { Name = "Test Province" };
            var postProvince = await _client.PostAsJsonAsync("/api/province", provinceCreate);
            await LogIfError(postProvince, "CreateProvince");
            postProvince.EnsureSuccessStatusCode();

            // Get created province Id
            var list = await _client.GetFromJsonAsync<PagedList<ProvinceDto>>("/api/province?pageNumber=1&pageSize=10");
            var created = list!.Items.First(x => x.Name == provinceCreate.Name);

            // Create translation
            var trans = new ProvinceTranslationDto { ProvinceId = created.Id, Language = "es", IsDefault = false, Name = "Provincia Prueba" };
            var postTrans = await _client.PostAsJsonAsync("/api/provincetranslation", trans);
            await LogIfError(postTrans, "CreateTrans");
            postTrans.EnsureSuccessStatusCode();
            var createdTrans = await postTrans.Content.ReadFromJsonAsync<ProvinceTranslationDto>();
            createdTrans.Should().NotBeNull();
            createdTrans!.Name.Should().Be(trans.Name);

            // Get by id
            var getById = await _client.GetAsync($"/api/provincetranslation/{createdTrans.Id}");
            await LogIfError(getById, "GetById");
            getById.StatusCode.Should().Be(HttpStatusCode.OK);

            // Update
            createdTrans.Name = "Provincia Actualizada";
            var put = await _client.PutAsJsonAsync($"/api/provincetranslation/{createdTrans.Id}", createdTrans);
            await LogIfError(put, "Update");
            put.EnsureSuccessStatusCode();
            var updated = await put.Content.ReadFromJsonAsync<ProvinceTranslationDto>();
            updated!.Name.Should().Be("Provincia Actualizada");

            // List translations for province
            var listTrans = await _client.GetAsync($"/api/provincetranslation/province/{created.Id}");
            await LogIfError(listTrans, "ListTrans");
            listTrans.EnsureSuccessStatusCode();
            var listDto = await listTrans.Content.ReadFromJsonAsync<List<ProvinceTranslationDto>>();
            listDto!.Should().Contain(x => x.Name == "Provincia Actualizada");

            // Delete
            var del = await _client.DeleteAsync($"/api/provincetranslation/{createdTrans.Id}");
            await LogIfError(del, "Delete");
            del.EnsureSuccessStatusCode();

            // Delete again -> NotFound
            var delAgain = await _client.DeleteAsync($"/api/provincetranslation/{createdTrans.Id}");
            await LogIfError(delAgain, "DeleteAgain");
            delAgain.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
    }
}
