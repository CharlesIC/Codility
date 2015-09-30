using System;

namespace Codility
{
    public class DiscIntersections
    {
        public int Solution(int[] A)
        {
            int intersectionCount = 0;
            int discCount = A.Length;

            for (int i = 0; i < discCount - 1; i++)
            {
                for (int j = i + 1; j < discCount; j++)
                {
                    var d = j - i;
                    var r1 = A[i];
                    var r2 = A[j];

                    if (d <= r1 + r2)
                    {
                        intersectionCount++;
                    }
                }
            }

            return intersectionCount <= 10000000 ? intersectionCount : -1;
        }

        public int Solution2(int[] A)
        {
            int intersectionCount = 0;
            int discCount = A.Length;

            var leftEdges = new long[A.Length];
            var rightEdges = new long[A.Length];

            for (int i = 0; i < discCount; i++)
            {
                leftEdges[i] = i - (uint)A[i];
                rightEdges[i] = i + (uint)A[i];
            }

            Array.Sort(leftEdges);
            Array.Sort(rightEdges);

            var leftEdgesCounted = 0;
            for (int rightEdgesCounted = 0; rightEdgesCounted < discCount; rightEdgesCounted++)
            {
                while (leftEdgesCounted < discCount && rightEdges[rightEdgesCounted] >= leftEdges[leftEdgesCounted])
                {
                    leftEdgesCounted++;
                }

                intersectionCount += leftEdgesCounted - rightEdgesCounted - 1;
                if (intersectionCount > 10000000)
                {
                    return -1;
                }
            }

            return intersectionCount;
        }
    }
}
