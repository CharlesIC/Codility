using System;
using System.Collections.Generic;

namespace Practice
{
	public class Dominator
	{
		public int Solution(int[] A)
		{
			var stack = new Stack<int>();

			foreach (var number in A) {
				if (stack.Count == 0 || stack.Peek() == number) {
					stack.Push(number);
				} else {
					stack.Pop();
				}
			}

			if (stack.Count == 0) {
				return -1;
			}

			var candidate = stack.Peek();
			var occurences = Array.FindAll(A, element => element == candidate).Length;

			if (occurences > A.Length / 2) {
				return Array.FindIndex(A, element => element == candidate);
			}

			return -1;
		}
	}
}
