﻿using _01_framwork.Applicatin.Email;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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

        public  void OnGet(CancellationToken cancellationToken)
        {
            var connection = HttpContext.Connection;
            var feature = HttpContext.Features;
           //await Test(2, cancellationToken);
        }

        //public async Task Test(int i, CancellationToken cancellationtoken)
        //{
        //    Thread.Sleep(100);
        //    while (true)
        //    {
        //        i++;
        //        var mesage = $"{i}";
                
        //        if (cancellationtoken.IsCancellationRequested)
        //        {
        //            RedirectToPage("./Index");
        //        }
        //    }
        //}
    }
}
