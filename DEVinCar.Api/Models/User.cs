namespace DEVinCar.Api.Models
{
    public class User
    {
        public int Id {get; internal set;}
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }

    }
}