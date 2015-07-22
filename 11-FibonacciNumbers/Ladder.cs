using System.Linq;

namespace Codility
{
    public class Ladder
    {
        public int[] Solution(int[] A, int[] B)
        {
            var combinations = new int[A.Length];
            var fibonacci = this.GetFibonacciSequence(A.Max(), B.Max());

            for (var i = 0; i < A.Length; i++)
            {
                var a = fibonacci[A[i] + 1];
                var b = (1 << B[i]) - 1;

                combinations[i] = a & b;
            }

            return combinations;
        }

        private int[] GetFibonacciSequence(int n, int modPower)
        {
            var mod = (1 << modPower) - 1;
            var fibonacci = new int[n + 2];
            fibonacci[1] = 1;

            for (var i = 2; i < fibonacci.Length; i++)
            {
                fibonacci[i] = (fibonacci[i - 2] + fibonacci[i - 1]) & mod;
            }

            return fibonacci;
        }
    }
}
