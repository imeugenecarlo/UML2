using System;

namespace UML2
{
    class Program
    {
        static void Main(string[] args)
        {

            Store store = new Store();
            store.Test();
            Console.WriteLine("Press any key to continue into user dialog");
            Console.ReadKey();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Red;
            store.Run();
            
        }
    }
}
