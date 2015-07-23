using System.Collections.Generic;
using System.Linq;

namespace Codility
{
    public class FibFrog
    {
        public int Solution(int[] A)
        {
            const int Origin = -1;
            var destination = A.Length;
            var fibonacci = GetFibonacciSequence(destination + 1);

            // Perform a breadth-first search on the array
            var marked = new HashSet<int>();
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
                        return leaf.Hops + 1;
                    }

                    if (A[nextPosition] == 1 && !marked.Contains(nextPosition))
                    {
                        queue.Enqueue(new Leaf { Position = nextPosition, Hops = leaf.Hops + 1 });
                        marked.Add(nextPosition);
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
            while (fibonacci[idx] <= max)
            {
                idx++;
                fibonacci.Add(fibonacci[idx - 1] + fibonacci[idx - 2]);
            }

            return fibonacci.GetRange(2, idx - 2).ToArray();
        }

        private struct Leaf
        {
            public int Position;
            public int Hops;
        }
    }
}
