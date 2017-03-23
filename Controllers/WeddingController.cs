using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeddingPlaner.Models;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace WeddingPlaner.Controllers
{
    public class WeddingController : Controller
    {
       private WeddingPlannerContext _context;
        public WeddingController(WeddingPlannerContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("Weddings")]
        public IActionResult WeddingList(){

            ViewBag.RsvpError="";
            ViewBag.RsvpError=HttpContext.Session.GetString("RSVPError");
            int? userId=HttpContext.Session.GetInt32("UserId");
            User MyUser=_context.Users.SingleOrDefault(user => user.UserId==(int)userId);
            List<Wedding> weddingList= _context.Weddings
                                                .Include(wedd => wedd.rsvps)
                                                .ToList();
            List<RSVP> UserAsRsvp =_context.RSVPs.Where(rsvp => rsvp.UserId==userId).ToList();
            ViewBag.UserAsRsvp=UserAsRsvp;
            ViewBag.WeddingList=weddingList;
            ViewBag.MyUser=MyUser;
            return View("WeddingList");
        }
        [HttpGet]
        [Route("PlanWedding")]
        public IActionResult PlanWedding(){
            ViewBag.Errors=new List<string>();
            return View("WeddingForm");
        }

        [HttpPost]
        [Route("CreateWedding")]
        public IActionResult CreateWedding(WeddingViewModel model){
            int? userId=HttpContext.Session.GetInt32("UserId");
            if(ModelState.IsValid){
                Wedding newWedding= new Wedding{
                    Bride=model.Bride,
                    Groom=model.Groom,
                    DateOfWedding=model.DateOfWedding,
                    UserId=(int)userId
                };
                _context.Weddings.Add(newWedding);
                _context.SaveChanges();
                //
                return RedirectToAction("WeddingList");
            }
            ViewBag.Errors=ModelState.Values;
            return View("WeddingForm");
        }
        [HttpGet]
        [Route("WeddingDetail/{WeddingId}")]
        public IActionResult WeddingDetail(int WeddingId){
            Wedding WeddingInfo=_context.Weddings
                                        .Include(wedd => wedd.rsvps)
                                        .ThenInclude(user => user.User)
                                        .SingleOrDefault(wedd => wedd.WeddingId==WeddingId);
            ViewBag.WeddingInfo = WeddingInfo;
            return View("WeddingDetail");
        }
    }
}