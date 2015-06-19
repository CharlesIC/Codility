using System;

namespace Practice
{
    public class Nesting
    {
        public int Solution(string S)
        {
            var count = 0;

            foreach (var character in S) {
                if (character == '(') {
                    count++;
                } else if (count == 0) {
                    return 0;
                } else {
                    count--;
                }
            }

            if (count == 0) {
                return 1;
            } else {
                return 0;
            }
        }
    }
}

