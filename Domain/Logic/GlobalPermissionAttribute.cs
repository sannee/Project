using System.Web.Mvc;

namespace Domain.Logic
{
    public class GlobalPermissionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string actionName = filterContext.ActionDescriptor.ActionName;
            string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;           
          
            if (controllerName != "Error")
            {
                bool access = PermissionManager.ValidatePermissions(controllerName, actionName, filterContext);

                if (!access)
                {
                    filterContext.HttpContext.Response.Redirect("/Error");
                }
            }
            base.OnActionExecuting(filterContext);
        }
    }
}
       

