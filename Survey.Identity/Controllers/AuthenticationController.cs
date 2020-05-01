using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Survey.Common.Messages;
using Survey.Identity.Contracts;
using Survey.Identity.Domain.Authentication.Commands;
using System.Threading.Tasks;

namespace Survey.Identity.Controllers
{
    [ApiController]
    public class AuthenticationController: ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;
        private readonly AsyncDispatcher _dispatcher;


        public AuthenticationController(
                          IMapper mapper,
                          LinkGenerator linkGenerator,
                          AsyncDispatcher dispatcher)
        {
            _mapper = mapper;
            _linkGenerator = linkGenerator;
            _dispatcher = dispatcher;
        }


        [HttpPost(ApiRoutes.Identity.SignIn)]
        public async Task<IActionResult> SignIn(SignInRequest request)
        {
            var command = _mapper.Map<SignInCommand>(request);
            var result = await _dispatcher.Dispatch(command);
            return Ok();
        }

        [HttpPost(ApiRoutes.Identity.SignOut)]
        public async Task<IActionResult> SignIn(SignOutRequest request)
        {
            var command = _mapper.Map<SignOutCommand>(request);
            var result = await _dispatcher.Dispatch(command);
            return Ok();
        }

        [HttpPost(ApiRoutes.Identity.ChangePassword)]
        public async Task<IActionResult> ChangePassword(ChangePasswordRequest request)
        {
            var command = _mapper.Map<ChangePasswordCommand>(request);
            var result = await _dispatcher.Dispatch(command);
            return Ok();
        }

    
    }
}
