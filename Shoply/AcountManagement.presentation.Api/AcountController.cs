
using _01_framwork.Applicatin;
using _01_framwork.Applicatin.Sms;
using AcountManagement.Application.Contracts.Acount;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AcountManagement.presentation.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcountController : ControllerBase
    {
        private readonly IAcountApplication acountApplication;
        private readonly ISmsService smsService;

        public AcountController(IAcountApplication acountApplication,ISmsService smsService)
        {
            this.acountApplication = acountApplication;
            this.smsService = smsService;
        }
        [HttpGet()]
        public void CheckMobileAndGetCode()
        {

        }
        [HttpPost()]
        public PasswordResult CheckMobileAndGetCode(RegesterMobil command)
        {
            acountApplication.getPassword += smsService.OnGetPassword;
            return acountApplication.GetPassword(command);
        }
        [Route("ChangPassword")]
        [HttpPost()]
        public OperationResult ChangPassword(ChangPassword command)
        {
            var result = acountApplication.ChangPassword(command);
            return result;
        }
    }
}
