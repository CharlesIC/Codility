using System;
using System.Collections.Generic;

namespace Practice
{
    public class FibFrog
    {
        public int[] solution(int[] A)
        {
            var positionBegin = -1;
            var positionEnd = A.Length;
            var pathLength = positionEnd - positionBegin;

            var fibonacci = GetFibonacciSequence(A.Length + 1);

            return null;
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
    }
}

