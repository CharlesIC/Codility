using System;

namespace Codility
{
	public class EquiLeader
	{
		public int Solution(int[] A)
		{
			var leaderIndex = new Dominator().Solution2(A);

			if (leaderIndex == -1) {
				return 0;
			}

			var leader = A[leaderIndex];
			var leaderCount = Array.FindAll(A, x => x == leader).Length;

			var equiLeaders = 0;
			var leaderCountSoFar = 0;

			for (int i = 0; i < A.Length; i++) {
				if (A[i] == leader) {
					leaderCountSoFar++;
				}
				if (leaderCountSoFar > (i + 1) / 2 &&
				    leaderCount - leaderCountSoFar > (A.Length - i - 1) / 2) {
					equiLeaders++;
				}
			}

			return equiLeaders;
		}
	}
}

