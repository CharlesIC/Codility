using System;

namespace Codility
{
    public class MaxNonoverlappingSegments
    {
        public int solution(int[] A, int[] B)
        {
            var result = 0;
            var stick = 0;

            while (stick < B.Length)
            {
                result++;
                var currentPosition = B[stick];

                // Skip all sticks overlapping with the current one
                while (stick < B.Length && A[stick] <= currentPosition)
                {
                    stick++;
                }
            }

            return result;
        }

        public int solution2(int[] A, int[] B)
        {
            var result = 0;
            var currentPosition = -1;

            for (int stick = 0; stick < B.Length; stick++)
            {
                if (A[stick] > currentPosition)
                {
                    result++;
                    currentPosition = B[stick];
                }
            }

            return result;
        }
    }
}
