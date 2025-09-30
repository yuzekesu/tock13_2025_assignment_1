using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.View
{
    public class Console_IO : IO
    {
        // "if you are having too many static classes in the assignment, then you are doing a object-oriented programming" -- Lucy
        // so our straight forward solution was to erase the "static" keyword from the methods ;)
        // okey Lucy you are right im going to change it now.

        // public methods:
        /// <summary>
        /// get a line from the standard input buffer.
        /// </summary>
        /// <param name="user_input"></param>
        /// <returns>the return does not contain any tabs or extra spaces</returns>
        public Status GetInput(out string user_input)
        {
            // initialization
            user_input = "";
            Status status = Status.EMPTY;
            string? unhandled_input = null;

            // start processing input
            unhandled_input = Console.ReadLine();
            if (unhandled_input == null || VerifyInput_IsEmpty(unhandled_input))
            {
                // when no inputs
                status = Status.EMPTY;
            }
            else 
            {

                // get rides of tabs and spaces
                string processed_input = EditInput_FullCourse(unhandled_input);
                if (VerifyInput_HasAlphabets(processed_input, out string theInvalid))
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
                    user_input = processed_input;
                }
            } 
                return status;
        }
        public void PutOutput_Prompt()
        {
            Console.Write("Enter an RPN expression <return> (empty string = exit):");
        }
        public void PutOutput_Result(double result_in_double)
        {
            Console.WriteLine($"Result: {result_in_double:f2}");
        }
        public void PutOutput_InvalidToken(string the_invalid) 
        {
            Console.WriteLine($"InvalidTokenException: {the_invalid}");
        }
        public void PutOutput_Exception(Exception e) 
        { 
            Console.WriteLine(e.Message);
        }
        public void PutOutput_exit()
        {
            Console.WriteLine("The user exited the application");
        }
    }
}
