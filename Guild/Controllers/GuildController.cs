using Guild.Models;
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
            List<Register> registerList = new List<Register>();

            return View();
        }
    }
}
