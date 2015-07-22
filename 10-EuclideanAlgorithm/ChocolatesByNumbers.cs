using System;

namespace Codility
{
	public class ChocolatesByNumbers
	{
		public int Solution(int N, int M)
		{
			var chocolates = new int[N];
			var countEaten = 0;

			var i = 0;
			while (chocolates[i] == 0) {
				chocolates[i] = 1;
				countEaten++;
				i = (i + M) % N;
			}

			return countEaten;
		}

		public int Solution2(int N, int M)
		{
			// Calculate the GCD
			var a = N;
			var b = M;
			int gcd;

			while (a % b != 0) {
				gcd = b;
				b = a % b;
				a = gcd;
			}
			gcd = b;

			return N / gcd;
		}
	}
}

