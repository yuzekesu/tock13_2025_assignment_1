using FileIO_proj;
using System;
using System.Globalization;

namespace FileIO_Exception
{
    internal class RPN_Test
    {
        public static double Evaluate(string expr)
        {
            if (string.IsNullOrWhiteSpace(expr))
            {
                throw new InvalidOperationException("Input is empty.");
            }

            var stack = new System.Collections.Generic.Stack<double>();
            var parts = expr.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var token in parts)
            {
                if(double.TryParse(token, NumberStyles.Float, CultureInfo.InvariantCulture,out var v) ||
                    double.TryParse(token.Replace(',' , '.'), NumberStyles.Float, CultureInfo.InvariantCulture, out v))
                {
                    stack.Push(v);
                    continue;
                }

                if(token is "+" or "-" or "*" or "/" or "%")
                {
                    if(stack.Count < 2)
                    {
                        throw new InvalidOperationException("InvalidOperationException\n");
                    }

                    var right = stack.Pop();
                    var left = stack.Pop();

                    stack.Push(token switch{

                        "+" => left + right,
                        "-" => left - right,
                        "*" => left * right,
                        //Tenerarys här för det fick koden o se lite snyggare ut XD
                        "/" => right == 0 ? throw new FileIO_proj.DivideByZeroException(left, right) : left / right,
                        "%" => right == 0 ? throw new FileIO_proj.DivideByZeroException(left, right) : left % right, 
                        _ => throw new InvalidTokenException(token)
                    });

                    continue;
                }

                throw new InvalidTokenException(token);
            }

            if(stack.Count != 1)
            {
                throw new InvalidOperationException("InvalidOperationException");
            }

            return stack.Pop();
        }
    }

    public static class Program
    {
        public static void Main(string[] args)
        {
            Reader_IO reader;
            Writer_IO writer;

            if (args.Length == 0)
            {
                reader = new ConsoleReader_IO();
                writer = new ConsoleWriter_IO();
                Console.WriteLine("Enter your equation: ");
            }
            else if (args.Length == 2)
            {
                reader = new FileReader_IO(args[0]);
                writer = new FileWriter_IO(args[1]);
            }
            else
            {
                Console.WriteLine("Syntax: Program [source destination]");
                return;
            }

            RunLoop(reader, writer);
        }

        private static void RunLoop(Reader_IO reader, Writer_IO writer)
        {
            while (true)
            {
                var line = reader.ReadLine();
                if (line == null || string.IsNullOrWhiteSpace(line))
                {
                    if (writer is ConsoleWriter_IO)
                    {
                        writer.WriteLine("Exiting...");
                    }
                    writer.FlushAndClose();
                    break;
                }

                try
                {
                    var result = RPN_Test.Evaluate(line);

                    if (writer is ConsoleWriter_IO)
                    {
                        writer.WriteLine($"Result: {result:0.0}");
                    }
                    else
                    {
                        writer.WriteLine($"{result:F2}");
                    }
                }
                catch (FileIO_proj.DivideByZeroException ex)
                {
                    if (writer is ConsoleWriter_IO)
                    {
                        writer.WriteLine($"DivideByZeroException: {ex.Left:0.0}/{ex.Right:0.0}");
                    }
                    else
                    {
                        writer.WriteLine($"DivideByZeroException: {ex.Left:F2}/{ex.Right:F2}");
                    }
                }
                catch (InvalidTokenException ex)
                {
                    writer.WriteLine($"InvalidTokenException: {ex.Token}");
                }
                catch (InvalidOperationException)
                {
                    writer.WriteLine("InvalidOperationException");
                }
                catch (Exception e)
                {
                    writer.WriteLine($"Exception: {e.Message}");
                }
            }
        }
    }
}
