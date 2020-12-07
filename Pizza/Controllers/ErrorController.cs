using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Pizza.Controllers
{
    public class ErrorController : Controller
    {
        [Route("/Error/{statusCode}")]
        public ActionResult Error(int statusCode)
        {
            ViewBag.Code = statusCode;
            return View();
        }

        [AllowAnonymous]
        [Route("/Exception")]
        public ActionResult Exception()
        {
            var exeptionDetails = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            ViewBag.ExceptionPath = exeptionDetails.Path;
            ViewBag.ExceptionMessage = exeptionDetails.Error.Message;
            ViewBag.Stacktrace = exeptionDetails.Error.StackTrace;

            return View();
        }
    }
}
