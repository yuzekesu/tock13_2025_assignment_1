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
        public static void PutOutput_Prompt()
        {
            Console.Write("Enter an RPN expression <return> (empty string = exit):");
        }
        public static void PutOutput_Result(double result_in_double)
        {
            Console.WriteLine($"Result: {result_in_double:f2}");
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
        private static bool VerifyInput_HasAlphabets(string input, out string theInvalid)
        {
            theInvalid = "\0";
            bool hasAlphabets = false;
            double temp_number;
            foreach (string s in input.Split(' ', StringSplitOptions.RemoveEmptyEntries))
            {
                if (double.TryParse(s, out temp_number) || VerifyString_IsOperand(s))
                {
                    ;
                }
                else
                {
                    theInvalid = s;
                    hasAlphabets = true;
                    break;
                }
            }
            return hasAlphabets;
        }
        private static bool VerifyString_IsOperand(string operand)
        {
            bool isValid = false;
            if (operand.Length == 1)
            {
                switch (operand[0])
                {
                    case '+': isValid = true; break;
                    case '-': isValid = true; break;
                    case '*': isValid = true; break;
                    case '/': isValid = true; break;
                    case '%': isValid = true; break;
                }
            } 
            
            return isValid;
        }
        private static string EditInput_DiscardsRedundantSpaces(string row_input)
        {
            string processed_input = "";
            string[] words = row_input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            foreach (var current in row_input.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select((word, offset) => new {offset, word})) // this is stupid.
            {
                if (current.offset == 0)
                {
                    processed_input += current.word;
                }
                else
                {
                    processed_input += ' ';
                    processed_input += current.word;
                }
            }
            return processed_input;
        }
        private static string EditInput_DiscardsTabs(string row_input)
        {
            string processed_input = "";
            foreach (char c in row_input)
            {
                if (c != '\t')
                {
                    processed_input += c;
                }
            }
            return processed_input;
        }
        private static string EditInput_FullCourse(string row_input) 
        {
            // get rides of tabs and spaces
            return EditInput_DiscardsRedundantSpaces(EditInput_DiscardsTabs(row_input));
        }
    }
}
