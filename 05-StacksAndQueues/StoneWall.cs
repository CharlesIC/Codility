namespace Codility
{
    public class StoneWall
    {
        public int Solution(int[] H)
        {
            var N = H.Length;
            var stones = 0;
            var stack = new int[N];
            var stack_num = 0;

            for (int i = 0; i < N; i++)
            {
                while (stack_num > 0 && stack[stack_num - 1] > H[i])
                {
                    stack_num--;
                }
                if (stack_num > 0 && stack[stack_num - 1] == H[i])
                {
                    continue;
                }
                else
                {
                    stones++;
                    stack[stack_num] = H[i];
                    stack_num++;
                }
            }

            return stones;
        }
    }
}