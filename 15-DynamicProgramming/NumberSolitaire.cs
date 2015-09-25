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
            maxScore[0] = A[0];

            for (int i = 1; i < maxScore.Length; i++)
            {
                maxScore[i] = int.MinValue;
            }


            for (int p = 1; p < n; p++)
            {
                maxScore[p % d] = maxScore.Max() + A[p];
            }

            return maxScore[(n - 1) % d];
        }
    }
}
