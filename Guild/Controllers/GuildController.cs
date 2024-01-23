using Guild.Models;
using Guild.Models.Domain;
using Guild.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;


namespace Guild.Controllers
{
    public class GuildController : Controller
    {

        private readonly IRegisterRepository _context;

        public GuildController(IRegisterRepository context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
           var workers = _context.GetAll().ToList(); 

            return View("Index",workers);
        }

        public IActionResult DashBoard()
        {
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                ViewBag.UserSession = HttpContext.Session.GetString("UserSession").ToString();
            }

            else
            {
                return RedirectToAction("Login");
            }
            return View();
        }
    }
}
