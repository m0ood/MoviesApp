using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MoviesApp.Filters
{
    public class ActorAgeFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var BirthDate = context.HttpContext.Request.Form["BirthDate"];
            var BirthDateDatetime = DateTime.Parse(BirthDate);
            var Date = DateTime.Now.Date;
            var Year = Math.Abs(BirthDateDatetime.Year - Date.Year);
            if (Year < 7 || Year > 99)
            {
                context.Result = new BadRequestResult();
            }
            base.OnActionExecuting(context);
        }
    }
}