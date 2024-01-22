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
                return RedirectToAction("Index",ex);
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
                return RedirectToAction("Index","Guild");
            }
        }

        [HttpPost]

        public IActionResult Edit(Update update)
        {
            try
            {
                var worker = _registerContext.FindById(update.Id);

                if (ModelState.IsValid)
                {
                    update.Name = worker.Name;
                    update.Email = worker.Email;
                    update.Phone = worker.Phone;
                    update.Age = worker.Age;
                  

                    _registerContext.Update(worker);
                    _registerContext.Save();
                    Console.WriteLine("Redirecting to Index");
                    return RedirectToAction("Index", "Guild");
                }
            }
            catch (Exception ex)
            {
                // Log the exception for debugging
                Console.WriteLine(ex.Message);
                throw; // Rethrow the exception if needed
            }
            return View(update);
            
        }
    }
}
