using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Model
{
    /// <summary>
    /// Interface for TokenStack which makes it easier to add a new implementation of the stack.
    /// </summary>
    public interface ITokenStack
    {
        void Push(Token token);
        Token Pop();
        int Count();
    }
}
