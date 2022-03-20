using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcountManagement.Application.Contracts.Acount
{
    public class ChangPassword
    {
        public long Id { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }
    }
}
