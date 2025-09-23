using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileIO_proj
{
    public class InvalidTokenException : Exception
    {
        public string Token { get; }
        public InvalidTokenException(string token) : base($"Invalid token: {token}")
        {
            Token = token;
        }
    }
}
