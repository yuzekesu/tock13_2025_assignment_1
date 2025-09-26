using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorException
{
    public class InvalidTokenException : Exception
    {
        public string Token { get; }
        public InvalidTokenException(string token) : base($"Invalid token: {token}")
        {
            Token = token;
        }


        public void PutOutPut_InvalidToken()
        {
            Console.WriteLine($"InvalidTokenException: {Token}");
        }
    }
}
