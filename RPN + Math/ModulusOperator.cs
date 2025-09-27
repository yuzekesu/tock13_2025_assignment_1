using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator.Exceptions;
using DivideByZeroException = Calculator.Exceptions.DivideByZeroException;

namespace Calculator.Model
{
    internal class ModulusOperator : Operator
    {
        public ModulusOperator() { }

        public override Operand OpCalc(Operand right, Operand left)
        {
            if (right.Number == 0)
            {
                throw new DivideByZeroException(left.Number, right.Number);
            }

            return new Operand(left.Number % right.Number);
        }

        public override string ToString() => "%";
    }
}
