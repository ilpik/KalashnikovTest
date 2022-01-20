using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalashnikovTest.DoublyLinkedList
{
    public class DoublyLinkedList<T> : IEnumerable<T>  // двусвязный список
    {
        public static DoublyNode<T> Head; // головной/первый элемент
        public static DoublyNode<T> Tail; // последний/хвостовой элемент
        private static int _count;  // количество элементов в списке

        public DoublyNode<T> GetHead() => Head;

        // добавление элемента
        public void Add(T data)
        {
            DoublyNode<T> node = new DoublyNode<T>(data);

            if (Head == null)
                Head = node;
            else
            {
                Tail.Next = node;
                node.Previous = Tail;
            }
            Tail = node;
            _count++;
        }

        public void AddFirst(T data)
        {
            DoublyNode<T> node = new DoublyNode<T>(data);
            DoublyNode<T> temp = Head;
            node.Next = temp;
            Head = node;
            if (_count == 0)
                Tail = Head;
            else
                temp.Previous = node;
            _count++;
        }

        // удаление
        public bool DeleteFromList(T data)
        {
            DoublyNode<T> current = FindNode(data);

            if (current != null)
            {
                // если узел не последний
                if (current.Next != null)
                {
                    current.Next.Previous = current.Previous;
                }
                else
                {
                    // если последний, переустанавливаем tail
                    Tail = current.Previous;
                }

                // если узел не первый
                if (current.Previous != null)
                {
                    current.Previous.Next = current.Next;
                }
                else
                {
                    // если первый, переустанавливаем head
                    Head = current.Next;
                }
                _count--;
                return true;
            }
            return false;
        }

        // удаление
        public void SendNodeToEnd(T data)
        {
            DeleteFromList(data);

            Add(data);
        }

        public DoublyNode<T> FindNode(T data)
        {
            DoublyNode<T> node = Head;

            // поиск  узла
            while (node != null)
            {
                if (node.Data.Equals(data))
                {
                    break;
                }
                node = node.Next;
            }

            return node;
        }
        public int Count { get { return _count; } }
        public bool IsEmpty { get { return _count == 0; } }

        public void Clear()
        {
            Head = null;
            Tail = null;
            _count = 0;
        }

        public bool Contains(T data)
        {
            DoublyNode<T> current = Head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                    return true;
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
            DoublyNode<T> current = Head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        public IEnumerable<T> BackEnumerator()
        {
            DoublyNode<T> current = Tail;
            while (current != null)
            {
                yield return current.Data;
                current = current.Previous;
            }
        }
    }
}
