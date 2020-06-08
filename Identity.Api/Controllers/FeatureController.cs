using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Common.Types.Types.ServiceBus;
using CSharpFunctionalExtensions;
using Identity.Api.Contrat.Features.Requests;
using Identity.Api.Identity.Domain.Features.Commands;
using Identity.Api.Identity.Domain.Features.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Survey.Common.Messages;

namespace Identity.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICommandSender _commandSender;
        private readonly Dispatcher _dispatcher;

        public FeatureController(IMapper mapper, ICommandSender commandSender, Dispatcher dispatcher)
        {
            _mapper = mapper;
            _commandSender = commandSender;
            _dispatcher = dispatcher;
        }

        [HttpGet("GetFeature")]
        public IActionResult GetFeature(Guid featureId)
        {
            return Ok(_dispatcher.Dispatch(new GetFeatureQuery(featureId)));
        }

        [HttpGet("GetFeatureList")]
        public IActionResult GetFeatureList()
        {
            return Ok(_dispatcher.Dispatch(new GetListFeaturesQuery()));
        }

        [HttpPost()]
        public IActionResult Register([FromBody] RegisterFeatureRequest request)
        {
            var command = _mapper.Map<RegisterFeatureCommand>(request);
            var result = _commandSender.Send(command);
            if (result.IsFailure)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] EditFeatureRequest request)
        {
            var command = _mapper.Map<EditFeatureCommand>(request);
            var result = _commandSender.Send(command);
            if (result.IsFailure)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpPatch]
        public IActionResult Disable([FromBody] DisableFeatureRequest request)
        {
            var command = _mapper.Map<DisableFeatureCommand>(request);
            var result = _commandSender.Send(command);
            if (result.IsFailure)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpDelete]
        public IActionResult Unregister([FromBody] UnregisterFeatureRequest request)
        {
            var command = _mapper.Map<UnRegisterFeatureCommand>(request);
            var result = _commandSender.Send(command);
            if (result.IsFailure)
                return BadRequest(result);
            return Ok(result);
        }
    }
}