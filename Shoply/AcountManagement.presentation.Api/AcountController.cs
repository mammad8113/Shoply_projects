
using _01_framwork.Applicatin;
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

        public AcountController(IAcountApplication acountApplication)
        {
            this.acountApplication = acountApplication;
        }
        [HttpGet()]
        public void CheckMobileAndGetCode()
        {

        }
        [HttpPost()]
        public PasswordResult CheckMobileAndGetCode(RegesterMobil command)
        {
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
