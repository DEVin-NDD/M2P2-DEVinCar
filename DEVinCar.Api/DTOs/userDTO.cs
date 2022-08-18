using System.ComponentModel.DataAnnotations;

namespace DEVinCar.Api.DTOs{
    public class UserDTO{
        [Required(ErrorMessage = "The name is required")]
        [MaxLength(255)]
        public string Name { get; set; }
        [Required(ErrorMessage = "The email is required")]
        [MaxLength(150)]
        public string Email { get; set; }
        [Required(ErrorMessage = "The password is required")]
        [MaxLength(50)]
        [MinLength(4, ErrorMessage = "The password must contain at least 4 digits")]
        public string Password { get; set; }
        public DateTime BirthDate { get; set; }
      
    }
}