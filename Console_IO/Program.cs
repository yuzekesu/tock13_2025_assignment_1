using Calculator.View;
using static System.Net.Mime.MediaTypeNames;
namespace Console_IO_Program
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Debugging Console_IO:");
            Console_IO consoleIO = new();
            bool running = true;
            while (running)
            {
                consoleIO.PutOutput_Prompt();
                Console_IO.Status status = consoleIO.GetInput(out string user_input);
                switch (status) 
                {
                    case Console_IO.Status.VALID_INPUT:
                        Console.WriteLine(user_input); 
                        break;
                    case Console_IO.Status.INVALID_INPUT:
                        Console.WriteLine($"InvalidTokenException: {user_input}");
                        break;
                    case Console_IO.Status.EMPTY:
                        Console.WriteLine("The user exited the application");
                        running = false;
                        break;
                }
            }
            
            
        }
    }
}
