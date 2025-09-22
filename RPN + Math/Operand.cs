using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Model
{
    public class Operand : Token
    {
        private double number;

        public double Number
        {
            get { return number; }
            set { number = value; }
        }

        public Operand(double value)
        {
            this.number = value;
        }

        public override string ToString()
        {
            return Number.ToString();
        }
    }
}   
