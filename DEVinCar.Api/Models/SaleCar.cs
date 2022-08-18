namespace DEVinCar.Api.Models
{
    public class SaleCar
    {
        public int Id { get; internal set; }
        public decimal UnitPrice { get; set; }
        public int Amount { get; set; }
        public int CarId { get; set; }
        public int SaleId { get; set; }
        public virtual Car Car { get; set; }
        public virtual Sale Sale { get; set; }
        public SaleCar()

        {
        }

        public SaleCar(int saleId, int carId, decimal unitPrice, int amount)
        {
            SaleId = saleId;
            CarId = carId;
            UnitPrice = unitPrice;
            Amount = amount;
        }
    }
}
