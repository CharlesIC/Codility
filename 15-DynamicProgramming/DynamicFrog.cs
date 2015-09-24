using System;

namespace Practice
{
    public class DynamicFrog
    {
        public int solution(int[] S, int k, int q)
        {
            var n = S.Length;
            var dp = new int[k + 1];
            dp[0] = 1;

            for (int j = 1; j < k + 1; j++)
            {
                for (int i = 0; i < n; i++)
                {
                    if (S[i] <= j)
                    {
                        dp[j] = (dp[j] + dp[j - S[i]]) % q;
                    }
                }
            }

            return dp[k];
        }
    }
}
