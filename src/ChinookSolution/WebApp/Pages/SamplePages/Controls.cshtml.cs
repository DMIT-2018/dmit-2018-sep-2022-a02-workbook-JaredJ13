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


        public void OnGet()
        {
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
    }
}
