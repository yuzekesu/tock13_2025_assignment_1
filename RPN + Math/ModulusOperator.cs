using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator.Exceptions;
using DivideByZeroException = Calculator.Exceptions.DivideByZeroException;

namespace Calculator.Model
{
    /// <summary>
    /// This class represents a modulus operator
    /// </summary>
    internal class ModulusOperator : Operator
    {
        /// <summary>
        /// Method that does modulus on two operands.
        /// Overrides the method OpCalc in class Operator
        /// </summary>
        /// <param name="right"> The right operand to the operator </param>
        /// <param name="left"> The left operand to the operator </param>
        /// <returns> A operator with the result of the operand </returns>
        public override Operand OpCalc(Operand right, Operand left)
        {
            if (right.Number == 0)
            {
                throw new DivideByZeroException(left.Number, right.Number);
            }

            return new Operand(left.Number % right.Number);
        }

        /// <summary>
        /// Method that returns modulus operator as a character
        /// </summary>
        /// <returns> The string form of a modulus operator </returns>
        public override string ToString() => "%";
    }
}
