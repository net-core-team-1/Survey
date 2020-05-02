using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Survey.Common.Messages;
using Survey.Identity.Contracts;
using Survey.Identity.Domain.Features.Commands;
using Survey.Identity.Domain.Users.Commands;
using Survey.Indentity.Domain.Roles.Commands;
using System;
using System.Threading.Tasks;

namespace Survey.Identity.Controllers
{
    //[Route("[controller]")]
    [ApiController]
    public class FeaturesController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;
        private readonly AsyncDispatcher _dispatcher;

        public FeaturesController(IMapper mapper,
                                  LinkGenerator linkGenerator,
                                  AsyncDispatcher dispatcher)
        {
            _mapper = mapper;
            _linkGenerator = linkGenerator;
            _dispatcher = dispatcher;
        }


        [HttpPost(ApiRoutes.Features.Create)]
        public async Task<IActionResult> Create(CreateFeatureRequest request)
        {
            var command = _mapper.Map<CreateFeatureCommand>(request);
        
            var result = await _dispatcher.Dispatch(command);
            return FromResult(result);
        }

        [HttpPost(ApiRoutes.Features.EditInfo)]
        public async Task<IActionResult> EditInfo(Guid id, EditFeatureRequest request)
        {
            request.Id = id;
            var command = _mapper.Map<EditFeatureCommand>(request);
            var result = await _dispatcher.Dispatch(command);
            return FromResult(result);
        }


        [HttpPost(ApiRoutes.Features.Deactivate)]
        public async Task<IActionResult> Deactivate(Guid id, DeactivateFeatureRequest request)
        {
            request.Id = id;
            var command = _mapper.Map<DeactivateFeatureCommand>(request);
            var result = await _dispatcher.Dispatch(command);
            return FromResult(result);
        }

        [HttpPost(ApiRoutes.Features.Remove)]
        public async Task<IActionResult> Remove(Guid id, RemoveFeatureRequest request)
        {
            request.Id = id;
            var command = _mapper.Map<RemoveFeatureCommand>(request);
            var result = await _dispatcher.Dispatch(command);
            return FromResult(result);
        }


    }
}
