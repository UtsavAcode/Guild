using Guild.Data;
using Guild.Models;
using Guild.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Eventing.Reader;

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

            var workers = await applicationDbContext.Workers.ToListAsync();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
            
        }



        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(Register reg)
        {

            


            if (ModelState.IsValid)
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
                return RedirectToAction("Login");


            }

            return View(reg);
        }
        


    }
}
