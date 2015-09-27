using System;
using System.Linq;

namespace Codility
{
    public class NumberSolitaire
    {
        public int solution(int[] A)
        {
            const int d = 6;
            var n = A.Length;

            var maxScore = new int[d];

            for (int i = 0; i < maxScore.Length; i++)
            {
                maxScore[i] = A[0];
            }

            for (int p = 1; p < n; p++)
            {
                maxScore[p % d] = maxScore.Max() + A[p];
            }

            return maxScore[(n - 1) % d];
        }
    }
}
