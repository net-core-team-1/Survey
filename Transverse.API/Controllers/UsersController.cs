using AutoMapper;
using Common.Types.Types.ServiceBus;
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Survey.Common.Messages;
using Survey.Transverse.Contract;
using Survey.Transverse.Contract.Users.Requests;
using Survey.Transverse.Contract.Users.Responses;
using Survey.Transverse.Domain.Users;
using Survey.Transverse.Domain.Users.Commands;
using Survey.Transverse.Domain.Users.Queries;
using System;
using System.Collections.Generic;

namespace Survey.Transverse.API.Controllers
{
    [ApiController]
    //[Authorize]
    [EnableCors("AllowOrigin")]
    public class UsersController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly Dispatcher _dispatcher;
        private readonly LinkGenerator _linkGenerator;
        private readonly IUserRepository _userRepository;
        private readonly IBusPublisher _busPublisher;

        public UsersController(Dispatcher dispatcher,
                               IMapper mapper,
                               LinkGenerator linkGenerator,
                               IUserRepository userRepository,
                               IBusPublisher busPublisher)
        {
            _mapper = mapper;
            _dispatcher = dispatcher;
            _linkGenerator = linkGenerator;
            _userRepository = userRepository;
            _busPublisher = busPublisher;
        }


        [HttpPost(ApiRoutes.Users.Register)]
        public IActionResult Register(UserRegistrationRequest registerRequest)
        {
            var registerCommand = _mapper.Map<RegisterUserCommand>(registerRequest);
             _busPublisher.SendAsync(registerCommand);

            //    Result result = _dispatcher.Dispatch(registerCommand);
            return Ok();
        }


        [HttpGet(ApiRoutes.Users.QueryAll)]
        public IActionResult GetList()
        {
            bool isAuthorized = _userRepository.DoesUserHaveAccessTo(Guid.Parse("7E7335D2-F275-4CC2-BA00-35D83F9C5203"), "QuerryAllUsers");
            List<UserListResponse> list = _dispatcher.Dispatch(new GetListUsersQuery());
            return Ok(list);
        }


        [HttpGet(ApiRoutes.Users.QueryById)]
        public IActionResult GetById(Guid id)
        {
            var user = _dispatcher.Dispatch(new GetUserByIdQuery(id));
            if (user == null)
                return NotFound("user not found");
            var userModel = _mapper.Map<UserResponse>(user);
            return Ok(userModel);
        }


        [HttpPost(ApiRoutes.Users.Unregister)]
        public IActionResult Unregister(Guid id, UnregisterRequest unregisterRequest)
        {
            var result = _dispatcher.Dispatch(new UnregisterUserCommand(id, unregisterRequest.By, unregisterRequest.Reason));

            return FromResult(result);
        }

        [HttpPost(ApiRoutes.Users.EditeInfo)]
        public IActionResult EditInfo(Guid id, EditUserRequest request)
        {
            var command = new EditUserCommand(id, request.FirstName, request.LastName, request.Email, request.Permissions,
                                              request.DeleteExistingPermissions);

            var result = _dispatcher.Dispatch(command);

            return FromResult(result);
        }

    }

}
