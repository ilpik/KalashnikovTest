using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalashnikovTest.Queue
{
    public class AppQueue<T> : IEnumerable<T> 
    {
        QueueNode<T> head; // головной/первый элемент
        QueueNode<T> tail; // хвостовой элемент/последний
        int count;

        // добавление в очередь
        public void AddToQueue(T data)
        {
            QueueNode<T> QueueNode = new QueueNode<T>(data);
            QueueNode<T> tempQueueNode = tail;
            tail = QueueNode;
            if (count == 0)
                head = tail;
            else
                tempQueueNode.Next = tail;
            count++;
        }

        // удаление из очереди
        public void DeleteFromQueue()
        {
            if (count == 0)
                throw new InvalidOperationException();
            head = head.Next;
            count--;
        }

        // Перенос первого в конец  очереди
        public void SendFirstToEnd()
        {
            QueueNode<T> node = head;
            DeleteFromQueue();
            AddToQueue(node.Data);
        }
        // получаем первый элемент
        public T GetFirst
        {
            get
            {
                if (IsEmpty)
                    return default(T);
                return head.Data;
            }
        }

        // получаем последний элемент
        public T GetLast
        {
            get
            {
                if (IsEmpty)
                    throw new InvalidOperationException();
                return tail.Data;
            }
        }
        public int Count => count;
        public bool IsEmpty => count == 0;

        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public bool Contains(T data)
        {
            QueueNode<T> current = head;
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
            QueueNode<T> current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }
}
