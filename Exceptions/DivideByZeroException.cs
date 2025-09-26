using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions_proj
{
    public class DivideByZeroException : Exception
    {
        public double Left { get; }
        public double Right { get; }
        public DivideByZeroException(double left, double right) : base("DivideByZeroException: ") { 
            Left = left; 
            Right = right; 
        }

    }
}
