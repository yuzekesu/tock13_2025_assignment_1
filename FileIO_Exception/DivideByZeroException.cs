using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileIO_proj
{
    public class DivideByZeroException : Exception
    {
        public double Left { get; }
        public double Right { get; }
        public DivideByZeroException(double left, double right) : base("Attempted to divide by zero.") { 
            Left = left; 
            Right = right; 
        }

    }
}
