using System;
using System.Collections.Generic;

namespace Practice
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

			// Test
			var h = new HashSet<int>();
			h.Add(1);
			h.Add(2);
			h.Add(3);

			var he = h.GetEnumerator();

			he.MoveNext();
			Console.Write(he.Current + " ");

			he.MoveNext();
			Console.Write(he.Current + " ");

			he.MoveNext();
			Console.Write(he.Current + " ");

			he.MoveNext();
			Console.Write(he.Current + " ");
			// -- end test

			for (int i = countPeaks; i > 1; i--) {
				if (N % i == 0) {
					var k = N / i;

					var boundary = k;
					using (var peaks = peakPositions.GetEnumerator()) {
//						while (peaks.Current < boundary && boundary <= N) {
//							if (!peaks.MoveNext()) {
//								if (boundary < N) {
//									return 0;	
//								}
//
//								return k;
//							}
//						}
//						boundary += k;
//
//						while (boundary <= N) {
//							if (peaks.MoveNext()) {
//								if (peaks.Current > boundary) {
//									boundary += k;
//								}
//							} else if (boundary == N) {
//								return k;
//							} else {
//								return 0;
//							}
//						}

						while (peaks.Current < boundary && boundary < N) {
							if (!peaks.MoveNext()) {
								return 0;
							}

							if (peaks.Current > boundary) {
								boundary += k;
							}
						}

						return i;
					}
				}
			}

			return 0;
		}
	}
}
