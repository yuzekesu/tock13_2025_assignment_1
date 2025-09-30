using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Model
{
    /// <summary>
    /// This class represents a multiplication operator
    /// </summary>
    internal class MultiplyOperator : Operator
    {
        /// <summary>
        /// Method that does multiplication on two operands.
        /// Overrides the method OpCalc in class Operator
        /// </summary>
        /// <param name="right">The right operand to the operator</param>
        /// <param name="left"><The left operand to the operator/param>
        /// <returns>A operator with the result of the operand</returns>
        public override Operand OpCalc(Operand right, Operand left)
        {
            return new Operand(left.Number * right.Number);
        }

        /// <summary>
        /// Method that returns multiplication operator as a character
        /// </summary>
        /// <returns>The string form of a multiplication operator</returns>
        public override string ToString() => "*";
    }
}
