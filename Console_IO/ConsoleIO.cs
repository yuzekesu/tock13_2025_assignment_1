using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.View
{
    public class ConsoleIO : IO
    {
        // public methods:
        /// <summary>
        /// get a line from the standard input buffer.
        /// </summary>
        /// <param name="user_input"></param>
        /// <returns>the return does not contain any tabs or extra spaces</returns>
        public Status GetInput(out string user_input)
        {
            // initialization
            InputLine.NewLine(Console.ReadLine());
            user_input = string.Empty;
            Status status = Status.EMPTY;

            // start processing input
            if (InputLine.IsEmpty())
            {
                // when no inputs
                status = Status.EMPTY;
            }
            else 
            {

                if (InputLine.HasAlphabets(out string theInvalid))
                {
                    // when inputs contain anything other than operator and operands
                    status = Status.INVALID_INPUT;
                    user_input = theInvalid;
                }
                else
                {
                    // when inputs are valid (only operands and operators)
                    // we are not checking the logical validation here.
                    status = Status.VALID_INPUT;
                    user_input = InputLine.ProcessedLine;
                }
            } 
                return status;
        }
        public void AskInput()
        {
            Console.Write("Enter an RPN expression <return> (empty string = exit):");
        }
        public void WriteResult(double result_in_double)
        {
            Console.WriteLine($"Result: {result_in_double:f2}");
        }
        public void WriteInvalidToken(string the_invalid) 
        {
            Console.WriteLine($"InvalidTokenException: {the_invalid}");
        }
        public void WriteException(Exception e) 
        { 
            Console.WriteLine(e.Message);
        }
        public void WriteExit()
        {
            Console.WriteLine("The user exited the application");
        }
    }
}
