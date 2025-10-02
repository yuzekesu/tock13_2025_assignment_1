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
        /// <summary>
        /// Reads the input with StreamReader.
        /// </summary>
        /// <param name="sr"></param>
        /// <param name="userInput"></param>
        /// <returns>If the input is blank, it returns Status.EMPTY. If the input has a token that is not allowed, it returns Status.INVALID_INPUTIf the input is acceptable, it returns Status.VALID_INPUT</returns>
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
                userInput = invalid;
                return Status.INVALID;
            }

            userInput = InputLine.ProcessedLine;
            return Status.VALID;
        }

        /// <summary>
        /// Output the result.
        /// </summary>
        /// <param name="sw"></param>
        /// <param name="result"></param>
        public void PutOutputResult(StreamWriter sw, double result)
        {
            sw.WriteLine($"{result:F2}");
        }

        /// <summary>
        /// output message
        /// </summary>
        /// <param name="sw"></param>
        /// <param name="message"></param>
        public void PutOutputMessage(StreamWriter sw, string message)
        {
            sw.WriteLine(message);
        }

        /// <summary>
        /// Output InvalidTokenException
        /// </summary>
        /// <param name="sw"></param>
        /// <param name="token"></param>
        public void PutOutPutInvalidToken(StreamWriter sw, string token)
        {
            sw.WriteLine($"InvalidTokenException: {token}");
        }

        /// <summary>
        /// Wrapper
        /// </summary>
        /// <param name="inputPath"></param>
        /// <param name="outputPath"></param>
        /// <param name="work"></param>
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
