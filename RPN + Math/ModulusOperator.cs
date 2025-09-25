using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Model
{
    internal class ModulusOperator : Operator
    {
        public ModulusOperator() { }

        public override Operand OpCalc(Operand right, Operand left)
        {
            if (right.Number == 0)
            {
                throw new DivideByZeroException($"DivideByZeroException: {left.Number:f2}/{right.Number:f2}");
            }

            return new Operand(left.Number % right.Number);
        }

        public override string ToString() => "%";
    }
}
