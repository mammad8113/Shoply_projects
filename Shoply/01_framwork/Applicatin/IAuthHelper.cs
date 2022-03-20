using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_framwork.Applicatin
{
    public interface IAuthHelper
    {
        void SignOut();
        void Signin(AuthViewModel command);
        bool IsAuthenticated();
        string CurrentAccountRole();
        long CurrentAccountId();
    }
}
