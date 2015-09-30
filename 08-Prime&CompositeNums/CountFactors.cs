namespace Codility
{
	public class CountFactors
	{
		public int Solution(int N)
		{
			var result = 0;

			int i = 1;
			while (i * i < N) {
				if (N % i == 0) {
					result += 2;
				}
				i++;
			}
			if (i * i == N) {
				result++;
			}

			return result;
		}
	}
}

