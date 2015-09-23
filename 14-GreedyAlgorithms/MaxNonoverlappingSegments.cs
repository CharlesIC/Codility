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

                var nextStick = stick + 1;
                while (nextStick < B.Length && A[nextStick] <= currentPosition)
                {
                    nextStick++;
                }

                stick = nextStick;
            }

            return result;
        }
    }
}
