using System;

namespace Codility
{
    public static class FibonacciNumbers
    {
        public static void PrintFibNumbers(int n)
        {
            var a = 1;
            var b = 1;

            Console.Write(a + " ");
            Console.Write(b + " ");

            for (int i = 2; i < n; i++)
            {
                var x = a + b;
                a = b;
                b = x;

                Console.Write("{0} ", x);
            }
        }

        public static int[] FibNumbners(int n)
        {
            var nums = new int[n];

            nums[0] = 1;
            nums[1] = 1;

            for (int i = 2; i < n; i++)
            {
                nums[i] = nums[i - 1] + nums[i - 2];
            }

            return nums;
        }
    }
}
