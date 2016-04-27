using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Async
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Run().Wait();
        }

        public static async Task Run()
        {
            Console.WriteLine($"[{DateTime.Now}] Generating directory...");
            Dictionary<string, List<string>> directory = await DirectoryGenerator.GenerateAsyncFast();
            Console.WriteLine($"[{DateTime.Now}] Done!\n");

            foreach (var company in directory.Keys)
            {
                Console.WriteLine($"{company}:");

                foreach (var employee in directory[company])
                    Console.WriteLine($"     {employee}");
            }

            Console.ReadKey(true);
        }
    }
}