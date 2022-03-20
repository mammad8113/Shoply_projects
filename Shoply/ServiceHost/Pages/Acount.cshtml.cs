using AcountManagement.Application.Contracts.Acount;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
    public class AcountModel : PageModel
    {
        [TempData]
        public string LoginMessage { get; set; }
        [TempData]
        public string registerMessage { get; set; }
        private readonly IAcountApplication acountApplication;

        public AcountModel(IAcountApplication acountApplication)
        {
            this.acountApplication = acountApplication;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPostLogin(Login command)
        {
            var result = acountApplication.Login(command);
            if (result.IsSuccedded)
                return RedirectToPage("./Index");

            LoginMessage = result.Message;
            return RedirectToPage("/Acount");
        }

        public IActionResult OnGetLogout()
        {
            acountApplication.Logout();
            return RedirectToPage("/Index");
        }

        public IActionResult OnPostRegister(RegisterAcount command)
        {
            var result = acountApplication.Create(command);
            if (result.IsSuccedded)
                return RedirectToPage("./Index");

            registerMessage = result.Message;
            return Page();
        }

    }
}
