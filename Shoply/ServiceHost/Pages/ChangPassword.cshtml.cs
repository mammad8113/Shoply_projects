using _01_framwork.Applicatin.Sms;
using AcountManagement.Application.Contracts.Acount;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
    public class ChangPasswordModel : PageModel
    {
        [TempData]
        public string Message { get; set; }
        public long Id { get; set; }
        private readonly IAcountApplication acountApplication;

        public ChangPasswordModel(IAcountApplication acountApplication)
        {
            this.acountApplication = acountApplication;

        }
        public void OnGet(long id)
        {
            Id = id;
        }
        public IActionResult OnPost(ChangPassword command)
        {
            var result = acountApplication.ChangPassword(command);
            if (result.IsSuccedded)
                return RedirectToPage("/Acount");

            Message = result.Message;
            return Page();
        }
    }
}
