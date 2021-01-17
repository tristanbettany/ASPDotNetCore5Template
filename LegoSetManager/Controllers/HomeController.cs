using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LegoSetManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> Logger;

        public HomeController(ILogger<HomeController> logger)
        {
            Logger = logger;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize("Developers")]
        public IActionResult Protected()
        {
            return View();
        }
    }
}
