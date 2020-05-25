using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Survey.Api.Commands.Users;
using Survey.CQRS.ServiceBus;
using Survey.Transverse.Contract;
using Survey.Transverse.Contract.Users.Requests;
using System;

namespace Survey.Transverse.API.Controllers
{
    [ApiController]
    //[Authorize]
    [EnableCors("AllowOrigin")]
    public class UsersController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;
        private readonly IBusPublisher _busPublisher;

        public UsersController(
                               IMapper mapper,
                               LinkGenerator linkGenerator,
                               IBusPublisher busPublisher)
        {
            _mapper = mapper;
            _linkGenerator = linkGenerator;
            _busPublisher = busPublisher;
        }


        [HttpPost(ApiRoutes.Users.Register)]
        public IActionResult Register(UserRegistrationRequest registerRequest)
        {
            var registerCommand = _mapper.Map<RegisterUserCommand>(registerRequest);
             _busPublisher.SendAsync(registerCommand);

            return Accepted();
        }


        [HttpPost(ApiRoutes.Users.Unregister)]
        public IActionResult Unregister(Guid id, UnregisterRequest unregisterRequest)
        {
            _busPublisher.SendAsync(new UnregisterUserCommand(id, unregisterRequest.By, unregisterRequest.Reason));

            return Accepted();
        }

        [HttpPost(ApiRoutes.Users.EditeInfo)]
        public IActionResult EditInfo(Guid id, EditUserRequest request)
        {
            var command = new EditUserCommand(id, request.FirstName, request.LastName, request.Email, request.Permissions,
                                              request.DeleteExistingPermissions);

            _busPublisher.SendAsync(command);

            return Accepted();
        }

    }

}
