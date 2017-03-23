
using System;
using System.Collections.Generic;
using WeddingPlaner.Models;

namespace WeddingPlaner{
    public class User:BaseEntity{
        public int UserId{get;set;}
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt{get;set;}

        public List<Wedding> Weddings {get;set;}
        
        public User(){
            CreatedAt=DateTime.Now;   
            Weddings=new List<Wedding>();
        }
    }

}