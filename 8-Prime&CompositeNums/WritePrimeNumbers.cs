using System;

namespace Codility
{
	public class WritePrimeNumbers
	{
		public void GeneratePrimeNumbers(int n)
		{
			Console.WriteLine("Prime numbers up to {0}:", n);

			for (int i = 0; i < 1000; i++) {
				if (IsPrime(i)) {
					Console.Write("{0} ", i);
				}
			}

			Console.WriteLine();
		}

		private bool IsPrime(int n)
		{
			if (n <= 1) {
				return false;
			}

			int i = 2;
			while (i * i <= n) {
				if (n % i == 0) {
					return false;
				}
				i++;
			}

			return true;
		}
	}
}

