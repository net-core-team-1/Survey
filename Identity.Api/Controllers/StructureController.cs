using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Common.Types.Types.ServiceBus;
using Identity.Api.Contrat.Structures.Requests;
using Identity.Api.Identity.Domain.Structure.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Survey.Common.Messages;

namespace Identity.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StructureController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IBusPublisher _busPublisher;
        private readonly Dispatcher _dispatcher;

        public StructureController(IMapper mapper, IBusPublisher busPublisher, Dispatcher dispatcher)
        {
            _mapper = mapper;
            _busPublisher = busPublisher;
            _dispatcher = dispatcher;
        }

        [HttpGet("GetStructure")]
        public IActionResult GetStructure(Guid structureId)
        {
            throw new NotImplementedException();
            //return Ok(_dispatcher.Dispatch(new GetFeatureQuery(featureId)));
        }

        [HttpGet("GetStructrueList")]
        public IActionResult GetAllStructures()
        {
            throw new NotImplementedException();
            //return Ok(_dispatcher.Dispatch(new GetListFeaturesQuery()));
        }

        [HttpPost()]
        public IActionResult Register([FromBody] RegisterStructureRequest request)
        {
            var command = _mapper.Map<RegisterStructureCommand>(request);
            _busPublisher.SendAsync(command);
            return Ok(request);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] EditStructureRequest request)
        {
            var command = _mapper.Map<EditStructureCommand>(request);
            _busPublisher.SendAsync(command);
            return Ok(request);
        }

        [HttpPatch]
        public IActionResult Disable([FromBody] DisableStructureRequest request)
        {
            var command = _mapper.Map<DisableStructureCommand>(request);
            _busPublisher.SendAsync(command);
            return Ok(request);
        }

        [HttpDelete]
        public IActionResult Unregister([FromBody] DeleteStructureRequest request)
        {
            var command = _mapper.Map<DeleteStructureCommand>(request);
            _busPublisher.SendAsync(command);
            return Ok(request);
        }
    }
}