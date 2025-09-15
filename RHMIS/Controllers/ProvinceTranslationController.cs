using MediatR;
using Microsoft.AspNetCore.Mvc;
using PHMIS.Application.Common;
using PHMIS.Application.DTO.Provinces;
using PHMIS.Application.Features.Provinces.Commands;
using PHMIS.Application.Features.Provinces.Queries;
using PHMIS.Controllers.Base;

namespace PHMIS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvinceTranslationController : BaseApiController
    {
        [HttpPost]
        public async Task<ActionResult<ProvinceTranslationDto>> Create(ProvinceTranslationDto dto) =>
            HandleResultResponse(await Mediator.Send(new CreateProvinceTranslationCommand(dto)));

        [HttpGet("province/{provinceId}")]
        public async Task<ActionResult<List<ProvinceTranslationDto>>> GetByProvince(int provinceId) =>
            HandleResultResponse(await Mediator.Send(new GetProvinceTranslationListQuery(provinceId)));

        [HttpGet("{id}")]
        public async Task<ActionResult<ProvinceTranslationDto>> GetById(int id) =>
            HandleResultResponse(await Mediator.Send(new GetProvinceTranslationByIdQuery(id)));

        [HttpPut("{id}")]
        public async Task<ActionResult<ProvinceTranslationDto>> Update(int id, ProvinceTranslationDto dto) =>
            HandleResultResponse(await Mediator.Send(new UpdateProvinceTranslationCommand(id, dto)));

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(int id) =>
            HandleResultResponse(await Mediator.Send(new DeleteProvinceTranslationCommand(id)));
    }
}
