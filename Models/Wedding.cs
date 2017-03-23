
using System;
using System.Collections.Generic;
using WeddingPlaner.Models;

namespace WeddingPlaner{
    public class Wedding:BaseEntity{
        public int WeddingId{get;set;}
        public string Bride { get; set; }
        public string Groom { get; set; }
        public DateTime DateOfWedding { get; set; }
        public DateTime CreatedAt{get;set;}
        public int UserId{get;set;}
        public User User{get;set;}
        public List<RSVP> rsvps{get;set;}
        public Wedding(){
            CreatedAt=DateTime.Now;  
            rsvps=new List<RSVP>(); 
        }
    }

}