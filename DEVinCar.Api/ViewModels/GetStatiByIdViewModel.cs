namespace DEVinCar.Api.ViewModels
{
    public class GetStatiByIdViewModel
    {
        public int StatiId { get; set; }
        public string StatiName { get; set; }
        public string StatiInitials { get; set; }

        public GetStatiByIdViewModel(int id, string name, string initials)
        {
            StatiId = id;
            StatiName = name;
            StatiInitials = initials;
        }

    }
}
