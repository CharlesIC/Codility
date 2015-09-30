using System;

namespace Codility
{
	public class MaxSliceSum
	{
		public int Solution(int[] A)
		{
			var maxSumEnding = 0;
			var maxSum = -int.MaxValue;

			foreach (var num in A) {
				maxSumEnding += num;
				maxSum = Math.Max(maxSumEnding, maxSum);

				if (maxSumEnding < 0) {
					maxSumEnding = 0;
				}
			}

			return maxSum;
		}

		public int Solution2(int[] A)
		{
			var maxSumEndingHere = 0;
			var maxSlice = A[0];

			foreach (var num in A) {
				maxSumEndingHere = Math.Max(maxSumEndingHere + num, num);
				maxSlice = Math.Max(maxSlice, maxSumEndingHere);
			}

			return maxSlice;
		}
	}
}

