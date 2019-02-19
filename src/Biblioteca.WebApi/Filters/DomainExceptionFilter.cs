using System.Net;
using Biblioteca.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace Biblioteca.WebApi.Filters
{
    public class DomainExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (!(context.Exception is DomainException domainException)) return;
            var json = JsonConvert.SerializeObject(domainException.BusinessMessage);

            context.Result = new BadRequestObjectResult(json);
            context.HttpContext.Response.StatusCode = (int) HttpStatusCode.BadRequest;
        }
    }
}