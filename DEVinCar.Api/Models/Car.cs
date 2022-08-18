namespace DEVinCar.Api.Models
{
    public class Car
    {
        public int Id { get; internal set; }
        public string Name { get; set; }
        public decimal SuggestedPrice { get; set; }
        // de acordo com o gerente do projeto vicenzo foi incluso o mapeamento
        public virtual List<SaleCar> Sales { get; set; }
        public Car ()
        {
        }
        public Car(int id, string name, decimal suggestedPrice)
        {
            Id = id;
            Name = name;
            SuggestedPrice = suggestedPrice;
        }
    }
}
