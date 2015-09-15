using System;
using System.Linq;
using System.Collections.Generic;

namespace Practice
{
    public class NailingPlanksEfficient
    {
        public int Solution(int[] A, int[] B, int[] C)
        {
            var sortedNails = GetSortedNails(C);
            var result = -1;

            for (int i = 0; i < A.Length; i++)
            {
                result = FindFirstNailIndex(A[i], B[i], sortedNails, result);

                if (result == -1)
                {
                    return -1;
                }
            }

            return result + 1;
        }

        private int FindFirstNailIndex(int plankBegin, int plankEnd, IList<Nail> nailsInOrder, int preResult)
        {
            var firstNailOrder = GetFirstNailOrder(plankBegin, plankEnd, nailsInOrder);

            // Can't find a nail that could nail the plank
            if (firstNailOrder == -1)
            {
                return -1;
            }

            var bestNailIdx = FindBestNailForPlank(plankEnd, firstNailOrder, nailsInOrder, preResult);

            return bestNailIdx;
        }

        private int GetFirstNailOrder(int plankBegin, int plankEnd, IList<Nail> nailsInOrder)
        {
            var firstNailOrder = -1;

            var nailOrderLower = 0;
            var nailOrderUpper = nailsInOrder.Count - 1;
            var nailOrderMid = 0;

            // Search by position :: Find the first nail
            // which is between plankBegin and plankEnd
            // (i.e. has the lowest acceptable position)
            while (nailOrderLower <= nailOrderUpper)
            {
                nailOrderMid = (nailOrderLower + nailOrderUpper) / 2;
                var positionMid = nailsInOrder[nailOrderMid].Position;

                if (positionMid < plankBegin)
                {
                    nailOrderLower = nailOrderMid + 1;
                }
                else
                {
                    nailOrderUpper = nailOrderMid - 1;

                    if (positionMid <= plankEnd)
                    {
                        firstNailOrder = nailOrderMid;
                    }
                }
            }
                
            return firstNailOrder;
        }

        private int FindBestNailForPlank(int plankEnd, int firstNailOrder, IList<Nail> nailsInOrder, int preResult)
        {
            var bestNailIdx = nailsInOrder[firstNailOrder].Index;

            // Search by index :: Linearly search all qualifying
            // nails and find the one that is used the earliest
            // (i.e. has the lowest index)
            var nailOrder = firstNailOrder + 1;
            while (nailOrder < nailsInOrder.Count)
            {
                if (nailsInOrder[nailOrder].Position > plankEnd)
                {
                    break;
                }

                bestNailIdx = Math.Min(bestNailIdx, nailsInOrder[nailOrder].Index);

                nailOrder++;

                // The current result won't influence the overall result
                // because some other plank needs a nail used later than
                // the best nail for the current one
                if (preResult >= bestNailIdx)
                {
                    return preResult;
                }
            }

            return Math.Max(bestNailIdx, preResult);
        }

        private IList<Nail> GetSortedNails(int[] nails)
        {
            var nailIndex = new int[nails.Length];

            for (int i = 0; i < nails.Length; i++)
            {
                nailIndex[i] = i;
            }

            var nailCompare = Comparer<int>.Create(new Comparison<int>((x, y) =>
                    {
                        if (nails[x] == nails[y])
                        {
                            return x - y;
                        }
                        return nails[x] - nails[y];
                    }));

            Array.Sort(nailIndex, nailCompare);
            var sortedNails = nailIndex.Select(idx => new Nail { Index = idx, Position = nails[idx] }).ToList();

            return sortedNails;
        }

        private struct Nail
        {
            public int Index;
            public int Position;
        }
    }
}
