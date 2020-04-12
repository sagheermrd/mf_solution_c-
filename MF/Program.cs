using System;

namespace MF
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Enter input string");
            var input = Console.ReadLine();
            Console.WriteLine("=== Strated : " + DateTime.Now);
            var repeatedWords= new Utility().RepeatedWords(input);
            foreach (var word in repeatedWords)
            {
                Console.WriteLine(word);
            }
            Console.WriteLine("=== Finished : " + DateTime.Now);
        }
    }
}
