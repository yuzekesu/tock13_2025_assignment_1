using Calculator.Calculator;
using Calculator.Model;

// To build cross multiple projects:
// right-click the "Dependecies" in the solution explorer according to your project. Then choose "add references". 

namespace Calculator_Program
{
    internal class Calculator
    {
        private CalculatorController controller = new();
        static void Main(string[] args)
        {
            CalculatorController controller = new CalculatorController();
            CalculatorController.run(args, controller);
        }
    }
}
