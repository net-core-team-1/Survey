using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Api.Identity.Domain.Features
{
    public class FeatureInfo : ValueObject
    {
        public String Label { get; private set; }
        public String Description { get; private set; }
        public String Controller { get; private set; }
        public string ControllerActionName { get; private set; }
        public String Action { get; private set; }

        protected FeatureInfo()
        {

        }
        private FeatureInfo(string label, string description, string controller, string controllerActionName, string action)
        {
            Label = label;
            Description = description;
            Controller = controller;
            ControllerActionName = controllerActionName;
            Action = action;
        }
        public static Result<FeatureInfo> Create(string label, string description, string controller, string controllerActionName, string action)
        {
            return Result.Success(new FeatureInfo(label, description, controller, controllerActionName, action));
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Label;
            yield return Description;
            yield return Controller;
            yield return ControllerActionName;
            yield return Action;
        }
    }
}
