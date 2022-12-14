using ChinookSystem.BLL;
using ChinookSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages
{
    public class IndexModel : PageModel
    {
        #region Private Variables and Constructor

        
        private readonly ILogger<IndexModel> _logger;
        private readonly AboutServices _aboutServices;

        public IndexModel(ILogger<IndexModel> logger, AboutServices aboutServices)
        {
            _logger = logger;
            _aboutServices = aboutServices;
        }
        #endregion

        #region Feedback and Error Handling
        
        [TempData]
        public string Feedback { get; set; }
        private bool HasFeedback => !string.IsNullOrWhiteSpace(Feedback);

        #endregion

        public void OnGet()
        {
            DbVersionInfo info = _aboutServices.GetDbVersion();
            if(info == null)
            {
                Feedback = "Version Unkown";

            }
            else
            {
                Feedback = $"Version: {info.Major}.{info.Minor}.{info.Build}" + $" Release date of {info.ReleaseDate.ToShortDateString()}";
            }
        }
    }
}