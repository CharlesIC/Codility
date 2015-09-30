using System;
using System.Collections.Generic;

namespace Codility
{
	public class Dominator
	{
		public int Solution(int[] A)
		{
			var stack = new Stack<int>();

			foreach (var number in A) {
				if (stack.Count == 0 || stack.Peek() == number) {
				    stack.Push(number);
				}
				else
				{
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

		public int Solution2(int[] A)
		{
			var candidate = -1;
			var candiateIndex = -1;
			var candidateCount = 0;

			for (int i = 0; i < A.Length; i++) {
				if (candidateCount == 0) {
					candidate = A[i];
					candidateCount++;
				    candiateIndex = i;
				}
				else if (A[i] == A[candiateIndex])
				{
				    candidateCount++;
				}
				else
				{
				    candidateCount--;
				}
			}

			if (Array.FindAll(A, x => x == candidate).Length <= A.Length / 2) {
				return -1;
			}

			return candiateIndex;
		}
	}
}
