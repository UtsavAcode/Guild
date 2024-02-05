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

            var users = _context.GetAll().ToList();
            var email = HttpContext.Session.GetString("LoginSession");

            if (email !=null)
            {
                ViewBag.MySession = email;

                var user = _context.Get(x => x.Email == email);

                if (user != null)
                {
                    var userProfile = new UserProfile()
                    {
                        ProfileImageUrl = user.ProfileImageUrl,
                        ProfileId = user.Id,

                        FirstName    = user.FirstName,
                        LastName = user.LastName,   
                        Age = user.Age,
                        Email = user.Email,
                        Phone = user.Phone,
                        Address = user.Address,
                    };

                    return View(userProfile);
                }
            }

            

            else
            {
                return RedirectToAction("Login");
            }
           
           
            return View(users);
        }
    }
}
