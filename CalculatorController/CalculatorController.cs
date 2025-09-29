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
        // attributs
        private Console_IO consoleIO = new();
        private File_IO fileIO = new();
        private RPNCalculator Calculator = new();
        // methods
        public static void run(string[] args, CalculatorController controller)
        {
            if (args.Length == 0)
            {
                controller.RunConsole();
            }
            else if (args.Length == 2)
            {
                controller.RunFile(args[0], args[1]);
            }
        }
        private void RunConsole()
        {
            bool running = true;
            while (running)
            {
                consoleIO.PutOutput_Prompt();
                IO.Status status = consoleIO.GetInput(out string user_input);
                switch (status)
                {
                    case IO.Status.VALID_INPUT:
                        ITokenStack rpn = new TokenStack(user_input);
                        try
                        {
                            consoleIO.PutOutput_Result(Calculator.PreCalc(rpn));
                        }
                        catch (Exception e) // change this when Exception_proj is finished
                        {
                            consoleIO.PutOutput_Exception(e);
                        }
                        break;
                    case IO.Status.INVALID_INPUT:
                        consoleIO.PutOutput_InvalidToken(user_input);
                        break;
                    case IO.Status.EMPTY:
                        consoleIO.PutOutput_exit();
                        running = false;
                        break;
                }
            }
        }
        private void RunFile(string file_input, string file_output)
        {
            bool running = true;
            using (StreamReader sReader = File.OpenText(file_input))
            {
                using (StreamWriter sWriter = File.CreateText(file_output))
                {
                    while (running)
                    {
                        // no prompt for file IO
                        IO.Status status = fileIO.GetInput(sReader, out string user_input);
                        switch (status)
                        {
                            case IO.Status.VALID_INPUT:
                                TokenStack rpn = new TokenStack(user_input);
                                try
                                {
                                    fileIO.PutOutput_Result(sWriter, Calculator.PreCalc(rpn));
                                }
                                catch (Exception e)
                                {
                                    fileIO.PutOutput_Message(sWriter, e.Message);
                                }
                                break;
                            case IO.Status.INVALID_INPUT:
                                fileIO.PutOutPut_InvalidToken(sWriter, user_input);
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
