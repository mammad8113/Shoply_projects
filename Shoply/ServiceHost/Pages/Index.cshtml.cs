using _01_framwork.Applicatin.Email;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceHost.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IEmailService emailService;

        public IndexModel(IEmailService emailService)
        {
            this.emailService = emailService;
        }

        public void OnGet()
        {
            //emailService.SendEmail("salam", "salam salam", "nazarym175@gmail.com");
        }
    }
}
