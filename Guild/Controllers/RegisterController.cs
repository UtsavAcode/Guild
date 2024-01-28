using Guild.Models;
using Guild.Models.Domain;
using Guild.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;

using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

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
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Register model)
        {
            var user = _registerContext.Get(x=> x.Email == model.Email && x.Password == model.Password);

            if (user != null)
            {
                HttpContext.Session.SetString("LoginSession", user.Email);
                return RedirectToAction("Dashboard", "Guild");
            }

            else
            {
                TempData["error"] = "Login Failed.";
            }
            return View();
        }
      

        public IActionResult Logout()
        {
            if(HttpContext.Session.GetString("LoginSession") != null)
            {
                HttpContext.Session.Remove("LoginSession");
                return RedirectToAction("Index","Guild");

            }
            return View();
        }

        [HttpGet]
        public IActionResult Create(int? Id)
        {
            if (Id == null)
            {
                TempData["error"] = "Invalid user ID.";
            }
            var user = _registerContext.Get(x=> x.Id == Id);


            if (user != null)
            {
                var profileData = new UserProfile()
                {
                    ProfileId = user.Id,
                    Name = user.Name,
                    Email = user.Email,
                    Age = user.Age,
                    Phone = user.Phone,
                    Address = user.Address,
                };

                return View(profileData);

            }

            else
            {
                TempData["error"] = "Data not found.";
                return RedirectToAction("AddEmployee");
            }

            
           /* return View();*/
        
        
        }

        /*
                [HttpPost]
                public IActionResult Create(UserProfile profile)
                {
                    if (ModelState.IsValid)
                    {

                        var userId = profile.ProfileId;

                        var existingUser = _registerContext.Get(x => x.Id == userId);

                        if (existingUser != null)
                        {
                            existingUser.Address = profile.Address;
                            _registerContext.Add(existingUser);
                            _registerContext.Save();

                            TempData["success"] = "The profile is created successfully.";
                            return RedirectToAction("Dashboard", "Guild");
                        }


                        else
                        {
                            TempData["error"] = "Cannot create the profile.";
                            return RedirectToAction("Login");
                        }

                    }

                    TempData["error"] = "Invalid profile data.";
                    return RedirectToAction("Dashboard", "Guild");
                }

        */

        /*    [HttpPost]
            public IActionResult Create(UserProfile profile)
            {
                var user = _registerContext.FindById(profile.ProfileId);
                if(ModelState.IsValid)
                {
                    user.Address = profile.Address;
                    _registerContext.Update(user);
                    _registerContext.Save();

                    TempData["success"] = "The profile is created.";
                    return RedirectToAction("Dashboard", "Guild");
                }

                return View(profile);

            }*/


    }
}
