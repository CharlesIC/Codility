namespace Practice
{
    using System.Collections.Generic;

    internal class CountNonDivisible
    {
        public int[] Solution(int[] A)
        {
            var N = A.Length;
            var numbers = new HashSet<int>();
            var countDivisibles = new int[(2 * N) + 1];
            var countIndivisibles = new int[N];

            foreach (var x in A)
            {
                numbers.Add(x);
            }

            for (int i = 0; i < N; i++)
            {
                var num = A[i];
                while (num <= 2 * N)
                {
                    if (numbers.Contains(num))
                    {
                        countDivisibles[num]++;
                    }

                    num += A[i];
                }
            }

            for (int i = 0; i < N; i++)
            {
                countIndivisibles[i] = N - countDivisibles[A[i]];
            }

            return countIndivisibles;
        }
    }
}
