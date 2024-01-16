using Guild.Data;
using Guild.Models.Domain;
using Guild.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Guild.Areas.Admin.Controllers
{

    [Area("Admin")]

    public class AdminController: Controller
    {
        private readonly IWorkerRepository applicationDbContext;

        public AdminController(IWorkerRepository applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public IActionResult AdminDash()
        {
            return View();
        }

        //USer Details Section.

        [HttpGet]
       
        public IActionResult RegisteredUser()
        {
            var workers = applicationDbContext.GetAll();
            return View(workers);
        }

        //This is for the edit section.

 
        public IActionResult Edit(int Id)
        {
            if (Id == null || Id==0)
            {
                return NotFound();
            }

            worker workers = applicationDbContext.GetById(Id);

            if (workers == null)
            {
                return NotFound();
            }
           // ViewData["routeInfo"] = ControllerContext.MyDisplayRouteInfo();

            return View(workers);
        }

        //THis is the delete section.

     
        public IActionResult Delete(int Id)
        {
            var worker = applicationDbContext.GetById(Id);
            if (worker !=null) {

                applicationDbContext.DeleteById(worker.Id);
                applicationDbContext.Save();
                return RedirectToAction("RegisteredUser");
            }

           
            return RedirectToAction("RegisteredUser");
        }

        public IActionResult Profile()
        {
            return View();
        }
    }
}//


