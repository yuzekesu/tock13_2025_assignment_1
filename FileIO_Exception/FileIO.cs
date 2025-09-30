using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


//Merged Reader_IO och Writer_IO into FileIO to make it simpler
namespace Calculator.View
{
    //The File IO class for the calculator
    public class FileIO : IO
    {
        //Reads the input with StreamReader and draws a conclusion based on the if-statement
        //If the input is blank, it returns Status.EMPTY
        //If the input has a token that is not allowed, it returns Status.INVALID_INPUT
        //If the input is acceptable, it returns Status.VALID_INPUT
        public Status GetInput(StreamReader sr, out string userInput)
        {
            userInput = string.Empty;

            InputLine.NewLine(sr.ReadLine());
            if(InputLine.IsEmpty())
            {
                return Status.EMPTY;
            }

            if(InputLine.HasAlphabets(out string invalid))
            {
                user_input = invalid;
                return Status.INVALID;
            }

            user_input = InputLine.ProcessedLine;
            return Status.VALID_INPUT;
        }

        //This line of code writes two decimal places after a double so it fits the output criteria
        //This way the output becomes for example "10.00" instead of "10"
        public void PutOutputResult(StreamWriter sw, double result)
        {
            sw.WriteLine($"{result:F2}");
        }

        //This line of code writes an error message if needed in the output
        public void PutOutputMessage(StreamWriter sw, string message)
        {
            sw.WriteLine(message);
        }
        
        //InvalidTokenException output
        public void PutOutPutInvalidToken(StreamWriter sw, string token)
        {
            sw.WriteLine($"InvalidTokenException: {token}");
        }

        //This code implements "using StreamReader" and "using StreamWriter" so the input and output are always disposed
        //No memory leaks :)
        public void WithFiles(string inputPath, string outputPath, Action<StreamReader, StreamWriter> work)
        {
            using (StreamReader sReader = File.OpenText(inputPath))
            using (StreamWriter sWriter = File.CreateText(outputPath))
            {
                work(sReader, sWriter);
                sWriter.Flush();
            }
        }
    }
}
