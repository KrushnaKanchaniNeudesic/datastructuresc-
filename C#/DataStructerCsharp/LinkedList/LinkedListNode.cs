using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedList
{
    public class LinkedListNode<T>
    {
        public LinkedListNode(T value)
        {
            this.Value = value;
        }
                                                                                      
        public T Value { get; set; }

        public LinkedListNode<T> Next { get; set; }
    }
}
