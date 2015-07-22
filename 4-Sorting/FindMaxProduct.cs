using System;

namespace Codility
{
    public class FindMaxProduct
    {
        public int MaxProductOfThree(int[] A)
        {
            var maxPos = new[] { int.MinValue, int.MinValue, int.MinValue };
            var maxNeg = new[] { int.MaxValue, int.MaxValue };
		        
            // Find three max pos and neg numbers
            foreach (var num in A)
            {
                UpdateMaxes(maxPos, num);
                UpdateMins(maxNeg, num);
            }
		        
            return Math.Max(maxPos[0] * maxPos[1] * maxPos[2],
                maxNeg[0] * maxNeg[1] * maxPos[0]);
        }

        private void UpdateMaxes(int[] maxes, int x)
        {
            if (x >= maxes[0])
            {
                maxes[2] = maxes[1];
                maxes[1] = maxes[0];
                maxes[0] = x;
            }
            else if (x >= maxes[1])
            {
                maxes[2] = maxes[1];
                maxes[1] = x;
            }
            else if (x > maxes[2])
            {
                maxes[2] = x;
            }
        }

        private void UpdateMins(int[] mins, int x)
        {
            if (x <= mins[0])
            {
                mins[1] = mins[0];
                mins[0] = x;
            }
            else if (x < mins[1])
            {
                mins[1] = x;
            }
        }
    }
}