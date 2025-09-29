using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Model
{
    public interface ITokenStack
    {
        void Push(Token token);
        Token Pop();
        int Count();
    }
}
