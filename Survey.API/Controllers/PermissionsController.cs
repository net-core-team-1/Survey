using System;
using System.Collections.Generic;
using AutoMapper;
using Common.Types.Types.ServiceBus;
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Survey.Api.Commands.Permissions;
using Survey.Common.Messages;
using Survey.Transverse.Contract;
using Survey.Transverse.Contract.Permissions.Requests;
using Survey.Transverse.Contract.Permissions.Responses;

namespace Survey.Transverse.API.Controllers
{
    [ApiController]
    //[Authorize]

    public class PermissionsController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;
        private readonly IBusPublisher _busPublisher;

        public PermissionsController(Dispatcher dispatcher,
                               IMapper mapper,
                               LinkGenerator linkGenerator,
                               IBusPublisher busPublisher)
        {
            _mapper = mapper;
            _linkGenerator = linkGenerator;
            _busPublisher = busPublisher;
        }

        [HttpPost(ApiRoutes.Permissions.Create)]
        [Produces("application/json")]
        public IActionResult Post(CreatePermissionRequest request)
        {
            var command = new CreatePermissionCommand(request.Label, request.Description, request.CreatedBy,request.Features);
            _busPublisher.SendAsync(command);
            return Accepted();
        }


        [HttpPost(ApiRoutes.Permissions.Deactivate)]
        [Produces("application/json")]
        public IActionResult Post(Guid id, DeactivatePermissionRequest request)
        {
            var command = new DeactivatePermissionCommand(id, request.DeletedBy);
            _busPublisher.SendAsync(command);
            return Accepted();
        }

        [HttpPost(ApiRoutes.Permissions.Remove)]
        [Produces("application/json")]
        public IActionResult Remove(Guid id, RemovePermissionRequest request)
        {
            var command = new RemovePermissionCommand(id, request.DeletedBy, request.Reason);
            _busPublisher.SendAsync(command);
            return Accepted();
        }

        [HttpPost(ApiRoutes.Permissions.Edit)]
        public IActionResult EditInfo(Guid id, EditPermissionRequest request)
        {
            var command = new EditPermissionCommand(id, request.Label, request.Description, 
                                                    request.Features, request.DeleteExistingFeatures);
            _busPublisher.SendAsync(command);
            return Accepted();
        }

    }
}
