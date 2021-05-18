using FacuTheRock.Talks.Net.OneOf.API.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FacuTheRock.Talks.Net.OneOf.API.Filters
{
    #region Pros & Cons

    /* ****************************************
     * Pros:
     *   - Mecanismo provisto por el framework
     *   - Single Responsibility Principle
     *   - Solución conocida
     * 
     * Cons:
     *   - Reglas de negocio en la API
     *   - No es claro
     *   - Reglas de negocio como excepciones
     * 
     * ****************************************/

    #endregion

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
