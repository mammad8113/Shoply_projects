using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_framwork.Applicatin
{
    public class PayResult
    {
        public bool IsSuccedded { get; set; }
        public string Message { get; set; }
        public string IssueTrakingNo { get; set; }

        public PayResult Successs(string message, string issueTrakingNo)
        {
            IsSuccedded = true;
            Message = message;
            IssueTrakingNo = issueTrakingNo;
            return this;
        }

        public PayResult Faild(string message)
        {
            IsSuccedded = false;
            Message = message;
            return this;
        }
    }
}
