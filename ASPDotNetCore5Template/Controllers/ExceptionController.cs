using ASPDotNetCore5Template.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace ASPDotNetCore5Template.Controllers
{
    public class ExceptionController : Controller
    {
        private readonly ILogger<HomeController> Logger;

        public ExceptionController(ILogger<HomeController> logger)
        {
            Logger = logger;
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Index()
        {
            return View("Exception", new ErrorViewModel
            {
                Code = 500,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }

        [AllowAnonymous]
        [Route("/Exception/Code/{code:int}")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Code(int code)
        {
            return View("Exception", new ErrorViewModel
            {
                Code = code,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
    }
}
