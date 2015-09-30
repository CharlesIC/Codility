using System;

namespace Codility
{
	public class MaxProfit
	{
		public int Solution(int[] A)
		{
			if (A.Length < 1) {
				return 0;
			}

			var minPrice = A[0];
			var maxPrice = A[0];
			var maxProfit = 0;

			foreach (var price in A) {
				if (price > maxPrice) {
					maxPrice = price;
				    maxProfit = Math.Max(maxProfit, maxPrice - minPrice);
				}
				else if (price < minPrice)
				{
				    minPrice = maxPrice = price;
				}
			}

			return maxProfit;
		}

		public int Solution2(int[] A)
		{
			if (A.Length < 1) {
				return 0;
			}

			var maxProfit = 0;
			var minPrice = A[0];

			foreach (var price in A) {
				maxProfit = Math.Max(maxProfit, price - minPrice);
				minPrice = Math.Min(minPrice, price);
			}

			return maxProfit;
		}
	}
}

