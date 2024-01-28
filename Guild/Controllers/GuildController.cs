using Guild.Models;
using Guild.Models.Domain;
using Guild.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

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

        [HttpGet]
        public IActionResult DashBoard()
        {
            var email = HttpContext.Session.GetString("LoginSession");

            if (email !=null)
            {
                ViewBag.MySession = email;

                var user = _context.Get(x => x.Email == email);

                if (user != null)
                {
                    var userProfile = new UserProfile()
                    {
                        ProfileId = user.Id,
                        Name    = user.Name,
                        Age = user.Age,
                        Email = user.Email,
                        Phone = user.Phone,
                    };

                    return View(userProfile);
                }
            }

            

            else
            {
                return RedirectToAction("Login");
            }
           
           
            return View();
        }
    }
}
