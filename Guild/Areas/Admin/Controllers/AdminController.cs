using Guild.Data;
using Guild.Models.Domain;
using Guild.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Guild.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Route("Admin")]
    public class AdminController: Controller
    {
        private readonly IWorkerRepository applicationDbContext;

        public AdminController(IWorkerRepository applicationDbContext)
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
        public IActionResult RegisteredUser()
        {
            var workers = applicationDbContext.GetAll();
            return View("~/Areas/Admin/Views/Admin/RegisteredUser.cshtml", workers);
        }

        //This is for the edit section.

        [Route("Edit")]
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
            return View("~/Areas/Admin/Views/Admin/Edit.cshtml", workers);
        }

        //THis is the delete section.

        [Route("Delete")]
        public IActionResult Delete(int Id)
        {
            var worker = applicationDbContext.GetById(Id);
            if (worker == null) { 
            
            return NotFound();
            }

            applicationDbContext.DeleteById(worker.Id);
            return View();
        }
    }
}//


