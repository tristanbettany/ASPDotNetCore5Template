using LegoSetManager.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace LegoSetManager.Controllers
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
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
    }
}
