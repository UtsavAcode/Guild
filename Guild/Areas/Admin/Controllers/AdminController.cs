using Microsoft.AspNetCore.Mvc;

namespace Guild.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Areas/Admin/Views/Admin/AdminDash.cshtml");
        }
    }
}
