using System.ComponentModel.DataAnnotations;

namespace DEVinCar.Api.DTOs
{
    public class AdressDTO
    {
        [Required(ErrorMessage = "The Street is required")]
        [MaxLength(150,ErrorMessage="Street name must be a maximum of 100 characters")]
        public string Street { get; set; }
        [Required(ErrorMessage = "The Cep is required")]
        [MaxLength(8,ErrorMessage="The CEP must have a maximum of 8 characters")]
        public string Cep { get; set; }
        [Required(ErrorMessage = "The Number is required")]
        public int Number { get; set; }
        [MaxLength(255,ErrorMessage="The Complement must have a maximum of 255 characters")]
        public string Complement { get; set; }

    }
}