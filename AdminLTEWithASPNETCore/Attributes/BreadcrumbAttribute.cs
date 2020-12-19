using AdminLTEWithASPNETCore.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminLTEWithASPNETCore.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Assembly, AllowMultiple = true)]
    public class BreadcrumbAttribute : Attribute
    {
        public BreadcrumbAttribute(string label, string action = "", string controller = "", bool passArgs = false)
        {
            Label = label;
            ControllerName = controller;
            ActionName = action;
            PassArguments = passArgs;
        }

        public BreadcrumbAttribute(Type resourceType, string resourceName, string action = "", string controller = "", bool passArgs = false)
        {
            Label = ResourceHelper.GetResourceLookup(resourceType, resourceName);
            ControllerName = controller;
            ActionName = action;
            PassArguments = passArgs;
        }

        public string Label { get; }
        public string ControllerName { get; }
        public string ActionName { get; }
        public bool PassArguments { get; }
    }
}