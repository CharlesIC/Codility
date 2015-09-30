namespace Codility
{
    using System;

    public class CountSemiprimes
    {
        public int[] Solution(int N, int[] P, int[] Q)
        {
            var M = P.Length;
            var factors = new int[N + 1];
            var cumSemiprimes = new int[N + 1];
            var countSemiprimes = new int[M];

            // Determine minimum prime factors for all elements of the array
            var num = 2;
            while (num * num <= N)
            {
                if (factors[num] == 0)
                {
                    var k = num * num;
                    while (k <= N)
                    {
                        if (factors[k] == 0)
                        {
                            factors[k] = num;
                        }

                        k += num;
                    }
                }

                num++;
            }

            // Determine semiprimes
            for (int i = 4; i <= N; i++)
            {
                cumSemiprimes[i] = cumSemiprimes[i - 1];

                if (factors[i] != 0)
                {
                    if (factors[i / factors[i]] == 0)
                    {
                        cumSemiprimes[i]++;
                    }
                }
            }

            // Return number of semiprimes in range
            for (int query = 0; query < M; query++)
            {
                countSemiprimes[query] = cumSemiprimes[Q[query]] - cumSemiprimes[P[query] - 1];
            }

            return countSemiprimes;
        }
    }
}
