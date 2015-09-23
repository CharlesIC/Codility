using System;
using System.Linq;
using System.Collections.Generic;

namespace Codility
{
    public class MaxNonoverlappingSegments
    {
        public int solution(int[] A, int[] B)
        {
            var startPositions = GetIndexedPositions(A);
           
            var overlaps = new Dictionary<int, int>();

            var pool = new List<int>();
            var start = A.Min();
            for (int i = 0; i < B.Length; i++)
            {
                var newSticks = new List<int>();
                var sticksEnding = new HashSet<int> { i };

                // Get to the end of next stick
                while (i < B.Length - 1 && B[i + 1] == B[i])
                {
                    sticksEnding.Add(i);
                    i++;
                }

                var end = B[i];

                // Add all new sticks up to this point to the pool
                for (int j = start; j <= end; j++)
                {
                    if (startPositions.ContainsKey(j))
                    {
                        newSticks.AddRange(startPositions[j]);
                    }
                }

                if (newSticks.Count > 0)
                {
                    pool.AddRange(newSticks);

                    // All sticks in the pool overlap with each other
                    foreach (var stick in pool)
                    {
                        if (!overlaps.ContainsKey(stick))
                        {
                            overlaps.Add(stick, -1);
                        }
                        
                        overlaps[stick] += newSticks.Count;
                    }
                }

                // Advance start position and remove sticks from pool
                start = end;

                foreach (var stick in sticksEnding)
                {
                    pool.Remove(stick);
                }
            }

            return -1;
        }

        public int solution2(int[] A, int[] B)
        {
            var result = 0;
            var sticksAtPosition = GetSticksAtPosition(A, B);

            var start = A.Min();
            var pool = new HashSet<int>();
            var excludedSticks = new HashSet<int>();

            for (int i = 0; i < B.Length; i++)
            {
                // Get to the end of next stick
                var sticksEnding = new HashSet<int> { B[i] };
                while (i < B.Length - 1 && B[i + 1] == B[i])
                {
                    i++;
                    sticksEnding.Add(i);
                }

                var currentPosition = B[i];

            }

            return -1;
        }

        private Dictionary<int, List<int>> GetIndexedPositions(int[] A)
        {
            var indexedPositions = new Dictionary<int, List<int>>();

            for (int i = 0; i < A.Length; i++)
            {
                if (!indexedPositions.ContainsKey(A[i]))
                {
                    indexedPositions.Add(A[i], new List<int>());
                }

                indexedPositions[A[i]].Add(i);
            }

            return indexedPositions;
        }

        private Dictionary<int, HashSet<int>> GetSticksAtPosition(int[] A, int[] B)
        {
            var n = A.Length;
            var innerCount = 0;
            var outerCount = 0;

            var sticksAtPosition = new Dictionary<int, HashSet<int>>();
            var pool = new HashSet<int>();

            for (int i = B.Length - 1; i >= 0; i--)
            {
                outerCount++;

                var currentPosition = B[i];
                var newPool = new HashSet<int>();
                pool.Add(i);

                if (!sticksAtPosition.ContainsKey(currentPosition))
                {
                    sticksAtPosition.Add(currentPosition, new HashSet<int>());   
                }

                foreach (var stick in pool)
                {
                    var startPosition = A[stick];

                    if (startPosition <= currentPosition)
                    {
                        sticksAtPosition[currentPosition].Add(stick);
                        newPool.Add(stick);
                    }

                    innerCount++;
                }

                pool = newPool;
            }

            return sticksAtPosition;
        }

        public int solution3(int[] A, int[] B)
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
