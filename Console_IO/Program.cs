using Calculator.View;
using static System.Net.Mime.MediaTypeNames;
namespace Console_IO_Program
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool running = true;
            while (running)
            {
                Console_IO.PutOutput_Prompt();
                Console_IO.Status status = Console_IO.GetInput(out string user_input);
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
