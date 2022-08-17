using System.ComponentModel.DataAnnotations;

namespace DEVinCar.Api.DTOs
{
     public class City
    {     
        [Required(ErrorMessage = "The name is required")]
        [MaxLength(50)]  
        public string Name { get; set; }
       
    }
}