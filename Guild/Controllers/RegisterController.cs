﻿using Guild.Models;
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


                    var existingUser = _registerContext.Get(w => w.Email == worker.Email);

                    if (existingUser != null)
                    {
                        var profile = new UserProfile() { 
                            
                            Address = worker.Address
                        };

                        _registerContext.Update(existingUser);
                        _registerContext.Save();

                        TempData["success"] = "The profile is created successfully.";
                        return RedirectToAction("Dashboard", "Guild");
                    }

                    else
                    {
                        TempData["error"] = "Sorry you need to Register first.";
                        return RedirectToAction("AddEmployee");
                    }


                  
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
    }
}
