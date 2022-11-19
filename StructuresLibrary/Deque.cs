using System.Collections;

namespace StructuresLibrary
{
    public class Deque<T> : IEnumerable<T>
    {
        private DoublyNode<T> first;
        private DoublyNode<T> last;
        int count;

        public T First
        {
            get
            {
                if (IsEmpty)
                    throw new InvalidOperationException("The list is empty!");
                return first.Data;
            }
        }

        public T Last
        {
            get
            {
                if (IsEmpty)
                    throw new InvalidOperationException("The list is empty!");
                return last.Data;
            }
        }

        public bool IsEmpty => count == 0;

        public int Length => count;

        public void AddFirst(T data)
        {
            var node = new DoublyNode<T>(data);

            if (count == 0)
            {
                last = node;
            }
            else
            {
                node.Next = first;
                first.Previous = node;
            }
            first = node;

            count++;
        }

        public void Clear()
        {
            first = last = null;
            count = 0;
        }

        public void AddLast(T data)
        {
            var node = new DoublyNode<T>(data);

            if (count == 0)
            {
                first = node;
            }
            else
            {
                last.Next = node;
                node.Previous = last;
            }

            last = node;
            count++;
        }

        public T RemoveLast()
        {
            if (count == 0)
            {
                throw new InvalidOperationException("It is not possible to delete the last element of an empty list!");
            }

            T output = last.Data;

            if (count == 1)
            {
                first = last = null;
            }
            else
            {
                last = last.Previous;
                last.Next = null;
            }

            count--;
            return output;
        }

        public T RemoveFirst()
        {
            if (count == 0)
            {
                throw new InvalidOperationException("It is not possible to delete the first element of an empty list!");
            }

            T output = first.Data;
            if (count == 1)
            {
                first = last = null;
            }
            else
            {
                first = first.Next;
                first.Previous = null;
            }

            count--;
            return output;
        }

        public bool Contains(T data)
        {
            var current = first;

            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            var current = first;

            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }
}
