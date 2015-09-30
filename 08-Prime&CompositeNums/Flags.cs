using System;
using System.Linq;
using System.Collections.Generic;

namespace Codility
{
	public class Flags
	{
		public int Solution(int[] A)
		{
			var N = A.Length;
			var minDistance = N;
			var maxDistance = 0;
			var maxFlags = 0;
			var peakPositions = new HashSet<int>();

			for (int i = 1; i < N - 1; i++) {
				if (A[i - 1] < A[i] && A[i] > A[i + 1]) {
					if (peakPositions.Count > 0) {
						minDistance = Math.Min(minDistance, i - peakPositions.Last());
					} 
					peakPositions.Add(i);
				}
			}

			if (peakPositions.Count < 2) {
				return peakPositions.Count;
			}

			maxDistance = (int)Math.Min(peakPositions.Count, Math.Sqrt(N) + 1);
			for (int i = maxDistance; i >= minDistance; i--) {
				var distance = i;
				var flagsSet = 0;

				using (var peaks = peakPositions.GetEnumerator()) {
					var nextFlagBoundary = 0;

					while (peaks.MoveNext() &&
					       flagsSet < distance &&
					       nextFlagBoundary <= N) {

						if (peaks.Current >= nextFlagBoundary) {
							flagsSet++;
							nextFlagBoundary = peaks.Current + distance;	
						}
					}
				}

				maxFlags = Math.Max(maxFlags, flagsSet);
			}

			return maxFlags;
		}


		public int Solution2(int[] A)
		{
			var N = A.Length;
			var nextPeak = new int[N];
			var peakCount = 0;
			var firstPeak = -1;

			for (int i = 0; i < N; i++) {
				nextPeak[i] = -1;
			}

			for (int i = N - 2; i > 0; i--) {
				if (A[i] > A[i + 1] && A[i] > A[i - 1]) {
					nextPeak[i] = i;
					peakCount++;
					firstPeak = i;
				} else {
					nextPeak[i] = nextPeak[i + 1];
				}
			}
			if (peakCount < 2) {
				return peakCount;
			}

			var maxFlags = 1;
			var maxMinDistance = (int)Math.Sqrt(N);
			for (int minDistance = maxMinDistance + 1; minDistance > 1; minDistance--) {
				var flagsUsed = 1;
				var flagsRemaining = minDistance - 1;
				var pos = firstPeak;

				while (flagsRemaining > 0) {
					if (pos + minDistance > N - 1) {
						break;
					} else {
						pos = nextPeak[pos + minDistance];
					}
					if (pos == -1) {
						break;
					}

					flagsUsed++;
					flagsRemaining--;
				}

				maxFlags = Math.Max(maxFlags, flagsUsed);
			}

			return maxFlags;
		}
	}
}

