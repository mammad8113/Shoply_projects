using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_framwork.Applicatin
{
    public class PasswordResult
    {
        public bool IsSuccedded { get; set; }
        public string Message { get; set; }
        public string Code { get; set; }
        public long Id { get; set; }

        public PasswordResult Successs(string message, string code,long id)
        {
            IsSuccedded = true;
            Message = message;
            Code = code;
            Id = id;
            return this;
        }

        public PasswordResult Faild(string message)
        {
            IsSuccedded = false;
            Message = message;
            return this;
        }
    }
}
