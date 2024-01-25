using Guild.Models;
using Guild.Models.Domain;
using Guild.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace Guild.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        private readonly IRegisterRepository _repo;
        public AdminController(IRegisterRepository repo) 
        {
            _repo = repo;
        }
       

        public IActionResult AdminPanel()
        {
            return View();
        }


        //This is the List page

        public IActionResult Users()
        {
            var workers = _repo.GetAll().ToList();
            return View("Users", workers);
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var worker = _repo.Get(x => x.Id == Id);

            if (worker != null)
            {
                var employeeData = new Update()
                {
                    Id = worker.Id,
                    Name = worker.Name,
                    Email = worker.Email,
                    Phone = worker.Phone,
                    Age = worker.Age,

                };
                return View(employeeData);
            }
            else
            {
                TempData["error"] = "Data Not Found";
                return RedirectToAction("Users");
            }
        }


        [HttpPost]

        public IActionResult Edit(Update update) {

            var worker = _repo.FindById(update.Id);

            if(ModelState.IsValid)
            {
                worker.Name = update.Name;
                worker.Age = update.Age;
                worker.Phone = update.Phone;
                worker.Email = update.Email;

                _repo.Update(worker);
                _repo.Save();
                return RedirectToAction("Users");
            }

            return View(update);
        
        }

        public IActionResult DeleteWorker(int Id)
        {
            try
            {
                var worker = _repo.FindById(Id);
                _repo.Delete(worker);
                _repo.Save();

                TempData["success"] = "Record Delted Successfully.";
                return RedirectToAction("Users");

            }

            catch (Exception) {

                TempData["error"] = "Record could not be deleted.";
                return RedirectToAction("Users");
            }
        }



    }
}
