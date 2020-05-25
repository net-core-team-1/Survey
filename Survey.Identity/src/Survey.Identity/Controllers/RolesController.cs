using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Survey.Messaging;
using Survey.Identity.Contracts;
using Survey.Indentity.Domain.Roles.Commands;
using System;
using System.Threading.Tasks;

namespace Survey.Identity.Controllers
{
    [ApiController]
    public class RolesController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;
        private readonly DispatcherAsync _dispatcher;

        public RolesController(
                               IMapper mapper,
                               LinkGenerator linkGenerator,
                               DispatcherAsync dispatcher)
        {
            _mapper = mapper;
            _linkGenerator = linkGenerator;
            _dispatcher = dispatcher;
        }


        [HttpPost(ApiRoutes.Roles.Create)]
        public async Task<IActionResult> Create(CreateRoleRequest request)
        {
            var command = _mapper.Map<CreateRoleRequest,CreateRoleCommand>(request);
            command.Features = request.Features;// to fix after
            var result = await _dispatcher.Dispatch(command);
            return FromResult(result);
        }

        [HttpPost(ApiRoutes.Roles.Edit)] 
        public async Task<IActionResult> Edit(Guid id, EditRoleRequest request)
        {
            request.Id = id;
            var command = _mapper.Map<EditRoleCommand>(request);
            var result = await _dispatcher.Dispatch(command);
            return FromResult(result);
        }


        [HttpPost(ApiRoutes.Roles.UpdateFeatures)]
        public async Task<IActionResult> UpdateFeatures(Guid id, UpdateRoleFeaturesRequest request)
        {
            request.Id = id;
            var command = _mapper.Map<UpdateRoleFeaturesCommand>(request);
            command.Features = request.Features;// to fix after
            var result = await _dispatcher.Dispatch(command);
            return FromResult(result);
        }

        [HttpPost(ApiRoutes.Roles.Deactivate)]
        public async Task<IActionResult> Deactivate(Guid id, DeactivateRoleRequest request)
        {
            request.Id = id;
            var command = _mapper.Map<DeactivateRoleCommand>(request);
            var result = await _dispatcher.Dispatch(command);
            return FromResult(result);
        }

        [HttpPost(ApiRoutes.Roles.Activate)]
        public async Task<IActionResult> Activate(Guid id, ActivateRoleRequest request)
        {
            request.Id = id;
            var command = _mapper.Map<ActivateRoleCommand>(request);
            var result = await _dispatcher.Dispatch(command);
            return FromResult(result);
        }


        [HttpPost(ApiRoutes.Roles.Remove)]
        public async Task<IActionResult> Remove(Guid id, RemoveRoleRequest request)
        {
            request.Id = id;
            var command = _mapper.Map<RemoveRoleCommand>(request);
            var result = await _dispatcher.Dispatch(command);
            return FromResult(result);
        }

    }
}
