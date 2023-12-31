﻿using Common.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
   
    [ApiExplorerSettings(IgnoreApi = true)]   
    public class ErrorController : ControllerBase
    {
        [Route("error")]
        public ErrorResponse Error()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var exception = context.Error; 
            var code = 500; 

            if (exception is INotFoundException) code = 404; 


            Response.StatusCode = code; 

            return new ErrorResponse {
                Code = code,
                Message = exception.Message
            }; 
        }
    }
}
