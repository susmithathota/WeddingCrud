using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeddingPlaner.Models;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace WeddingPlaner.Controllers
{
    public class RSVPController : Controller
    {
       private WeddingPlannerContext _context;
        public RSVPController(WeddingPlannerContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("AddRSVP/{WeddindId}")]
        public IActionResult AddRsvp(int WeddindId){
            ViewBag.RsvpError="";
            int? userId= HttpContext.Session.GetInt32("UserId");
            RSVP checkUser = _context.RSVPs.SingleOrDefault(rsvp => rsvp.UserId ==(int)userId && rsvp.WeddingId==WeddindId);
            if(checkUser==null){
                RSVP newRsvp = new RSVP{
                UserId = (int)userId,
                WeddingId=WeddindId
                };
                _context.RSVPs.Add(newRsvp);
                _context.SaveChanges();
            }
            else{
                HttpContext.Session.SetString("RSVPError","Already Rsvp");
            }
             return RedirectToAction("WeddingList","Wedding");
        }
        [HttpGet]
        [Route("RemoveRSVP/{WeddingId}")]
        public IActionResult RemoveRsvp(int WeddingId){
            ViewBag.RsvpError="";
            int? userId= HttpContext.Session.GetInt32("UserId");
            RSVP UserToRemove=_context.RSVPs.SingleOrDefault(rsvp => rsvp.UserId ==(int)userId && rsvp.WeddingId==WeddingId);
            if(UserToRemove!=null){
                Console.WriteLine(UserToRemove);
                _context.RSVPs.Remove(UserToRemove);
                _context.SaveChanges();
            }
            else{
                HttpContext.Session.SetString("RSVPError","You are not an Rsvp");
            }
            return RedirectToAction("WeddingList","Wedding");
        }
    }

}