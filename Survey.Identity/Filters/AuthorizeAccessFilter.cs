using Microsoft.AspNetCore.Mvc.Filters;
using System;
using Survey.Identity.Util;
using Survey.Identity.Services.Features;
using Microsoft.AspNetCore.Mvc;

namespace Survey.Api.Filters
{
    public class AuthorizeAccessFilter : IAuthorizationFilter
    {
        private readonly string _actionName;
        private readonly HttpContextHelper _httpHelper;
        private readonly IFeatureService _featureService;

        public AuthorizeAccessFilter(HttpContextHelper httpHelper,
                                     string actionName,
                                     IFeatureService featureService)
        {
            _actionName = actionName;
            _httpHelper = httpHelper;
            _featureService = featureService;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            Guid userId = _httpHelper.GetUserId();
            string actionName = _actionName;

            bool isAuthorized = _featureService.DoesUseHaveAccesTo(userId, actionName);

            if (!isAuthorized)
            {
                context.Result = new UnauthorizedResult();
            }
        }


    }
}
