using Guild.Models;
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
        public IActionResult Register(Register register)
        {
            if (register != null)
            {
                var worker = new Models.Register()
                {

                    Name = register.Name,
                    Age = register.Age,
                    Email = register.Email,
                    Password = register.Password,
                    Phone = register.Phone,

                    
                };
                _registerContext.Add(worker);
                _registerContext.Save();

                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
