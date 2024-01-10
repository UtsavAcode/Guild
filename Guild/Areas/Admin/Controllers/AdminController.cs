using Guild.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Guild.Areas.Admin.Controllers
{

    [Area("admin")]
    [Route("admin")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext applicationDbContext;

        public AdminController(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public IActionResult Index()
        {
            return View("~/Areas/Admin/Views/Admin/AdminDash.cshtml");
        }

        //USer Details Section.

        [HttpGet]
        [Route("RegisteredUser")]
        public async Task <IActionResult> RegisteredUser()
        {
            var workers = await applicationDbContext.Workers.ToListAsync();
            return View("~/Areas/Admin/Views/Admin/AdminDash.cshtml", workers);
        }
    }
}


