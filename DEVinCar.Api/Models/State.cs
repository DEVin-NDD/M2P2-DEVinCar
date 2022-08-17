namespace DEVinCar.Api.Models {
    public class State {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Initials { get; set; }

        public List<City> Cities { get; set; }
    }
}
