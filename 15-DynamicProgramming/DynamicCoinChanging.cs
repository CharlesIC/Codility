using System;

namespace Practice
{
    public class DynamicCoinChanging
    {
        public int solution(int[] C, int K)
        {
            var n = C.Length;
            var dp = new int[n + 1, K + 1];

            for (int i = 1; i <= K; i++)
            {
                dp[0, i] = int.MaxValue;
            }

            for (int i = 1; i < n + 1; i++)
            {
                for (int j = 0; j < C[i - 1]; j++)
                {
                    dp[i, j] = dp[i - 1, j];
                }

                for (int j = C[i - 1]; j < K + 1; j++)
                {
                    dp[i, j] = Math.Min(dp[i, j - C[i - 1]] + 1, dp[i - 1, j]);
                }
            }

            for (int i = 0; i < dp.GetLength(0); i++)
            {
                Console.WriteLine();

                for (int j = 0; j < dp.GetLength(1); j++)
                {
                    Console.Write("{0} ", dp[i, j]);
                }
            }

            Console.WriteLine();
            return dp[n, K];
        }

        // More efficient memory use - only remember the previous row
        public int solution2(int[] C, int K)
        {
            var n = C.Length;
            var dp = new int[K + 1];

            for (int i = 1; i <= K; i++)
            {
                dp[i] = int.MaxValue;
            }

            for (int i = 1; i < n + 1; i++)
            {
                for (int j = C[i - 1]; j < K + 1; j++)
                {
                    dp[j] = Math.Min(dp[j - C[i - 1]] + 1, dp[j]);
                }
            }

            Console.WriteLine();
            foreach (var value in dp)
            {
                Console.Write("{0} ", value);
            }
            Console.WriteLine();

            return dp[K];
        }
    }
}
