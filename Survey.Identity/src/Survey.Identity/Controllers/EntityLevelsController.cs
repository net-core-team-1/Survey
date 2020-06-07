using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Survey.Messaging;
using Survey.Identity.Contracts;
using Survey.Identity.Domain.Users.Commands;
using System;
using System.Threading.Tasks;
using Survey.Identity.Contracts.EntityLevels.Requests;
using Survey.Identity.Domain.Entities.Levels.Commands;

namespace Survey.Identity.Controllers
{
   // [ApiController]
    //public class EntityLevelsController : BaseController
    //{
        //private readonly IMapper _mapper;
        //private readonly LinkGenerator _linkGenerator;
        //private readonly DispatcherAsync _dispatcher;

        //public EntityLevelsController(
        //                       IMapper mapper,
        //                       LinkGenerator linkGenerator,
        //                       DispatcherAsync dispatcher)
        //{
        //    _mapper = mapper;
        //    _linkGenerator = linkGenerator;
        //    _dispatcher = dispatcher;
        //}


        //[HttpPost(ApiRoutes.EntitiyLevels.Create)]
        //public async Task<IActionResult> Create(AddEntityLevelRequest request)
        //{
        //    var addCommand = _mapper.Map<AddEntityLevelCommand>(request);
        //    var result = await _dispatcher.Dispatch(addCommand);
        //    return FromResult(result);
        //}

        //[HttpPost(ApiRoutes.EntitiyLevels.EditeInfo)]
        //public async Task<IActionResult> Edit(Guid id, EditInfoEntityLevelRequest request)
        //{
        //    request.Id = id;
        //    var editCommand = _mapper.Map<EditInfoEntityLevelCommand>(request);
        //    var result = await _dispatcher.Dispatch(editCommand);
        //    return FromResult(result);
        //}


        //[HttpPost(ApiRoutes.EntitiyLevels.Delete)]
        //public async Task<IActionResult> Disable(Guid id, DeleteEntityLevelRequest request)
        //{
        //    request.Id = id;
        //    var command = _mapper.Map<DeleteEntityLevelCommand>(request);
        //    var result = await _dispatcher.Dispatch(command);
        //    return FromResult(result);
        //}



    //}
}
