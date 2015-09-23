using System;
using System.Linq;
using System.Collections.Generic;

namespace Codility
{
    public class MaxNonoverlappingSegments
    {
        public int solution(int[] A, int[] B)
        {
            var startPositions = new Dictionary<int, List<int>>();
            var endPositions = new Dictionary<int, List<int>>();

            for (int i = 0; i < A.Length; i++)
            {
                if (!startPositions.ContainsKey(A[i]))
                {
                    startPositions.Add(A[i], new List<int>());
                }

                if (!endPositions.ContainsKey(B[i]))
                {
                    endPositions.Add(B[i], new List<int>());
                }

                startPositions[A[i]].Add(i);
                endPositions[B[i]].Add(i);
            }

            var overlaps = new Dictionary<int, int>();

            var pool = new List<int>();
            var start = A.Min();
            for (int i = 0; i < B.Length; i++)
            {
                var newSticks = new List<int>();
                var sticksEnding = new HashSet<int> { i };

                // Get to the end of next stic
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
    }
}
