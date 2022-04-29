using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_framwork.Applicatin.TokenAuthorize
{
    public class TokenManagement : ITokenManagement
    {
        private readonly List<Token> tokens;
        public TokenManagement()
        {
            tokens = new List<Token>();
        }

        public bool Authorize(string Pwd)
        {
            if (string.IsNullOrWhiteSpace(Pwd) || Pwd.ToLower() != "shoply")
            {
                return false;
            }

            return true;
        }

        public Token NewToken()
        {
            var token = new Token
            {
                Value = Guid.NewGuid().ToString(),
                ExpierDate = DateTime.Now.AddMinutes(2),
            };
            tokens.Add(token);

            return token;
        }

        public bool VerifyToken(string token)
        {
            if (tokens.Any(x => x.Value == token && x.ExpierDate > DateTime.Now))
                return true;

            return false;
        }
    }
}
