using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.View
{
    public class Console_IO
    {
        public enum Status
        {
            VALID_INPUT,
            INVALID_INPUT,
            EMPTY
        }
        // public methods:
        public static Status GetInput(out string user_input)
        {
            // initialization
            user_input = "";
            Status status = Status.EMPTY;
            string? unhandled_input = null;

            // start prompt
            unhandled_input = Console.ReadLine();
            if (unhandled_input == null || VerifyInput_IsEmpty(unhandled_input)) 
            {
                // when no inputs
                status = Status.EMPTY;
            }
            else if (VerifyInput_HasAlphabets(unhandled_input, out char theInvalid)) 
            {
                // when inputs contain alphabets
                status = Status.INVALID_INPUT;
                user_input += theInvalid;
            }
            else 
            {
                // when inputs are valid (only operands and operators)
                // we are not checking the logical validation here.
                status = Status.VALID_INPUT;
                user_input = unhandled_input;
            }
                return status;
        }
        public static void PutOutput_Prompt()
        {
            Console.Write("Enter an RPN expression <return> (empty string = exit):");
        }
        public static void PutOutput_Result(double result_in_double)
        {
            Console.WriteLine($"Result: {result_in_double}");
        }
        // private methods:
        private static bool VerifyInput_IsEmpty(string input)
        {
            bool isEmpty = true;
            foreach (char c in input)
            {
                if (c != ' ' && c != '\n') // as long there is one valid input.
                {
                    isEmpty = false;
                }
            }
            return isEmpty;
        }
        private static bool VerifyInput_HasAlphabets(string input, out char theInvalid)
        {
            theInvalid = '\0';
            bool hasAlphabets = false;
            int temp_number;
            foreach (char c in input)
            {
                if (c != ' ' && c != '\n') {
                    if (Int32.TryParse([c], out temp_number) || VerifyCharactor_IsOperand(c) || c == ',')
                    {
                        ;
                    }
                    else
                    {
                        theInvalid = c;
                        hasAlphabets = true;
                        break;
                    }
                } 
            }
            return hasAlphabets;
        }
        private static bool VerifyCharactor_IsOperand(char operand)
        {
            bool isValid = false;
            switch (operand)
            {
                case '+': isValid = true; break;
                case '-': isValid = true; break;
                case '*': isValid = true; break;
                case '/': isValid = true; break;
                case '%': isValid = true; break;
            }
            return isValid;
        }
    }
}
