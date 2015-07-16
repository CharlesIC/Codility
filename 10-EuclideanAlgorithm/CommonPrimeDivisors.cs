using System;
using System.Collections.Generic;

namespace Practice
{
	public class CommonPrimeDivisors
	{
		public int Solution(int[] A, int[] B)
		{
			var countPairs = 0;
			var gcdProvider = new GCD();

			for (int i = 0; i < A.Length; i++) {
				
				var gcd = gcdProvider.GcdBinary(A[i], B[i], 1);

				var residueA = A[i] / gcd;
				var residueB = B[i] / gcd;

				if ((gcd % residueA == 0) && (gcd % residueB == 0)) {
					countPairs++;
				}

			}

			return countPairs;
		}



		public int Solution2(int[] A, int[] B)
		{
			var count = 0;

			for (int i = 0; i < A.Length; i++) {
				if (HaveSamePrimeDivisors(A[i], B[i])) {
					count++;
				}
			}

			return count;
		}


		private bool HaveSamePrimeDivisors(int a, int b)
		{
			var gcd = Gcd(a, b, 1);

			// Check that a is composed only of factors of the GCD
			while (a != 1) {
				var gcdA = Gcd(a, gcd, 1);

				if (gcdA == 1) {
					break;
				}

				a /= gcdA;
			}

			if (a != 1) {
				return false;
			}

			// Check that a is composed only of factors of the GCD
			while (b != 1) {
				var gcdB = Gcd(b, gcd, 1);

				if (gcdB == 1) {
					break;
				}

				b /= gcdB;
			}

			return b == 1;
		}

		private int Gcd(int a, int b, int res)
		{
			if (a == b) {
				return a * res;

			} else if (a % 2 == 0 && b % 2 == 0) {
				return Gcd(a / 2, b / 2, 2 * res);

			} else if (a % 2 == 0) {
				return Gcd(a / 2, b, res);

			} else if (b % 2 == 0) {
				return Gcd(a, b / 2, res);

			} else if (a > b) {
				return Gcd(a - b, b, res);

			} else {
				return Gcd(a, b - a, res);
			}
		}
	}
}

