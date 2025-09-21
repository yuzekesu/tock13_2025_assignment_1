using Calculator.Model;

// To build cross multiple projects:
// right-click the "Dependecies" in the solution explorer according to your project. Then choose "add references". 

namespace Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Calculator.Model.RPNCalc rpn = new RPNCalc();
            Calculator.Model.CalcMath math = new CalcMath();

            string[] input = new string[2];
            input[0] = "3 4,8 5,7 + * W *";
            input[1] = "239 100 4 2 / 5 6 + * - %";

            for (int i = 0; i < input.Length; i++)
            {
                rpn.pushStack(input[i]);
                Console.WriteLine($"Result = {math.Calculate(rpn)}");
            }
        }
    }
}
