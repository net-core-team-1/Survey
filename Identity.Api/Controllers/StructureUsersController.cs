using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Common.Types.Types.ServiceBus;
using Identity.Api.Contrat.Structures.Requests;
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

        [HttpGet("GetFeatureList")]
        public IActionResult GetFeatureList()
        {
            throw new NotImplementedException();
            // return Ok(_dispatcher.Dispatch(new GetListFeaturesQuery()));
        }

        [HttpPost()]
        public IActionResult Register([FromBody] RegisterStructureRequest request)
        {
            throw new NotImplementedException();
            //var command = _mapper.Map<RegisterFeatureCommand>(request);

            //_busPublisher.SendAsync(command);
            //return Ok(request);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] EditStructureRequest request)
        {
            throw new NotImplementedException();
            //var command = _mapper.Map<EditFeatureCommand>(request);
            //_busPublisher.SendAsync(command);
            //return Ok(request);
        }

        
    }
}