using AcountManagement.Application.Contracts.Acount;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

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

        public void OnGet([FromQuery(Name = "ReturnUrl")] string? ReturnUrl)
        {
            //string url = HttpContext.Request.Query["ReturnUrl"].ToString();
            if (ReturnUrl != null)
                HttpContext.Session.SetString("url", ReturnUrl);
        }

        public IActionResult OnPostLogin(Login command)
        {
            var result = acountApplication.Login(command);
            string url = HttpContext.Session.GetString("url");
       
            if (string.IsNullOrWhiteSpace(url))
                url = "./Index";

            if (result.IsSuccedded)
                HttpContext.Response.Redirect(url);

            LoginMessage = result.Message;
            return Page();
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
