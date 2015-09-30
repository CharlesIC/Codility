using System;

namespace Codility
{
	public class MinPerimeterRectangle
	{
		public int Solution(int N)
		{
			var minPerimeter = 2 * (N + 1);

			int i = 1;
			while (i * i <= N) {
				if (N % i == 0) {
					minPerimeter = Math.Min(minPerimeter, 2 * (i + (N / i)));
				}
				i++;
			}

			return minPerimeter;
		}
	}
}

