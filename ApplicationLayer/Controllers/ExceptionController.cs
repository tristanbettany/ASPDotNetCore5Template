using ApplicationLayer.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace ApplicationLayer.Controllers
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
            return View("Exception", new ExceptionViewModel
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
            return View("Exception", new ExceptionViewModel
            {
                Code = code,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
    }
}
