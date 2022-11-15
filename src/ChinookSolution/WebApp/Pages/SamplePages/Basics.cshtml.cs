#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages.SamplePages
{
    public class BasicsModel : PageModel
    {
        // Pagemodel is basically an object, treat it like an object
        //  Data fields, Properties, Constructors, and Behaviours (aka methods)

        // Data fields
        public string MyName { get; set; }

        // Properties
        //  The annotation BindProperty ties a property in a PageModel class
        //     directly to a control in the content page
        //  Data is transfered between the two automatically
        //  On the content page, the control to use this property will have a 
        //      helper-tag called asp-for
        [BindProperty(SupportsGet = true)]
        public int? ID { get; set; } // must make nullable so we can save it on our page

        // The tempdata annotation stores data until it's read in another
        //      immediate request
        // This annotation attribute has two methods called Keep(string) and 
        //      Peek(string) (used on content page)
        // Keep in a dictionary (name/value pair)
        //      Useful to redirect when data is required for more than a single request
        //      Implemented by TempData providers using either cookies or session state
        // TempData is not bound to any particular control like a BindProperty
        [TempData]
        public string FeedBack { get; set; }

        public void OnGet()
        {
            // This executes in response to a get request from the browser
            // When the page is first accessed, the browser issues a get request
            // When the page is refreshed without a Post request, the browser issues a 
            //  Get request.
            // When the page is retrieved in response to a form's POST using RedirectToPage()
            // If not RedirectToPage() is used on the Post, there is not Get request issued.

            Random rnd = new Random();
            int oddEven = rnd.Next(0, 25);
            if(oddEven % 2 == 0)
            {
                MyName = $"Jared is even {oddEven}";
            }
            else
            {
                MyName = null;
            }
        }

        // Processing in response to a request from a form on a web page
        //  This request is referred to as a Post (method = "post") 

        // General post
        // A general post occurs when a asp-page-handler is not used.
        // The return datatype can be void, however, yours will normally encounter the datatype
        //  IActionResult
        // The IActionResult requires some type of request action
        //      on the return statement of the method OnPost()
        //Typical actions:
        // Page()
        //      : does not issue a OnGet request
        //      : Remains on the current page
        //      : A good action for form processing involving validation 
        //          and with the catch of a try/catch
        // RedirectToPage()
        //      : Does issue a OnGet request
        //      : is used to retain input values via the @Page and your BindPropety form 
        //          controls on your form on the content page
        
        public IActionResult OnPost()
        {
            // This line of code is used to cause a delay in processing so we can
            //  see on the network activities some type of simulated processing
            Thread.Sleep(2000);

            // Retrieve data via the Request Object
            // Request: web page to server
            // Response: server to web page
            string buttonValue = Request.Form["theButton"];
            FeedBack = $"Button pressed is {buttonValue} with numeric input of {ID}";
            //return Page(); // does not issue a onGet()
            return RedirectToPage(new {ID=ID}); // request for OnGet so our random number thing happens again
        }
    }
}
