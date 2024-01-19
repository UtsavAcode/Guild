using Guild.Data;
using Guild.Models;
using Guild.Models.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Eventing.Reader;
using Microsoft.AspNetCore.Http;
using Guild.Repository.IRepository;
using Guild.Views.Guild;


namespace Guild.Controllers
{
    //Creating a constructor of the controller.
    public class GuildController : Controller
    {
        //Assigning a private field.
        private readonly IWorkerRepository _workerContext;
        private readonly IProfileRepository _profileContext;
  /*      private readonly IRegisterRepository _registerContext;*/


        public GuildController(IWorkerRepository applicationDbContext, IProfileRepository profileDbContext/*, IRegisterRepository registerDbContext*/)
        {
            this._workerContext = applicationDbContext;
            this._profileContext = profileDbContext;
           /* this._registerContext = registerDbContext;*/
        }



        // Index page.
        [HttpGet]
        public async Task<IActionResult> Index()
        {

            var workers = _workerContext.GetAll().ToList();

            if (HttpContext.Session.GetString("WorkerSession") != null)
            {
                return RedirectToAction("Dashboard");
            }
            return View();
        }




        //The register area is below.
        [HttpGet]
        public IActionResult Register()
        {
            //this line of code shows that this action method is returning a view result.
            //It typically renders HTML view associated with the action.
            return View();
        }

        [HttpPost]
        //Now we will use the HttpPost request to save the input data into the database.
        //We create a Register action method responsible for handling incoming http request.
        //Register() determines the route at which the method will be invoked.
        //Register inside Register(Register reg) action is the model we are using.
        //reg is the object of that model.

        public async Task<IActionResult> Register(Models.Register reg)
        {
            //ModelState.IsValid means that if there is no error validation in the form excute the code in the if statement.
            if (ModelState.IsValid)
            {

                var worker = new worker()
                {
                    Name = reg.Name,
                    Email = reg.Email,
                    Age = reg.Age,
                    Password = reg.Password,
                    Phone = reg.Phone,

                };


                _workerContext.Add(worker);
                _workerContext.Save();

                //clear the model state to reset the form 
                ModelState.Clear();

                return RedirectToAction("Login");


            }

            return View(reg);
        }
        //The register area ends here.



        //The login codes are below.

        //This is to display the login page.
        [HttpGet]
        public async Task<IActionResult> Login()
        {
            //Creating a statement to redirect to dashboard if session exist.

            if (HttpContext.Session.GetString("WorkerSession") != null)
            {
                return RedirectToAction("Dashboard");
            }

            return View();

        }

        //The codes below are used to handle the login scenario.

        [HttpPost]

        //The Login action method is using the Login model and the login object.
        //The data will be stored there and be compared to the data in the database and allowed login.
        public async Task<IActionResult> Login(Models.Login login)
        {

            //The myWorker variable is created to store the data that comes from the login form.
            //The data that comes from the login form is checked if it already exist in the table(dbSet) workers or not.
            // We create an x variable to represent the model and compare it with the incoming data login.UserEmail & UserPassword.
            // If both the condition match we use FirstOrDefault to store the entire row in myWorker.
            var myWorker = _workerContext.Get(x => x.Email == login.UserEmail && x.Password == login.UserPassword);

            //In the condition myWorker is not null.

            if (myWorker != null)
            {
                //creating a session and using HttpContext class using the namespace Http at the top.
                //Naming the session and storing the data from myWorker in the session.

                HttpContext.Session.SetString("WorkerSession", myWorker.Email);
                return RedirectToAction("Dashboard");
            }

            //Incase myWorker is null
            else
            {
                ViewBag.Message = "Login failed, Please use correct email and password.";
            }
            return View();
        }

        //Dashboard View.
        public IActionResult Dashboard()
        {
            //Accessing my session.
            //Creating a session.
            //If the session is not null.

            if (HttpContext.Session.GetString("WorkerSession") != null)
            {
                //Creating a viewBag message.

                ViewBag.MySession = HttpContext.Session.GetString("WorkerSession").ToString();
            }

            //If the session is null.
            else
            {
                //Redirect to Login in case the user directly wants to get to the dashboard without login.
                return RedirectToAction("Login");
            }
            ModelState.Clear();
            return View();
        }
        //Login section ends.


        //The logout section starts.

        public IActionResult Logout()
        {


            if (HttpContext.Session.GetString("WorkerSession") != null)
            {
                //Removing the session to Logout.
                HttpContext.Session.Remove("WorkerSession");

                //Redirecting to the Login view after removing the session indicating Logout.
                return RedirectToAction("Login");
            }
            return View();
        }

        //Create your user profiles.

        [HttpGet]
        public IActionResult Profile(int Id)
        {
            ViewBag.Id = Id;
            worker userData = _workerContext.FindById(Id);
            if (userData != null)
            {
                //Creating a profile model using the data from the register model.

                Models.Profile profileData = new Models.Profile
                {
                    WorkerId = userData.Id,
                    Name = userData.Name,
                    Email = userData.Email,
                    Phone = userData.Phone,
                    Age = userData.Age,

                };

                return View(profileData);
            }
            return View();
        }

            [HttpPost]

            public IActionResult Profile(Models.Profile model)
            {
                if (ModelState.IsValid)
                {
                    var User = new Models.Profile()
                    {
                        WorkerId = model.WorkerId,
                        Name = model.Name,
                        Age = model.Age,
                        Email = model.Email,
                        Password = model.Password,
                        Phone = model.Phone,
                        Address = model.Address,
                    };

                    _profileContext.Add(User);
                    _profileContext.Save();

                    return RedirectToAction("Index");
                }

            return View(model);
            }
        }
    }
