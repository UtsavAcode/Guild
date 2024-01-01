using Microsoft.AspNetCore.Mvc;

namespace Guild.Controllers
{
    public class GuildController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
