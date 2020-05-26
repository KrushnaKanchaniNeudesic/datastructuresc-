using System;

namespace DoubleLinkedlist
{
    class Program
    {
        static void Main(string[] args)
        {
            DoubleLinkedList<int> linked = new DoubleLinkedList<int>();
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
