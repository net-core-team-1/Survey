using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Common.Types.Types.ServiceBus;
using Identity.Api.Contrat.Structures.Requests;
using Identity.Api.Identity.Domain.Structures.Commands;
using Identity.Api.Identity.Domain.Structures.Queries;
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
        private readonly ICommandSender _commandSender;
        private readonly Dispatcher _dispatcher;

        public StructureController(IMapper mapper, ICommandSender commandSender, Dispatcher dispatcher)
        {
            _mapper = mapper;
            _commandSender = commandSender;
            _dispatcher = dispatcher;
        }

        [HttpGet("GetStructure")]
        public IActionResult GetStructure(Guid structureId)
        {
            return Ok(_dispatcher.Dispatch(new GetStructureByIdQuery(structureId)));
        }

        [HttpGet("GetStructrueList")]
        public IActionResult GetAllStructures()
        {
            return Ok(_dispatcher.Dispatch(new GetStructureListQuery()));
        }

        [HttpPost()]
        public IActionResult Register([FromBody] RegisterStructureRequest request)
        {
            var command = _mapper.Map<RegisterStructureCommand>(request);
            var result = _commandSender.Send(command);
            if (result.IsFailure)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] EditStructureRequest request)
        {
            var command = _mapper.Map<EditStructureCommand>(request);
            var result = _commandSender.Send(command);
            if (result.IsFailure)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpPatch]
        public IActionResult Disable([FromBody] DisableStructureRequest request)
        {
            var command = _mapper.Map<DisableStructureCommand>(request);
            var result = _commandSender.Send(command);
            if (result.IsFailure)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpDelete]
        public IActionResult Unregister([FromBody] DeleteStructureRequest request)
        {
            var command = _mapper.Map<DeleteStructureCommand>(request);
            var result = _commandSender.Send(command);
            if (result.IsFailure)
                return BadRequest(result);
            return Ok(result);
        }
    }
}