using FacuTheRock.Talks.Net.OneOf.API.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FacuTheRock.Talks.Net.OneOf.API.Filters
{
    public class UserAlreadyExistsBusinessExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is UserAlreadyExistsBusinessException)
            {
                context.Result = new ConflictResult();
                context.ExceptionHandled = true;
            }
        }
    }
}
