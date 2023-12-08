using System;

namespace G6RXAI_ADT_2023241.Client
{     static class Extension
{
    public static void ToProcess<T>(this IEnumerable<T> query, string name)
    {
        Console.WriteLine($"\n:: {name} ::\n");

        foreach (var item in query)
            Console.WriteLine("\t" + item);

        Console.WriteLine("\n\n");
    }
}
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
        }
    }
}
