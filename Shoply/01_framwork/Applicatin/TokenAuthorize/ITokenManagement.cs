using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_framwork.Applicatin.TokenAuthorize
{
    public interface ITokenManagement
    {
        public bool Authorize(string Pwd);
        Token NewToken();
        bool VerifyToken(string token);
    }
}
