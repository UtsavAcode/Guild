using Guild.Data;
using Guild.Models;
using Guild.Models.Domain;
using Guild.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace Guild.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        private readonly IWorkerRepository _context;

        public AdminController(IWorkerRepository context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Users()
        {
            var workers = _context.GetAll();

            if (workers != null) {
                return View(workers);
            }
            return View();

        }

        public IActionResult Update(int Id)
        {
            var workers = _context.Get(w => w.Id == Id);

            if (workers != null) {
                var workerData = new Update()
                {

                    Id = workers.Id,
                    Name = workers.Name,
                    Email = workers.Email,
                    Phone = workers.Phone,
                    Age = workers.Age,
                    Password = workers.Password,
                };

                return View(workerData);
            }

            return RedirectToAction("Users");

        }


        [HttpPost]

        public IActionResult Update(Update model) {

            var workers = _context.FindById(model.Id);

            if (workers != null)
            {
                workers.Name = model.Name;
                workers.Email = model.Email;
                workers.Phone = model.Phone;
                workers.Age = model.Age;

                _context.Update(workers);
                _context.Save();

                return RedirectToAction("Users");
            }

            return View("Update", model);

        }

        

    }
}
