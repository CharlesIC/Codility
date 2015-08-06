using System;
using System.Linq;
using System.Collections.Generic;

namespace Codility
{
    public class NailingPlanks
    {
        public int Solution(int[] A, int[] B, int[] C)
        {
            var planksAtPositions = IndexPlanks(A, B);

            var lowerBound = 1;
            var upperBound = C.Length;
            var result = -1;

            while (lowerBound <= upperBound)
            {
                var midNailsUsed = (lowerBound + upperBound) / 2;
                if (CheckNails(C, A.Length, midNailsUsed, planksAtPositions))
                {
                    upperBound = midNailsUsed - 1;
                    result = midNailsUsed;
                }
                else
                {
                    lowerBound = midNailsUsed + 1;
                }
            }

            return result;
        }

        private bool CheckNails(int[] nails, int countPlanks, int nailsUsed,
                                Dictionary<int, List<int>> planksAtPositions)
        {
            var planksNailed = new HashSet<int>();

            for (var i = 0; i < nailsUsed; i++)
            {
                var nailPosition = nails[i];

                if (!planksAtPositions.ContainsKey(nailPosition))
                {
                    continue;
                }

                foreach (var plank in planksAtPositions[nailPosition])
                {
                    if (!planksNailed.Contains(plank))
                    {
                        planksNailed.Add(plank);
                    }
                }
            }

            return planksNailed.Count == countPlanks;
        }

        Dictionary<int, List<int>> IndexPlanks(int[] A, int[] B)
        {
            var plankIndex = new Dictionary<int, List<int>>();
            var currentPlanks = new List<int>();

            var leftEdgeIdx = 0;
            var rightEdgeIdx = 0;

            for (int position = A.Min(); position <= B.Max(); position++)
            {
                while (leftEdgeIdx < A.Length && A[leftEdgeIdx] <= position)
                {
                    currentPlanks.Add(leftEdgeIdx);
                    leftEdgeIdx++;
                }

                while (rightEdgeIdx < B.Length && B[rightEdgeIdx] < position)
                {
                    currentPlanks.Remove(rightEdgeIdx);
                    rightEdgeIdx++;
                }

                var planksAtCurrentPositon = new List<int>(currentPlanks);
                plankIndex.Add(position, planksAtCurrentPositon);
            }

            return plankIndex;
        }


        public int Solution2(int[] A, int[] B, int[] C)
        {
            return 0;
        }
    }
}
