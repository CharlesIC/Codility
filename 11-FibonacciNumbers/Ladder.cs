using System;
using System.Linq;

namespace Practice
{
    public class Ladder
    {
        public int[] Solution(int[] A, int[] B)
        {
            var combinations = new int[A.Length];
            var fibonacci = GetFibonacciSequence(A.Max(), B.Max());

            for (int i = 0; i < A.Length; i++)
            {
                var a = (int)fibonacci[A[i] + 1];
                var b = (1 << B[i]) - 1;

                combinations[i] = a & b;
            }

            return combinations;
        }

        private double[] GetFibonacciSequence(int n, int modPower)
        {
            var mod = (1 << modPower) - 1;
            var fibonacci = new double[n + 2];
            fibonacci[1] = 1;

            for (int i = 2; i < fibonacci.Length; i++)
            {
                fibonacci[i] = (int)(fibonacci[i - 2] + fibonacci[i - 1]) & mod;
            }

            return fibonacci;
        }
    }
}
