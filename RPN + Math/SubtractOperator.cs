using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Model
{
    /// <summary>
    /// This class represents a division operator
    /// </summary>
    internal class SubtractOperator : Operator
    {
        /// <summary>
        /// Method that does subtraction on two operands.
        /// Overrides the method OpCalc in class Operator
        /// </summary>
        /// <param name="right">The right operand to the operator</param>
        /// <param name="left"><The left operand to the operator/param>
        /// <returns>A operator with the result of the operand</returns>
        public override Operand OpCalc(Operand right, Operand left)
        {
            return new Operand(left.Number - right.Number);
        }

        /// <summary>
        /// Method that returns subtraction operator as a character
        /// </summary>
        /// <returns>The string form of a subtraction operator</returns>
        public override string ToString() => "-";
    }
}
