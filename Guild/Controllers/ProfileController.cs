using Guild.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace Guild.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IRegisterRepository _profileContext;

        public ProfileController(IRegisterRepository profileContext)
        {
            _profileContext = profileContext;
        }

        [HttpGet]
        public IActionResult Profile(int Id)
        {
            var worker = _profileContext.Get(x => x.Id == Id);

            if (worker != null)
            {
                var info = new Models.Profile() {

                    ProfileId = worker.Id,
                    Name = worker.Name,
                    Age = worker.Age,
                    Email = worker.Email,
                    Phone = worker.Phone,

                };

                return View(info);
            }

            else
            {
                TempData["error"] = "The data is not available";
                return RedirectToAction("Profile");
            }
        }

        [HttpPost]
        public IActionResult Profile(Models.Profile model)
        {
           var user = _profileContext.FindById(model.ProfileId);

            if (User !=null)
            {
                user.Name = model.Name;
                user.Age = model.Age;
                user.Email = model.Email;
                user.Phone = model.Phone;
                    

            _profileContext.Update(user);
           
          
            }

            else
            {
                var newUser = new Models.Profile() {


                    Name = model.Name,
                    Age = model.Age,
                    Email = model.Email,
                    Phone = model.Phone,
                    // Assuming these properties exist in your Register model
                    Address = model.Address,
                    Occupation = model.Occupation
                };

                _profileContext.Add(newUser);
            }
        }
    }
}
