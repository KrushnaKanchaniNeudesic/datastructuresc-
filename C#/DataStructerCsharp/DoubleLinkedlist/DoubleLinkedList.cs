using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DoubleLinkedlist
{
    public class DoubleLinkedList<T> : ICollection<T>
    {
        public int Count { get; private set; }

        /// <summary>
        /// First node in list 
        /// </summary>
        public DoubleLinkedListNode<T> Head { get; private set; }

        public DoubleLinkedListNode<T> Tail { get; private set; }


        #region Add

        public void AddFirst(T value)
        {
            this.AddFirst(new DoubleLinkedListNode<T>(value));
        }

        public void AddFirst(DoubleLinkedListNode<T> node)
        {
            DoubleLinkedListNode<T> temp = Head;

            Head = node;

            Head.Next = temp;

            if (Count == 0)
            {
                Tail = Head;
            }
            else
            {
                temp.Previous = Head;
            }

            Count++;

        }

        public void AddLast(T value)
        {
            this.AddLast(new DoubleLinkedListNode<T>(value));
        }

        public void AddLast(DoubleLinkedListNode<T> node)
        {
            if (Count == 0)
            {
                Head = node;
            }
            else
            {
                Tail.Next = node;
                node.Previous = Tail;
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
                else
                {
                    Head.Previous = null;
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
                // Before: Head --> 3 --> 5 --> 7
                //         Tail = 7
                // After:  Head --> 3 --> 5 --> null
                //         Tail = 5
                // Null out 5's Next pointer
                Tail.Previous.Next = null;
                Tail = Tail.Previous;
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
            DoubleLinkedListNode<T> current = Head;
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
            DoubleLinkedListNode<T> current = Head;
            while (current != null)
            {
                array[arrayIndex++] = current.Value;
                current = current.Next;
            }
        }



        public bool Remove(T item)
        {
            DoubleLinkedListNode<T> previous = null;
            DoubleLinkedListNode<T> current = Head;

            // foure case 
            // 1. empty list do nothing
            // 2. Single node: (Previous Null)
            // 3. many nodes
            //    a. node to remove is the first node
            //    b. node to remove middile or last



            while (current != null)
            {
                if (current.Value.Equals(item))
                {
                    // it's node in middle or end 
                    if (previous != null)
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
                        if (current.Next == null)
                        {
                            Tail = previous;
                        }
                        else
                        {
                            // Before: Head -> 3 <-> 5 <-> 7 -> null
                            // After:  Head -> 3 <-------> 7 -> null

                            // previous = 3
                            // current = 5
                            // current.Next = 7
                            // So... 7.Previous = 3
                            current.Next.Previous = previous;
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
            DoubleLinkedListNode<T> current = Head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        #endregion
    }
}
