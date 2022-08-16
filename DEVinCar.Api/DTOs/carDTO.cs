using System.ComponentModel.DataAnnotations;

namespace DEVinCar.Api.DTOs{
    public class carDTO{
        [Required(ErrorMessage = "The name is required")]
        [MaxLength(255)]
        public string Name { get; set; }
        public decimal SuggestedPrice { get; set; }

    }
}


