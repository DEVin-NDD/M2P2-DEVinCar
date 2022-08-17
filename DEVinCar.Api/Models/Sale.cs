namespace DEVinCar.Api.Models
{
    public class Sale
    {

        public int Id { get; internal set; }
        public int BuyerId { get; set; }
        public int SellerId { get; set; }
        public DateTime SaleDate { get; set; }
        public Sale()
        {
        }

        public Sale(int buyerId, int sellerId, DateTime saleDate)
        {
            BuyerId = buyerId;
            SellerId = sellerId;
            SaleDate = saleDate;
        }
    }
}