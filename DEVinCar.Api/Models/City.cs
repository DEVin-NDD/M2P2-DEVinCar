namespace DEVinCar.Api.Models
{
    public class City
    {
        
        public int Id { get; set; }
        public int StateId { get; set; }
        public string Name { get; set; }

        public City(int id, int stateId, string name)
        {
            Id = id;
            StateId = stateId;
            Name = name;
        }
    }
}
