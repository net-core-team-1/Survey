using Microsoft.AspNetCore.Mvc.Filters;
using System;
using Survey.Api._Helpers;
using Survey.Transverse.Domain.Users;

namespace Survey.Api.Filters
{
    public class AuthorizeAccessFilter : IAuthorizationFilter
    {
        private readonly string _actionName;
        private readonly HttpContextHelper _httpHelper;
        private readonly IUserRepository _userRepository;

        public AuthorizeAccessFilter(HttpContextHelper httpHelper,
                                     string actionName,
                                     IUserRepository userRepository)
        {
            _actionName = actionName;
            _httpHelper = httpHelper;
            _userRepository = userRepository;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            Guid userId = _httpHelper.GetUserId();
            string actionName = _actionName;

            bool isAuthorized = _userRepository.DoesUserHaveAccessTo(userId, actionName);

            //if (!isAuthorized)
            //{
            //    context.Result = new UnauthorizedResult();
            //}
        }


    }
}
