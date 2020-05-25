using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Survey.Messaging;
using Survey.Identity.Contracts;
using Survey.Identity.Domain.Users.Commands;
using System;
using System.Threading.Tasks;
using Survey.Identity.Contracts.EntityLevels.Requests;
using Survey.Identity.Domain.Entities.Commands;

namespace Survey.Identity.Controllers
{
    [ApiController]
    public class EntitiesController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;
        private readonly DispatcherAsync _dispatcher;

        public EntitiesController(
                               IMapper mapper,
                               LinkGenerator linkGenerator,
                               DispatcherAsync dispatcher)
        {
            _mapper = mapper;
            _linkGenerator = linkGenerator;
            _dispatcher = dispatcher;
        }


        [HttpPost(ApiRoutes.Entities.Create)]
        public async Task<IActionResult> Create(CreateEntityRequest request)
        {
            var createCommand = _mapper.Map<CreateEntityCommand>(request);
            var result = await _dispatcher.Dispatch(createCommand);
            return FromResult(result);
        }

        [HttpPost(ApiRoutes.Entities.EditeInfo)]
        public async Task<IActionResult> Edit(Guid id, EditInfoEntityRequest request)
        {
            request.Id = id;
            var editCommand = _mapper.Map<EditInfoEntityCommand>(request);
            var result = await _dispatcher.Dispatch(editCommand);
            return FromResult(result);
        }


        [HttpPost(ApiRoutes.Entities.Delete)]
        public async Task<IActionResult> Delete(Guid id, DeleteEntityRequest request)
        {
            request.Id = id;
            var command = _mapper.Map<DeleteEntityCommand>(request);
            var result = await _dispatcher.Dispatch(command);
            return FromResult(result);
        }


    }
}
