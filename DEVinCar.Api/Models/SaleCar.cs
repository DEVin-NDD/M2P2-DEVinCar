namespace DEVinCar.Api.Models
{
    public class SaleCar
    {
        public int Id { get; internal set; }
        public int SaleId { get; set; }
        public int CarId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Amount { get; set; }
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
