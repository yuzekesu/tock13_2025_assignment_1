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
        
        // public methods:
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

    }
}
