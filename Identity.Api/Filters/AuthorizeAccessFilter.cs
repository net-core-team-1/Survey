using Identity.Api.Data.Repositories.Features;
using Identity.Api.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Filters
{
    public class AuthorizeAccessFilter : IAuthorizationFilter
    {

        private readonly HttpContextHelper _httpHelper;
        private readonly IFeatureRepository _featureRepository;

        public AuthorizeAccessFilter(HttpContextHelper httpHelper
                                     , IFeatureRepository featureRepository
            )
        {
            _httpHelper = httpHelper;
            _featureRepository = featureRepository;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            Guid userId = _httpHelper.GetUserId();
            var controllerName = context.RouteData.Values["controller"] as string;
            var actionName = context.RouteData.Values["action"] as string;
            bool isAuthorized = _featureRepository.DoesUseHaveAccesTo(userId, actionName, controllerName, Guid.Parse("B93378B3-EF83-4296-B516-1FAA1E7E000D"));
            if (!isAuthorized)
            {
                context.Result = new UnauthorizedResult();
            }
        }
    }
}
