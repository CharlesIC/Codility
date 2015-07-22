using System;

namespace Codility
{
	public class MaxDoubleSliceSum
	{
		public int Solution(int[] A)
		{
			var N = A.Length;

			// Find prefix sums
			var prefixSums = new int[N];
			var maxSumEndingHere = 0;
			for (int i = 1; i < N - 1; i++) {
				maxSumEndingHere = Math.Max(0, maxSumEndingHere + A[i]);
				prefixSums[i] = maxSumEndingHere;
			}

			// Find suffix sums
			var suffixSums = new int[N];
			maxSumEndingHere = 0;
			for (int i = N - 2; i > 0; i--) {
				maxSumEndingHere = Math.Max(0, maxSumEndingHere + A[i]);
				suffixSums[i] = maxSumEndingHere;
			}

			// Find max double slice
			var maxDoubleSlice = prefixSums[0] + suffixSums[2];
			for (int i = 0; i < N - 2; i++) {
				maxDoubleSlice = Math.Max(maxDoubleSlice, prefixSums[i] + suffixSums[i + 2]);
			}

			return maxDoubleSlice;
		}

		public int IncorrectSolution(int[] A)
		{
			var N = A.Length;
			if (A.Length < 5) {
				return -1;
			}

			var prefixSums = new int[N];
			var suffixSums = new int[N];

			// Find prefix sums
			var maxSumEndingHere = 0;
			for (int i = 2; i < N - 2; i++) {
				maxSumEndingHere = Math.Max(maxSumEndingHere + A[i - 1], A[i - 1]);
				prefixSums[i] = maxSumEndingHere;
			}

			// Find suffix sums
			maxSumEndingHere = 0;
			for (int i = N - 3; i > 1; i--) {
				maxSumEndingHere = Math.Max(maxSumEndingHere + A[i + 1], A[i + 1]);
				suffixSums[i] = maxSumEndingHere;
			}

			// Find max double slice
			var maxDoubleSlice = prefixSums[2] + suffixSums[2];
			for (int i = 2; i < N - 2; i++) {
				maxDoubleSlice = Math.Max(maxDoubleSlice, prefixSums[i] + suffixSums[i]);
			}

			return maxDoubleSlice;
		}

		public int IncorrectSolution2(int[] A)
		{
			var N = A.Length;

			// Find prefix sums
			var prefixSums = new int[N];
			var maxSumEndingHere = 0;
			for (int i = 1; i < N - 1; i++) {
				maxSumEndingHere = Math.Max(maxSumEndingHere + A[i], A[i]);
				prefixSums[i] = maxSumEndingHere;
			}

			// Find suffix sums
			var suffixSums = new int[N];
			maxSumEndingHere = 0;
			for (int i = N - 2; i > 0; i--) {
				maxSumEndingHere = Math.Max(maxSumEndingHere + A[i], A[i]);
				suffixSums[i] = maxSumEndingHere;
			}

			// Find max double slice
			var maxDoubleSlice = prefixSums[0] + suffixSums[2];
			for (int i = 0; i < N - 2; i++) {
				maxDoubleSlice = Math.Max(maxDoubleSlice, prefixSums[i] + suffixSums[i + 2]);
			}

			return maxDoubleSlice;
		}
	}
}

