using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Model
{
    public class RPNCalculator
    {
        //PreCalc used to check if there is still some Operands/Operatons inside stack before we return the result
        public double PreCalc(TokenStack r)
        {

            double result = Calculate(r).Number;

            if (r.stack.Count() != 0)
            {
                throw new InvalidOperationException("InvalidOperationException");
            }

            return result;
        }
        public Operand Calculate(TokenStack r)
        {
            //Exception, if stack is empty and we still try to calculate then throw.
            if (r.stack.Count() == 0)
            {
                throw new InvalidOperationException("InvalidOperationException");
            }

            //Instance of class CalcMath used to nestle the calculation process
            RPNCalculator nestledLoop = new RPNCalculator();

            //First - Token which we currently use
            Token first = r.stack.Pop();
            Operand result;

            
            switch (first)  
            {
                //Does not care of which specific subclass of operator that first consists of (polymorphism)
                //If "first" is a operator then call CalcMath method again to get the right and left operand
                case Operator:
                    Operand right = nestledLoop.Calculate(r);
                    Operand left = nestledLoop.Calculate(r);
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
