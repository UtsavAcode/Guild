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
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Worker worker)
        {
         
                var register = new Register()
                {

                    Name = worker.Name,
                    Age = worker.Age,
                    Email = worker.Email,
                    Password = worker.Password,
                    Phone = worker.Phone,

                    
                };

                if (register != null)
                {
                    _registerContext.Add(register);
                    _registerContext.Save();
                return RedirectToAction("Index");
            }

                
            return View();
        }
    }
}
