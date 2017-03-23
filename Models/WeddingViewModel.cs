using System.ComponentModel.DataAnnotations;
using System;
namespace WeddingPlaner.Models
{
    
    public class WeddingViewModel: BaseEntity
    {
        [Key]
        public int WeddingId{get;set;}

        [Required]
        [MinLength(3)]
        public string Bride { get; set; }
        [Required]
        [MinLength(2)]
        public string Groom { get; set; }

        [Required(ErrorMessage = "Weddind Date required")]
        [DateRange()]
        public DateTime DateOfWedding{get;set;}
        
    }
    public class DateRangeAttribute : ValidationAttribute
    {
        private DateTime maxDate;

       public DateRangeAttribute()
        {
            maxDate = DateTime.Now;
        }

       protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                DateTime inputDate = (DateTime)value;
                if (inputDate < maxDate)
                {
                    return new ValidationResult("Enter Future Date");
                }
            
            }

           return ValidationResult.Success;
        }
    }
}