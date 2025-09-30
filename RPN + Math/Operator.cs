using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Model
{
    /// <summary>
    /// This clas represnts an Operator
    /// </summary>
    public abstract class Operator : Token
    {
        /// <summary>
        /// Abstract mehtod that calculates a operator
        /// </summary>
        /// <param name="right">Right operand of the operator</param>
        /// <param name="left">Left operand of the operator</param>
        /// <returns>A operand</returns>
        public abstract Operand OpCalc(Operand right, Operand left);
    }

}
