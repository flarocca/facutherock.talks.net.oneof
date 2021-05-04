using FacuTheRock.Talks.Net.OneOf.API.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FacuTheRock.Talks.Net.OneOf.API.Filters
{
    public class InvalidUserNameBusinessExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is InvalidUserNameBusinessException)
            {
                context.Result = new BadRequestResult();
                context.ExceptionHandled = true;
            }
        }
    }
}
