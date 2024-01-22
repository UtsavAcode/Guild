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
    }
}
