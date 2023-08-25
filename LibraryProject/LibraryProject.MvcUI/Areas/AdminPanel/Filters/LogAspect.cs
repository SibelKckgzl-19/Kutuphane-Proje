using Microsoft.AspNetCore.Mvc.Filters;

namespace LibraryProject.MvcUI.Areas.AdminPanel.Filters
{
    public class LogAspect:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            
        }

        public override void OnResultExecuting(ResultExecutingContext context)
        {
            
        }
    }
}
