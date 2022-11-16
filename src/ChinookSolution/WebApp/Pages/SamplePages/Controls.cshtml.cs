#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages.SamplePages
{
    public class ControlsModel : PageModel
    {
        [TempData]
        public string FeedBack { get; set; }

        [BindProperty]
        public string EmailText { get; set; }

        [BindProperty]
        public string PasswordText { get; set; }

        [BindProperty]
        public DateTime DateText { get; set; } = DateTime.Now;

        [BindProperty]
        public TimeSpan TimeText { get; set; } = DateTime.Now.TimeOfDay;

        [BindProperty]
        public string Meal { get; set; }

        // Were assuming this array is actually data retrieved from the database
        public string[] Meals { get; set; } = new[] { "breakfast", "lunch", "dinner", "snacks" };

        [BindProperty]
        public bool AcceptanceBox { get; set; }

        [BindProperty]
        public string MessageBody { get; set; }

        [BindProperty]
        public int MyRide { get; set; }

        // Pretend that the following collection is data from a database
        //  the collection is based on a two property class called SelectionList
        //  the data for the list will be created in a seperate method
        public List <SelectionList> Rides { get; set; }

        [BindProperty]
        public string VacationSpot { get; set; }

        public List<string> VacationSpots { get; set; }

        [BindProperty]
        public int ReviewRating { get; set; }

        public void OnGet()
        {
            PopulateList();
            
        }

        private void PopulateList()
        {
            // Create a pretend collection from the database representing different types of 
            //      transportation (rides)
            Rides = new List<SelectionList>();
            Rides.Add(new SelectionList() { ValueID = 1, DisplayText = "Car" });
            Rides.Add(new SelectionList() { ValueID = 2, DisplayText = "Bus" });
            Rides.Add(new SelectionList() { ValueID = 3, DisplayText = "Bike" });
            Rides.Add(new SelectionList() { ValueID = 4, DisplayText = "Motorcycle" });
            Rides.Add(new SelectionList() { ValueID = 5, DisplayText = "Plane" });

            Rides.Sort((x,y) => x.DisplayText.CompareTo(y.DisplayText));

            VacationSpots = new List<string>();
            VacationSpots.Add("California");
            VacationSpots.Add("Caribbean");
            VacationSpots.Add("Cruising");
            VacationSpots.Add("Europe");
            VacationSpots.Add("Manitoba");
            VacationSpots.Add("Florida");
        }

        public IActionResult OnPostTextBox()
        {
            FeedBack = $"Email {EmailText}; Password {PasswordText}; Date {DateText}; Time {TimeText}";
            return Page();
        }

        public IActionResult OnPostRadioCheckArea()
        {
            FeedBack = $"Meal {Meal}; Acceptance {AcceptanceBox}; Message {MessageBody}";
            return Page();
        }

        public IActionResult OnPostListSlider()
        {
            FeedBack = $"Ride {MyRide}; Vacation {VacationSpot}; Review Rating {ReviewRating}";
            PopulateList(); // to repopulate our list again because the page won't remember our data
            return Page();
        }
    }
}
