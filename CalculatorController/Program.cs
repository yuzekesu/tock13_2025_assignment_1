using Calculator.Calculator;

namespace CalculatorController_Program
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CalculatorController controller = new CalculatorController();
            Console.WriteLine("Debugging CalculatorController:");
            foreach (var current in args.Select((word, offset) => new { word, offset }))
            {
                Console.WriteLine(current);
            }
            CalculatorController.Run(args, controller);
        }
    }
}
