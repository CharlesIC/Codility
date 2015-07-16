using System;

namespace Practice
{
	// Different methods to find the GCD (Greatest
	// Common Divisor) of two numbers. From
	// least to most efficient

	public class GCD
	{
		public int GcdSubstract(int a, int b)
		{
			if (a == b) {
				return a;
			} else if (a > b) {
				return GcdSubstract(a - b, b);
			} else {
				return GcdSubstract(a, b - a);
			}
		}


		public int GcdModulo(int a, int b)
		{
			if (a % b == 0) {
				return b;
			} else {
				return GcdModulo(b, a % b);
			}
		}


		public	int GcdBinary(int a, int b, int res)
		{
			if (a == b) {
				return a * res;

			} else if (a % 2 == 0 && b % 2 == 0) {
				return GcdBinary(a / 2, b / 2, 2 * res);

			} else if (a % 2 == 0) {
				return GcdBinary(a / 2, b, res);

			} else if (b % 2 == 0) {
				return GcdBinary(a, b / 2, res);

			} else if (a > b) {
				return GcdBinary(a - b, b, res);

			} else {
				return GcdBinary(a, b - a, res);
			}
		}
	}
}

