using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeddingPlaner.Models;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace WeddingPlaner.Controllers
{
    public class UserController : Controller
    {
       private WeddingPlannerContext _context;
        public UserController(WeddingPlannerContext context)
        {
            _context = context;
        }
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.RegisterErrors=new List<string>();
            ViewBag.LoginErrors= "";
            return View();
        }

        [HttpPost]
        [Route("Register")]
        public IActionResult Register(UserViewModel model){
            if(ModelState.IsValid){
                User newUser=new User{
                    FirstName=model.FirstName,
                    LastName=model.LastName,
                    Email=model.Email,
                    Password=model.Password
                };
                _context.Users.Add(newUser);
                _context.SaveChanges();

                User MyUser= _context.Users.SingleOrDefault(user => user.Email==model.Email);
                HttpContext.Session.SetInt32("UserId",(int)MyUser.UserId);
                return RedirectToAction("WeddingList","Wedding");    
            }
            else{
                ViewBag.RegisterErrors= ModelState.Values;
                return View("Index");
            } 
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult newLogin(string email,string password ){
            ViewBag.RegisterErrors=new List<string>();
            ViewBag.LoginErrors= "";
            User MyUser = _context.Users.SingleOrDefault(user => user.Email == email);
            if(MyUser!=null || password!=null){
                if((string)MyUser.Password==password){
                    HttpContext.Session.SetInt32("UserId",(int)MyUser.UserId);
                     return RedirectToAction("WeddingList","Wedding");
                }  
               
            }
            ViewBag.LoginErrors = "Invalid Combination";
            return View("Index"); 
        }
      
    }
}
