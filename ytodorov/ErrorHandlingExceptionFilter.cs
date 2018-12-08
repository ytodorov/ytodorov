using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ytodorov
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Microsoft.Extensions.DependencyInjection;
    using Newtonsoft.Json;
    using System;
    using System.Net;


    public class ErrorHandlingExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext exceptionContext)
        {
            HttpContext context = exceptionContext.HttpContext;
            Exception exception = exceptionContext.Exception;   

            JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                MaxDepth = 3
            };

            // System.OutOfMemoryException: 'Insufficient memory to continue the execution of the program.'
            //string json =  JsonConvert.SerializeObject(exception, jsonSerializerSettings);

            string json = $"{exception.StackTrace} {exception?.InnerException?.StackTrace} {exception?.InnerException?.InnerException?.StackTrace}";

         

            HttpStatusCode code = HttpStatusCode.InternalServerError; // 500 if unexpected

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
           
        }
    }
}
    


