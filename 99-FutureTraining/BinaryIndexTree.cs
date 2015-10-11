using System;
using System.Linq;

namespace Codility
{
    public class BinaryIndexTree
    {
        #region Fields

        private readonly int[] tree;
        private int max;

        #endregion

        #region Constructors

        public BinaryIndexTree(int maxVal)
        {
            max = maxVal;
            tree = new int[max + 1];
        }

        public BinaryIndexTree(int[] arr)
        {
            max = arr.Max();
            tree = new int[max + 1];

            foreach (var num in arr)
            {
                Update(num, 1);
            }
        }

        #endregion

        #region Public Methods

        public int ReadSingle(int idx)
        {
            int sum = tree[idx];

            if (idx > 0)
            {
                int z = idx - (idx & -idx);

                idx--;
                while (idx != z)
                {
                    sum -= tree[idx];
                    idx -= (idx & -idx);
                }
            }

            return sum;
        }

        public int ReadCumulative(int idx)
        {
            int sum = 0;
            while (idx > 0)
            {
                sum += tree[idx];
                idx -= (idx & -idx);
            }

            return sum;
        }

        public int FindCumulativeFrequency(int f)
        {
            int idx = 0;

            var shift = (int)(Math.Log(f) / Math.Log(2));
            var mask = 1 << shift;

            while (mask != 0 && idx < max)
            {
                var idxMid = mask + idx;

                if (f == tree[idxMid])
                {
                    return idxMid;
                }
                else if (f > tree[idxMid])
                {
                    idx = idxMid;
                    f -= tree[idxMid];
                }

                mask >>= 1;
            }

            if (f != 0)
            {
                return -1;
            }

            return idx;
        }

        public int FindGreatestCumulativeFrequency(int f)
        {
            int idx = 0;

            var shift = (int)(Math.Log(f) / Math.Log(2));
            var mask = 1 << shift;

            while (mask != 0 && idx < max)
            {
                int idxMid = mask + idx;

                if (f >= tree[idxMid])
                {
                    idx = idxMid;
                    f -= tree[idxMid];
                }

                mask >>= 1;
            }

            if (f != 0)
            {
                return -1;
            }

            return idx;
        }

        public void Scale(int c)
        {
            for (int i = 1; i <= max; i++)
            {
                tree[i] /= c;
            }
        }

        public void PrintTree()
        {
            Console.WriteLine();

            foreach (var f in tree)
            {
                Console.Write("{0} ", f);
            }

            Console.WriteLine();
        }

        public void Update(int idx)
        {
            Update(idx, 1);
        }

        #endregion

        #region Methods

        private void Update(int idx, int val)
        {
            while (idx <= max)
            {
                tree[idx] += val;
                idx += (idx & -idx);
            }
        }

        #endregion
    }
}
