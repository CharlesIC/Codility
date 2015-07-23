<<<<<<< Updated upstream
﻿using System;
using System.Linq;
using System.Collections.Generic;
>>>>>>> Stashed changes

namespace Codility
{
    public class FibFrog
    {
<<<<<<< Updated upstream
        public int[] Solution(int[] A)
>>>>>>> Stashed changes
        {
            const int Origin = -1;
            var destination = A.Length + 1;
            var fibonacci = GetFibonacciSequence(destination + 1);

            // Perform a breadth-first search on the array
            var queue = new Queue<Leaf>();
            queue.Enqueue(new Leaf { Position = Origin, Hops = 0 });

            while (queue.Count > 0)
            {
                var leaf = queue.Dequeue();
                var currentPosition = leaf.Position;
                var maxDistance = destination - currentPosition;

                foreach (var distance in fibonacci.Where(x => x <= maxDistance))
                {
                    var nextPosition = currentPosition + distance;

                    if (nextPosition == destination)
                    {
                        return leaf.Hops++;
                    }

                    if (A[nextPosition] == 1)
                    {
                        queue.Enqueue(new Leaf { Position = nextPosition, Hops = leaf.Hops++ });
                    }
                }
            }

            return -1;
        }

        private int[] GetFibonacciSequence(int max)
        {
            var fibonacci = new List<int>();
            fibonacci.AddRange(new[] { 0, 1 });

            var idx = 1;
            while (fibonacci[idx] < max)
            {
                idx++;
                fibonacci.Add(fibonacci[idx - 1] + fibonacci[idx - 2]);
            }

            return fibonacci.GetRange(0, idx).ToArray();
        }

        private struct Leaf
        {
            public int Position;
            public int Hops;
        }
    }
}
