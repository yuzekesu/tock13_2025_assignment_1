using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Model
{
    public class CalcMath
    {
        public static double PreCalc(RPNCalc r)
        {
            double result = Calculate(r).Number;

            if (r.stack.Count() != 0)
            {
                throw new InvalidOperationException("InvalidOperationException");
            }

            return result;
        }
        public static Operand Calculate(RPNCalc r)
        {
            
            if (r.stack.Count() == 0)
            {
                throw new InvalidOperationException("InvalidOperationException");
            }

            Token first = r.stack.Pop();
            Operand result;

            switch (first)  
            {
                //Does not care of which specific subclass of operator that first consists of (polymorphism)
                case Operator:
                    Operand right = CalcMath.Calculate(r);
                    Operand left = CalcMath.Calculate(r);
                    result = ((Operator)first).OpCalc(right, left);
                    break;

                default:
                    result = (Operand)first;
                    break;
            }

            return result;
        }
    }
}
