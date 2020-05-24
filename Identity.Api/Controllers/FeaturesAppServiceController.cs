using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Common.Types.Types.ServiceBus;
using Identity.Api.Contrat.AppServices.Requests;
using Identity.Api.Identity.Domain.AppServices.Commands;
using Identity.Api.Identity.Domain.Features.Commands;
using Identity.Api.Identity.Domain.Features.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Survey.Common.Messages;

namespace Identity.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesAppServiceController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IBusPublisher _busPublisher;
        private readonly Dispatcher _dispatcher;

        public FeaturesAppServiceController(IMapper mapper, IBusPublisher busPublisher, Dispatcher dispatcher)
        {
            _mapper = mapper;
            _busPublisher = busPublisher;
            _dispatcher = dispatcher;
        }

        [HttpGet("GetFeatureListByService")]
        public IActionResult GetServiceFeatures(Guid serviceId)
        {
            return Ok(_dispatcher.Dispatch(new GetListFeaturesByServiceQuery(serviceId)));
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