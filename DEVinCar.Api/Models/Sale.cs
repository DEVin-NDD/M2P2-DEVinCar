namespace DEVinCar.Api.Models
{
    public class Sale
    {

        public int Id { get; internal set; }
        public int BuyerldId { get; set; }
        public int SellerId { get; set; }
        public DateTime SaleDate { get; set; }
        public Sale()
        {
        }

        public Sale(int buyerldId, int sellerId, DateTime saleDate)
        {
            BuyerldId = buyerldId;
            SellerId = sellerId;
            SaleDate = saleDate;
        }
    }
}