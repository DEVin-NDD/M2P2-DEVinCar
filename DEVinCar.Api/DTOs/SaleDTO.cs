using System.ComponentModel.DataAnnotations;

namespace DEVinCar.Api.DTOs
{
    public class SaleDTO
    {
        public int UserId { get; set; }//SellerId
        [Required(ErrorMessage = "The BuyerId is required.")]
        public int BuyerId { get; set; }
        public int SellerId { get; set; }
        public DateTime SaleDate { get; set; }
    }
}
