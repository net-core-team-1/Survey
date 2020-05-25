using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Survey.Api.Commands.Features;
using Survey.CQRS.ServiceBus;
using Survey.Transverse.Contract;
using Survey.Transverse.Contract.Features.Requests;


namespace Survey.Transverse.API.Controllers
{
    [ApiController]
    //[Authorize]

    public class FeaturesController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;
        private readonly IBusPublisher _busPublisher;

        public FeaturesController(
                               IMapper mapper,
                               LinkGenerator linkGenerator,
                               IBusPublisher busPublisher)
        {
            _mapper = mapper;
            _linkGenerator = linkGenerator;
            _busPublisher = busPublisher;
        }

        [HttpPost(ApiRoutes.Features.Create)]
        [Produces("application/json")]
        public IActionResult Post(CreateFeatureRequest request)
        {
            var command = new CreateFeatureCommand(request.Label, request.Description, request.Action, request.Controller,
                                                request.ControllerActionName, request.CreatedBy);
            _busPublisher.SendAsync(command);
            return Accepted();
        }


        [HttpPost(ApiRoutes.Features.Deactivate)]
        [Produces("application/json")]
        public IActionResult Post(Guid id, DeactivateFeatureRequest request)
        {
            var command = new DeactivateFeatureCommand(id, request.DeletedBy);
            _busPublisher.SendAsync(command);
            return Accepted();
        }

        [HttpPost(ApiRoutes.Features.Remove)]
        [Produces("application/json")]
        public IActionResult Remove(Guid id, RemoveFeatureRequest request)
        {
            var command = new RemoveFeatureCommand(id, request.DeletedBy, request.Reason);
            _busPublisher.SendAsync(command);
            return Accepted();
        }

        [HttpPost(ApiRoutes.Features.EditInfo)]
        public IActionResult EditInfo(Guid id, EditFeatureRequest request)
        {
            request.Id = id;
            var command = _mapper.Map<EditFeatureCommand>(request);

            _busPublisher.SendAsync(command);
            return Accepted();
        }

    }
}
