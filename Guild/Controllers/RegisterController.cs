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
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Register worker)
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
                     return RedirectToAction("Index");
            

                
            /*return View();*/
        }
    }
}
