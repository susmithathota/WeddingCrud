using System.ComponentModel.DataAnnotations;
using System;
namespace WeddingPlaner.Models
{
    public abstract class BaseEntity {}
    public class UserViewModel: BaseEntity
    {
        [Key]
        public int UserId{get;set;}

        [Required]
        [MinLength(3)]
        public string FirstName { get; set; }
        [Required]
        [MinLength(2)]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }
        public DateTime CreatedAt{get;set;}

    }
}