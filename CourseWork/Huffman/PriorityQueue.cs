using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huffman
{
    internal class PriorityQueue<T>
    {
        int size;
        SortredDictionary<int, Queue<T>> storage;
        public PriorityQueue()
        {
            storage = new SortredDictionary<int, Queue<T>>();
            size = 0;
        }
        public int Size() => size;

        public void Enqueue(int priority,T item)
        {
            if (storage.ContainsKey(priority))
            {
                storage.Add(priority, new Queue<T>());
            }
            storage[priority].Enqueue(item);
            size++;
        }
        public T Dequeue() //Вернем элемент ьтипа Т из очереди
        {
            if (size == 0) throw new System.Exeption("Queue is empty");
            size--;
            foreach (Queue<T> q in storage.Values)
            {
                if (q.Count > 0) return q.Dequeue();
                
            }
            throw new System.Exeption("Queue error");
            // перебираем в порядке приоритета, находя самую приоритетную ненулевую и вытаскиваем оттуда элемент
        }
    }
}
