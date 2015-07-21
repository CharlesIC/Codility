using System;

namespace Practice
{
    public class Ladder
    {
        public int[] Solution(int[] A, int[] B)
        {
            var count = new int[A.Length];
            var maxRungs = 0;

            foreach (var num in A)
            {
                maxRungs = Math.Max(maxRungs, num);
            }

            var fibonacci = GetFibonacciSequence(maxRungs);

            for (int i = 0; i < A.Length; i++)
            {
                var a = (int)fibonacci[A[i] + 1];
                var b = (1 << B[i]) - 1;

                count[i] = a & b;
            }

            return count;
        }

        private double[] GetFibonacciSequence(int n)
        {
            var fibonacci = new double[n + 2];
            fibonacci[1] = 1;

            for (int i = 2; i < fibonacci.Length; i++)
            {
                fibonacci[i] = fibonacci[i - 2] + fibonacci[i - 1];
            }

            return fibonacci;
        }
    }
}
