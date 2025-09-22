using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Model
{
    internal class SumOperator : Operator
    {
        public SumOperator() { }

        public override Operand OpCalc(Operand right, Operand left)
        {
            return new Operand(left.Number + right.Number);
        }

        public override string ToString() => "+";
    }
}
