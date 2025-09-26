using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Model
{
    public class Operand : Token
    {
        public double Number
        {
            get; set;
        }

        public Operand(double value)
        {
            Number = value;
        }

        public override string ToString()
        {
            return Number.ToString();
        }
    }
}   
