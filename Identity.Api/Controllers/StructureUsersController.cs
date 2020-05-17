using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Common.Types.Types.ServiceBus;
using Identity.Api.Contrat.Structures.Requests;
using Identity.Api.Contrats.Structures.Requests;
using Identity.Api.Identity.Domain.Structure.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Survey.Common.Messages;

namespace Identity.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StructureUsersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IBusPublisher _busPublisher;
        private readonly Dispatcher _dispatcher;

        public StructureUsersController(IMapper mapper, IBusPublisher busPublisher, Dispatcher dispatcher)
        {
            _mapper = mapper;
            _busPublisher = busPublisher;
            _dispatcher = dispatcher;
        }

        [HttpGet("GetFeature")]
        public IActionResult GetStructureUsers(Guid structureId)
        {
            throw new NotImplementedException();
            //return Ok(_dispatcher.Dispatch(new GetFeatureQuery(featureId)));
        }

        [HttpPut]
        public IActionResult Edit([FromBody] EditStructureUsersRequest request)
        {
            var command = _mapper.Map<EditStructureUsersCommand>(request);
            _busPublisher.SendAsync(command);
            return Ok(request);
        }

        [HttpPost()]
        public IActionResult Register([FromBody] RegisterStructureUserRequest request)
        {
            var command = _mapper.Map<RegisterStructureUserCommand>(request);
            _busPublisher.SendAsync(command);
            return Ok(request);
        }

        [HttpDelete()]
        public IActionResult Unregister([FromBody] UnregisterUserStructureRequest request)
        {
            var command = _mapper.Map<UnregisterStructureUserCommand>(request);
            _busPublisher.SendAsync(command);
            return Ok(request);
        }

    }
}