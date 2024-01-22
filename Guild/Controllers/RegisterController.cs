using Guild.Models;
using Guild.Models.Domain;
using Guild.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace Guild.Controllers
{
    public class RegisterController : Controller

    {
        private readonly IRegisterRepository _registerContext;
     
   
        public RegisterController(IRegisterRepository registerContext)
        {
            _registerContext = registerContext;
           
        }

        [HttpGet]
        public IActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddEmployee(Models.Register worker)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var register = new Worker()
                    {

                        Name = worker.Name,
                        Age = worker.Age,
                        Email = worker.Email,
                        Password = worker.Password,
                        Phone = worker.Phone,


                    };
                    _registerContext.Add(register);
                    _registerContext.Save();
                    TempData["Success"] = "Registered Successfully";
                    return RedirectToAction("Index","Guild");
                }
            }

            catch (Exception ex)
            {
                /*SetMessage($"Opps !! Cannot Add Data. {ex.Message}", "ErrorMessage");*/
                return RedirectToAction("Index");
            }
                
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var worker = _registerContext.Get(x => x.Id == Id);

            if(worker != null)
            {
                var employeeData = new Update()
                {
                    Id = worker.Id,
                    Name = worker.Name,
                    Email = worker.Email,
                    Phone = worker.Phone,
                    Age= worker.Age,
                    Password = worker.Password,
                };
                return View(employeeData);
            }
            else
            {
                TempData["error"] = "Data Not Found";
                return RedirectToAction("Index","Register");
            }
        }

        [HttpPost]
        public IActionResult Edit(Update update)
        {

            
         var worker = _registerContext.FindById(update.Id);

                if (ModelState.IsValid)
                {
                    worker.Name = update.Name;
                    worker.Email = update.Email;
                    worker.Phone = update.Phone;
                    worker.Age = update.Age;
                    worker.Password = update.Password;

                _registerContext.Update(worker);
                _registerContext.Save();
                return RedirectToAction("Index", "Guild");
                    }

                return View("Edit",update);
           
        }
    }
}
