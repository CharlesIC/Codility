using System;

namespace Codility
{
    public class Queue
    {
        private readonly int[] queue;
        private readonly int capacity;
        private int head, tail;

        public Queue(int N)
        {
            head = tail = 0;
            capacity = N;
            queue = new int[N];
        }

        public void Push(int x)
        {
            tail = ++tail % capacity;

            if (tail == head)
            {
                throw new InvalidOperationException("Queue full");
            }

            queue[tail] = x;
        }

        public int Pop()
        {
            head = ++head % capacity;

            if (tail == head)
            {
                throw new InvalidOperationException("Queue empty");
            }

            return queue[head];
        }

        public int Size()
        {
            return tail - head + capacity;
        }

        public bool Empty()
        {
            return tail == head;
        }
    }
}
