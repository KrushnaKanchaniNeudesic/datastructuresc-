using System;
using System.ComponentModel;

namespace LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> linked = new LinkedList<int>();
            for (int i = 1; i <= 5; i++)
            {
                linked.Add(i);
            }

            linked.AddLast(6);

            foreach (var item in linked)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();

            

        }
    }
}
