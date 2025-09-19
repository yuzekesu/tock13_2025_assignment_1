using Calculator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Model
{
    internal class Calculator
    {
        static void Main(string[] args)
        {
            CalculatorController controller = new CalculatorController();

            controller.Run();


        }
    }
}
