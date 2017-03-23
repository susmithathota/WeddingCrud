using System;
using System.Collections.Generic;
using WeddingPlaner.Models;

namespace WeddingPlaner{
    public class RSVP:BaseEntity{
        public int RSVPId{get;set;}
        
        public int WeddingId{get;set;}
        public Wedding Wedding{get;set;}

        public int UserId{get;set;}
        public User User{get;set;}

        public DateTime CreatedAt{get;set;}

        public RSVP(){
            CreatedAt=DateTime.Now;
        }

    }
}