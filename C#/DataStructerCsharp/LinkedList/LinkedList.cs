using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LinkedList
{
    public class LinkedList<T> : ICollection<T>
    {
        public int Count { get; private set; }

        /// <summary>
        /// First node in list 
        /// </summary>
        public LinkedListNode<T> Head { get; private set; }

        public LinkedListNode<T> Tail { get; private set; }


        #region Add

        public void AddFirst(T value)
        {
            this.AddFirst(new LinkedListNode<T>(value));
        }

        public void AddFirst(LinkedListNode<T> node)
        {
            LinkedListNode<T> temp = Head;

            Head = node;

            Head.Next = temp;

            Count++;
            if (Count == 1)
            {
                Tail = Head;
            }
        }

        public void AddLast(T value)
        {
            this.AddLast(new LinkedListNode<T>(value));
        }

        public void AddLast(LinkedListNode<T> node)
        {
            if (Count == 0)
            {
                Head = node;
            }
            else
            {
                Tail.Next = node;
            }

            Tail = node;
            Count++;

        }

        #endregion


        #region Remove

        public void RemoveFirst()
        {
            if (Count != 0)
            {
                Head = Head.Next;
                Count--;
                if (Count == 0)
                {
                    Tail = Head;
                }
            }
        }

        public void RemoveLast()
        {
            if (Count == 1)
            {
                Head = null;
                Tail = null;
            }
            else
            {
                LinkedListNode<T> current = Head;
                while (current.Next != Tail)
                {
                    current = current.Next;
                }

                current.Next = null;
                Tail = current;
            }
            Count--;

        }

        #endregion

        #region Icollection

        public bool IsReadOnly => false;

        public void Add(T item)
        {
            this.AddFirst(item);
        }

        public void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        public bool Contains(T item)
        {
            LinkedListNode<T> current = Head;
            while (current.Next != null)
            {
                if (current.Value.Equals(item))
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            LinkedListNode<T> current = Head;
            while(current != null)
            {
                array[arrayIndex++] = current.Value;
                current = current.Next;
            }
        }

      

        public bool Remove(T item)
        {
            LinkedListNode<T> previous = null;
            LinkedListNode<T> current = Head;

            // foure case 
            // 1. empty list do nothing
            // 2. Single node: (Previous Null)
            // 3. many nodes
            //    a. node to remove is the first node
            //    b. node to remove middile or last



            while (current !=null)
            {
                if (current.Value.Equals(item))
                {
                    // it's node in middle or end 
                    if(previous != null)
                    {

                        // case 3a

                        // Scenario 1
                        // Before: head -> 3 -> 5 -> 7
                        // after : head -> 3 ------> 7

                        // Scenario 2
                        // Before: head -> 3 -> 5 -> null
                        // after:  head -> 3 ------> null  
                        //her we have to update with tail that we are doing if condition

                        previous.Next = current.Next;

                        // it was end node updating TailNode
                        if(current.Next  == null)
                        {
                            Tail = previous;
                        }
                        Count--;
                    }
                    else
                    {
                        //Case 2 or Case 3a
                        RemoveFirst();
                    }
                    return true;
                }

                previous = current;
                current = current.Next;
            }

            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)this).GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            LinkedListNode<T> current = Head;
            while(current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        #endregion
    }
}
