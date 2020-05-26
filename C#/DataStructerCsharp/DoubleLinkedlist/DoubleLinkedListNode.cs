using System;
using System.Collections.Generic;
using System.Text;

namespace DoubleLinkedlist
{
    public class DoubleLinkedListNode<T>
    {
        public DoubleLinkedListNode(T value)
        {
            this.Value = value;
        }

        public T Value { get; set; }

        public DoubleLinkedListNode<T> Next { get; set; }

        public DoubleLinkedListNode<T> Previous { get; set; }
    }
}
