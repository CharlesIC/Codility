using System;

namespace Codility
{
    public class TieRopes
    {
        public int solution(int K, int[] A)
        {
            var result = 0;
            var length = 0;

            foreach (var rope in A)
            {
                length += rope;

                if (length >= K)
                {
                    result++;
                    length = 0;
                }
            }

            return result;
        }
    }
}
