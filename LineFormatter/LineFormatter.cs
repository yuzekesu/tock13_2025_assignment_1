using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.View
{
    /// <summary>
    /// A class for storing tab free & space free string line.
    /// </summary>
    public class LineFormatter
    {
        /// <summary>
        /// tab free & space free string line, thus is "processed". 
        /// </summary>
        public string ProcessedLine { get; private set;}
        public LineFormatter() 
        { 
            ProcessedLine = string.Empty;
        }
        public LineFormatter(string? line) 
        {
            ProcessedLine = string.Empty;
            NewLine(line);
        }
        /// <summary>
        /// Formatt a new line. This discard the previus one. String.Empty if the "line" is null.
        /// </summary>
        /// <param name="line"></param>
        public void NewLine(string? line)
        {
            ProcessedLine = line == null ? string.Empty : line;
            this.ReplaceTabsWithSpace();
            this.DiscardsRedundantSpaces();
        }
        // public: 
        public bool IsEmpty()
        {
            bool isEmpty = true;
            foreach (char c in ProcessedLine)
            {
                if (c != ' ' && c != '\n') // as long there is one valid input.
                {
                    isEmpty = false;
                }
            }
            return isEmpty;
        }
        public bool HasAlphabets(out string theInvalid)
        {
            theInvalid = "\0";
            bool hasAlphabets = false;
            double temp_number;
            foreach (string s in ProcessedLine.Split(' ', StringSplitOptions.RemoveEmptyEntries))
            {
                if (double.TryParse(s, out temp_number) || IsOperand(s))
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
        // private: 
        private bool IsOperand(string operand)
        {
            bool isValid = false;
            if (operand.Length == 1)
            {
                switch (operand[0])
                {
                    case '+': 
                    case '-': 
                    case '*': 
                    case '/': 
                    case '%': isValid = true; break;
                }
            }

            return isValid;
        }
        private void DiscardsRedundantSpaces()
        {
            string processing = "";
            foreach (var current in ProcessedLine.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select((word, offset) => new { offset, word })) // this is stupid.
            {
                if (current.offset == 0)
                {
                    processing += current.word;
                }
                else
                {
                    processing += ' ';
                    processing += current.word;
                }
            }
            ProcessedLine = processing;
        }
        private void ReplaceTabsWithSpace()
        {
            string processing = "";
            foreach (char c in ProcessedLine)
            {
                if (c != '\t')
                {
                    processing += c;
                }
                else
                {
                    processing += " ";
                }
            }
            ProcessedLine = processing;
        }

    }

}
