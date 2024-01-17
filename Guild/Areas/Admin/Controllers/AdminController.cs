using Guild.Data;
using Guild.Models;
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

        [HttpGet]
        public IActionResult Edit(int Id)
        {
           var workers = applicationDbContext.GetById(Id);

            if (workers != null)
            {
                var viewModel = new worker()
                {

                    Id = workers.Id,
                    Name = workers.Name,
                    Email = workers.Email,
                    Age = workers.Age,
                    Password = workers.Password,
                    Phone = workers.Phone,
                };

                return View("Edit",viewModel);

            }
            return RedirectToAction("RegisteredUser");
        }

        //THis is the section that handles the changes made in the update.
        [HttpPost]
        public IActionResult Update(worker obj)
        {

            var existingWorker = applicationDbContext.GetById(obj.Id);

            if (existingWorker != null)
            {
                existingWorker.Name = obj.Name;
                existingWorker.Email = obj.Email;
                existingWorker.Password = obj.Password;
                existingWorker.Phone = obj.Phone;
                existingWorker.Age = obj.Age;

                applicationDbContext.Update(existingWorker);
                return RedirectToAction("RegisteredUser");
            }

            return RedirectToAction("AdminDash");
        }
        //THis is the delete section.


        /*  public IActionResult Delete(int Id)
          {
              var worker = applicationDbContext.GetById(Id);
              if (worker !=null) {

                  applicationDbContext.DeleteById(worker.Id);
                  applicationDbContext.Save();
                  return RedirectToAction("RegisteredUser");
              }


              return RedirectToAction("RegisteredUser");
          }*/

        public IActionResult Delete(int Id)
        {
            applicationDbContext.DeleteById(Id);
            return ViewBag.Message("Somethig wrong.");
        }

    }
}//


