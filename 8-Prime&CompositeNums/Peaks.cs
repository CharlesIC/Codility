using System.Collections.Generic;

namespace Codility
{
	public class Peaks
	{
		public int Solution(int[] A)
		{
			var N = A.Length;
			var countPeaks = 0;
			var peakPositions = new HashSet<int>();

			for (int i = 1; i < N - 1; i++) {
				if (A[i - 1] < A[i] && A[i] > A[i + 1]) {
					countPeaks++;
					peakPositions.Add(i);
				}
			}

			for (int i = countPeaks; i > 0; i--) {
				if (N % i == 0) {
					var blockSize = N / i;
					var boundary = blockSize;

				    using (var peaks = peakPositions.GetEnumerator())
				    {
				        while (peaks.Current < boundary && peaks.MoveNext() && boundary < N)
				        {
				            if (peaks.Current >= boundary) {
								boundary += blockSize;
							}
						}

						if (boundary == N) {
							return i;
						}
					}
				}
			}

			return 0;
		}
	}
}
