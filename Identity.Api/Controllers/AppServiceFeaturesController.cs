using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Common.Types.Types.ServiceBus;
using Identity.Api.Contrat.AppServices.Requests;
using Identity.Api.Identity.Domain.AppServices.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Survey.Common.Messages;

namespace Identity.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppServiceFeaturesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IBusPublisher _busPublisher;
        private readonly Dispatcher _dispatcher;

        public AppServiceFeaturesController(IMapper mapper, IBusPublisher busPublisher, Dispatcher dispatcher)
        {
            _mapper = mapper;
            _busPublisher = busPublisher;
            _dispatcher = dispatcher;
        }

        [HttpGet("GetServiceFeatures")]
        public IActionResult GetServiceFeatures(Guid serviceId)
        {
            throw new NotImplementedException();
            //return Ok(_dispatcher.Dispatch(new GetFeatureQuery(featureId)));
        }

        [HttpPost()]
        public IActionResult RegisterFeature([FromBody] RegisterAppServiceFeatureRequest request)
        {
            var command = _mapper.Map<RegisterAppServiceFeatureCommand>(request);

            _busPublisher.SendAsync(command);
            return Ok(request);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] EditAppServiceFeaturesRequest request)
        {
            var command = _mapper.Map<EditAppServiceFeaturesCommand>(request);
            _busPublisher.SendAsync(command);
            return Ok(request);
        }

    }
}