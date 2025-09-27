using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Exceptions
{
    public class DivideByZeroException : System.Exception
    {
        public double Left { get; }
        public double Right { get; }
        public DivideByZeroException(double left, double right) : base($"DivideByZeroException: {left:f2}/{right:f2}") { 
            Left = left; 
            Right = right; 
        }

    }
}
