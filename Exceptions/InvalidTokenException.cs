using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Exceptions
{
    public class InvalidTokenException : System.Exception
    {
        public string Token { get; }
        public InvalidTokenException(string token) : base($"InvalidTokenException:  {token}")
        {
            Token = token;
        }

    }
}
