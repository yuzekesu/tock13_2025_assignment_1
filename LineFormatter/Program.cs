using Calculator.View;

namespace LineFormatter_Program
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LineFormatter line = new(Console.ReadLine());
            Console.WriteLine(line.ProcessedLine);
        }
    }
}
