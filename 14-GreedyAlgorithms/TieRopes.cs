using System;

namespace Codility
{
    public class TieRopes
    {
        public int solution(int K, int[] A)
        {
            var result = 0;
            var currentLength = 0;

            foreach (var length in A)
            {
                if (currentLength < K)
                {
                    currentLength += length;
                }
                else
                {
                    result++;
                    currentLength = length;
                }
            }

            if (currentLength >= K)
            {
                result++;
            }

            return result;
        }
    }
}
