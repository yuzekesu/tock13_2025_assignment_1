using Calculator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Model
{
    internal class CalculatorController
    {
        RPNCalc rpn = new RPNCalc();
        CalcMath math = new CalcMath();


        public void Run()
        {
            string[] input = new string[2];
            input[0] = "3 4,8 5,7 + * 2,5 *";
            input[1] = "239 100 4 2 / 5 6 + * - %";

            for (int i = 0; i < input.Length; i++)
            {
                rpn.pushStack(input[i]);
                Console.WriteLine($"Result = {math.Calculate(rpn)}");
            }


        }
    }
}
