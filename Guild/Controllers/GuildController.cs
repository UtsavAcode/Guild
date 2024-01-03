using Guild.Data;
using Guild.Models;
using Guild.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Guild.Controllers
{
    public class GuildController : Controller
    {
        private readonly ApplicationDbContext applicationDbContext;
        

        public GuildController(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {

            var employees = await applicationDbContext.Workers.ToListAsync();
            return View(employees);
        }




        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task <IActionResult> Register(Register reg)
        {
            var worker = new worker()
            {
                Name = reg.Name,
                Email = reg.Email,
                Age = reg.Age,
                Password = reg.Password,
                Phone = reg.Phone,

            };

            await applicationDbContext.Workers.AddAsync(worker);
            await applicationDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }


    }
}
