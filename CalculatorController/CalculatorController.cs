using Calculator.View;
using Calculator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Calculator
{
    public class CalculatorController
    {
        public static void run(string[] args)
        {
            if (args.Length == 0)
            {
                RunConsole();
            }
            else
            {
                ; // file IO
            }
        }
        private static void RunConsole()
        {
            bool running = true;
            while (running)
            {
                Console_IO.PutOutput_Prompt();
                Console_IO.Status status = Console_IO.GetInput(out string user_input);
                switch (status)
                {
                    case Console_IO.Status.VALID_INPUT:
                        RPNCalc rpn = new RPNCalc();
                        CalcMath math = new CalcMath();
                        rpn.pushStack(user_input);
                        Console_IO.PutOutput_Result(math.Calculate(rpn));
                        break;
                    case Console_IO.Status.INVALID_INPUT:
                        Console.WriteLine($"InvalidTokenException: {user_input}");
                        break;
                    case Console_IO.Status.EMPTY:
                        Console.WriteLine("The user exited the application");
                        running = false;
                        break;
                }
            }
        }
    }
}
