using MediatR;
using Microsoft.AspNetCore.Mvc;
using PHMIS.Application.Common;
using PHMIS.Application.DTO.Localization;
using PHMIS.Application.Features.Localization.Commands;
using PHMIS.Application.Features.Localization.Queries;
using PHMIS.Controllers.Base;

namespace PHMIS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageController : BaseApiController
    {
        [HttpPost]
        public async Task<ActionResult<LanguageDto>> Create(LanguageCreateDto dto) =>
            HandleResultResponse(await Mediator.Send(new CreateLanguageCommand(dto)));

        [HttpGet]
        public async Task<ActionResult<PagedList<LanguageDto>>> GetAll([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 25) =>
            HandleResultResponse(await Mediator.Send(new GetLanguageListQuery(pageNumber, pageSize)));

        [HttpGet("{id}")]
        public async Task<ActionResult<LanguageDto>> GetById(int id) =>
            HandleResultResponse(await Mediator.Send(new GetLanguageByIdQuery(id)));

        [HttpPut("{id}")]
        public async Task<ActionResult<LanguageDto>> Update(int id, LanguageCreateDto dto) =>
            HandleResultResponse(await Mediator.Send(new UpdateLanguageCommand(id, dto)));

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(int id) =>
            HandleResultResponse(await Mediator.Send(new DeleteLanguageCommand(id)));
    }
}
