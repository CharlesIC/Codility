using System;
using System.Collections.Generic;

namespace Codility
{
    public class StrSymmetryPoint
    {
        public int solution(string s)
        {
            var n = s.Length;

            if (n == 0 || n % 2 == 0)
            {
                return -1;
            }

            var middle = n / 2;
            var chars = new Stack<char>();

            for (int i = 0; i < middle; i++)
            {
                chars.Push(s[i]);
            }

            for (int i = middle + 1; i < s.Length; i++)
            {
                if (s[i] != chars.Pop())
                {
                    return -1;
                }
            }

            return middle;
        }

        // More memory efficient
        public int solution2(string s)
        {
            var n = s.Length;

            if (n == 0 || n % 2 == 0)
            {
                return -1;
            }

            var middle = n / 2;
            var head = n - 1;
            var tail = 0;

            while (head > tail)
            {
                if (s[head] != s[tail])
                {
                    return -1;
                }

                head--;
                tail++;
            }

            return middle;
        }
    }
}
