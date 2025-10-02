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
                    status = Status.INVALID;
                    user_input = theInvalid;
                }
                else
                {
                    // when inputs are valid (only operands and operators)
                    // we are not checking the logical validation here.
                    status = Status.VALID;
                    user_input = InputLine.ProcessedLine;
                }
            } 
                return status;
        }
        /// <summary>
        /// asking for the user input in the console
        /// </summary>
        public void AskInput()
        {
            Console.Write("Enter an RPN expression <return> (empty string = exit):");
        }
        /// <summary>
        /// output the result
        /// </summary>
        /// <param name="result_in_double"></param>
        public void WriteResult(double result_in_double)
        {
            Console.WriteLine($"Result: {result_in_double:f2}");
        }
        /// <summary>
        /// output message for InvalidTokenException
        /// </summary>
        /// <param name="the_invalid">the part of string that is invalid</param>
        public void WriteInvalidToken(string the_invalid) 
        {
            Console.WriteLine($"InvalidTokenException: {the_invalid}");
        }
        /// <summary>
        /// output exceptions
        /// </summary>
        /// <param name="e"></param>
        public void WriteException(Exception e) 
        { 
            Console.WriteLine(e.Message);
        }
        /// <summary>
        /// prompt exit message
        /// </summary>
        public void WriteExit()
        {
            Console.WriteLine("The user exited the application");
        }
    }
}
