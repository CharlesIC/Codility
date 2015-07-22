using System;

namespace Codility
{
	public class Stack
	{
		private readonly int[] stack;
		private readonly int capacity;
		private int size;

		public Stack(int N)
		{
			size = 0;
			capacity = N;
			stack = new int[N];
		}

		public void Push(int x)
		{
			if (size == capacity) {
				throw new InvalidOperationException("Stack full");
			}
            
			stack[size] = x;
			size++;
		}

		public int Pop()
		{
			if (size == 0) {
				throw new InvalidOperationException("Stack empty");
			}
            
			size--;
			return stack[size];
		}

		public int Peek()
		{
			if (size == 0) {
				throw new InvalidOperationException("Stack empty");
			}

			return stack[size];
		}
	}
}

