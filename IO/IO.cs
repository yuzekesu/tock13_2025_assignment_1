using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.View
{
    public class IO
    {
        public enum Status
        {
            VALID_INPUT,
            INVALID_INPUT,
            EMPTY
        }
        // protected methods:
        protected static bool VerifyInput_IsEmpty(string input)
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
        protected static bool VerifyInput_HasAlphabets(string input, out string theInvalid)
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
        protected static bool VerifyString_IsOperand(string operand)
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
        protected static string EditInput_DiscardsRedundantSpaces(string row_input)
        {
            string processed_input = "";
            foreach (var current in row_input.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select((word, offset) => new { offset, word })) // this is stupid.
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
        protected static string EditInput_DiscardsTabs(string row_input)
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
        protected static string EditInput_FullCourse(string row_input)
        {
            // get rides of tabs and spaces
            return EditInput_DiscardsRedundantSpaces(EditInput_DiscardsTabs(row_input));
        }

    }
}
