using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ASPDotNetCore5Template.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<HomeController> Logger;

        public UserController(ILogger<HomeController> logger)
        {
            Logger = logger;
        }

        [AllowAnonymous]
        public IActionResult SignedOut()
        {
            return View();
        }
    }
}
