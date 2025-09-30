using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Model
{
    /// <summary>
    /// Class represents the RPN calculator 
    /// </summary>
    public class RPNCalculator
    {
        /// <summary>
        /// This method is used to call calculations and checks if the stack is empty before returning the result
        /// </summary>
        /// <param name="tokenStack">Stack of tokens</param>
        /// <returns>The value of the calculation</returns>
        public double PreCalc(ITokenStack tokenStack)
        {
            double result = Calculate(tokenStack).Number;

            if (tokenStack.Count() != 0)
            {
                throw new InvalidOperationException("InvalidOperationException");
            }

            return result;
        }

        /// <summary>
        /// Method that pops tokens and calculates the result
        /// </summary>
        /// <param name="tokenStack">Stack of tokens</param>
        /// <returns>A operand with the value of the result.</returns>
        public Operand Calculate(ITokenStack tokenStack)
        {
            //Exception, if stack is empty and we still try to calculate then throw.
            if (tokenStack.Count() == 0)
            {
                throw new InvalidOperationException("InvalidOperationException");
            }

            //Instance of class CalcMath used to nestle the calculation process
            RPNCalculator nestledLoop = new RPNCalculator();

            //First - Token which we currently use
            Token first = tokenStack.Pop();
            Operand result;

            
            switch (first)  
            {
                //Does not care of which specific subclass of operator that first consists of (polymorphism)
                //If "first" is a operator then call CalcMath method again to get the right and left operand
                case Operator:
                    Operand right = nestledLoop.Calculate(tokenStack);
                    Operand left = nestledLoop.Calculate(tokenStack);
                    result = ((Operator)first).OpCalc(right, left);
                    break;

                //If the poped token "first" is a operand then return it
                //Will become a left or right operand if this occurs in a nestled CalcMath call
                default:
                    result = (Operand)first;
                    break;
            }

            return result;
        }
    }
}
