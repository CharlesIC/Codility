using System;
using System.Collections.Generic;

namespace Codility
{
	public class Fish
	{
		public int Solution(int[] A, int[] B)
		{
			var count = 0;
			var stack = new Stack<int>();

			for (int i = 0; i < A.Length; i++)
			{
				if (B[i] == 0)
				{
					while (stack.Count > 0 && A[i] > stack.Peek())
					{
						stack.Pop();
					}

					if (stack.Count == 0)
					{
						count++;
					}
				}
				else if (B[i] == 1)
				{
					stack.Push(A[i]);
				}
			}

			return count + stack.Count;
		}
	}
}

