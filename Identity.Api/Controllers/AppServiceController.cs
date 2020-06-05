using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Common.Types.Types.ServiceBus;
using Identity.Api.Contrat.AppServices.Requests;
using Identity.Api.Identity.Domain.AppServices.Commands;
using Identity.Api.Identity.Domain.AppServices.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Survey.Common.Messages;

namespace Identity.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppServiceController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IBusPublisher _busPublisher;
        private readonly Dispatcher _dispatcher;

        public AppServiceController(IMapper mapper, IBusPublisher busPublisher, Dispatcher dispatcher)
        {
            _mapper = mapper;
            _busPublisher = busPublisher;
            _dispatcher = dispatcher;
        }

        [HttpGet("GetService")]
        public IActionResult GetService(Guid serviceId)
        {
            return Ok(_dispatcher.Dispatch(new GetAppServiceByIdQuery(serviceId)));
        }

        [HttpGet("GetServiceList")]
        public IActionResult GetAllServices()
        {
            return Ok(_dispatcher.Dispatch(new GetListAppServiceQuery()));
        }

        [HttpGet("GetDetailledServiceInfo")]
        public IActionResult GetDetailledServiceInfo(Guid serviceId)
        {
            return Ok(_dispatcher.Dispatch(new GetDetailledAppServiceQuery(serviceId)));
        }

        [HttpPost()]
        public IActionResult Register([FromBody] RegisterAppServiceRequest request)
        {
            var command = _mapper.Map<RegisterAppServiceCommand>(request);
            _busPublisher.SendAsync(command);
            return Ok(request);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] EditAppServiceRequest request)
        {
            var command = _mapper.Map<EditAppServiceCommand>(request);
            _busPublisher.SendAsync(command);
            return Ok(request);
        }

        [HttpPatch]
        public IActionResult Disable([FromBody] DisableAppServiceRequest request)
        {
            var command = _mapper.Map<DisableAppServiceCommand>(request);
            _busPublisher.SendAsync(command);
            return Ok(request);
        }

        [HttpDelete]
        public IActionResult Unregister([FromBody] DeleteAppServiceRequest request)
        {
            var command = _mapper.Map<DeleteAppServiceCommand>(request);
            _busPublisher.SendAsync(command);
            return Ok(request);
        }
    }
}