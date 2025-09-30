using Calculator.View;
using static System.Net.Mime.MediaTypeNames;
namespace Console_IO_Program
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Debugging Console_IO:");
            ConsoleIO consoleIO = new();
            bool running = true;
            while (running)
            {
                consoleIO.AskInput();
                ConsoleIO.Status status = consoleIO.GetInput(out string user_input);
                switch (status) 
                {
                    case ConsoleIO.Status.VALID:
                        Console.WriteLine(user_input); 
                        break;
                    case ConsoleIO.Status.INVALID:
                        Console.WriteLine($"InvalidTokenException: {user_input}");
                        break;
                    case ConsoleIO.Status.EMPTY:
                        Console.WriteLine("The user exited the application");
                        running = false;
                        break;
                }
            }
            
            
        }
    }
}
