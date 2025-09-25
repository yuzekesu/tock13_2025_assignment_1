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
            else if (args.Length == 2)
            {
                RunFile(args[0], args[1]);
            }
        }
        private static void RunConsole()
        {
            bool running = true;
            while (running)
            {
                Console_IO.PutOutput_Prompt();
                IO.Status status = Console_IO.GetInput(out string user_input);
                switch (status)
                {
                    case IO.Status.VALID_INPUT:
                        RPNCalc rpn = new RPNCalc(user_input);
                        try
                        {
                            Console_IO.PutOutput_Result(CalcMath.PreCalc(rpn));
                        }
                        catch (Exception e) // change this when Exception_proj is finished
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case IO.Status.INVALID_INPUT:
                        Console.WriteLine($"InvalidTokenException: {user_input}");
                        break;
                    case IO.Status.EMPTY:
                        Console.WriteLine("The user exited the application");
                        running = false;
                        break;
                }
            }
        }
        private static void RunFile(string file_input, string file_output)
        {
            bool running = true;
            using (StreamReader sReader = File.OpenText(file_input))
            {
                using (StreamWriter sWriter = File.CreateText(file_output))
                {
                    while (running)
                    {
                        // no prompt for file IO
                        IO.Status status = File_IO.GetInput(sReader, out string user_input);
                        switch (status)
                        {
                            case IO.Status.VALID_INPUT:
                                RPNCalc rpn = new RPNCalc(user_input);
                                try
                                {
                                    File_IO.PutOutput_Result(sWriter, CalcMath.PreCalc(rpn));
                                }
                                catch (Exception e)
                                {
                                    sWriter.WriteLine(e.Message);
                                }
                                break;
                            case IO.Status.INVALID_INPUT:
                                sWriter.WriteLine($"InvalidTokenException: {user_input}");
                                break;
                            case IO.Status.EMPTY:
                                // nothing needs to be prompt here for file IO
                                running = false;
                                break;
                        }
                    }
                }
            }
        }
    }
}
