using System;
using System.Threading.Tasks;

namespace films
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("TMDB film viewer!");
            while (true)
            {
                Console.WriteLine("\nOptions:");
                Console.WriteLine("1) Select film");
                Console.WriteLine("2) Search film");
                Console.WriteLine("0) Exit program");
                int input = 99;
                bool parse = int.TryParse(Console.ReadLine(), out input);
                if (!parse) { continue; }
                switch (input)
                {
                    case 0: Environment.Exit(0); break;
                    case 1: await DisplayFilm.Run();   break;
                    case 2: Console.WriteLine("TWO"); break;
                    default: Console.WriteLine("invalid option\n"); break;
                }
            }

        }
    }
}