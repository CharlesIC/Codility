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
                var a = fibonacci[A[i] + 1];
                var b = Math.Pow(2, B[i]);

                count[i] = (int)(a - Math.Floor(a / b) * b);
            }

            // 8 4 2 1
            // 8 = 1000
            // 2 = 0010
            // 8 % 2 = 0;

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
