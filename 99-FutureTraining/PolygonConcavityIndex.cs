using System;
using System.Linq;

namespace Codility
{
    public class PolygonConcavityIndex
    {
        public int solution(Point2D[] A)
        {
            // All angles are acute in a triangle
            if (A.Length <= 3)
            {
                return -1;
            }

            var n = A.Length;
            var leftMostIdx = 0;
            for (int i = 0; i < n; i++)
            {
                if (A[i].x < A[leftMostIdx].x)
                {
                    leftMostIdx = i;
                }
                else if (A[i].x == A[leftMostIdx].x)
                {
                    if (A[leftMostIdx].x == A[(leftMostIdx + 1) % n].x)
                    {
                        leftMostIdx = i;
                    }
                }
            }

            var leftMost = A[leftMostIdx];
            var next = A[(leftMostIdx + 1) % n];
            var previous = A[(leftMostIdx - 1 + n) % n];

            var previousEdge = new Vector(previous, leftMost);
            var nextEdge = new Vector(leftMost, next);

            var clockwise = previousEdge.AngleOfRotationRelativeTo(nextEdge, clockwise: true, degrees: true) < 180;

            for (int i = 0; i < n; i++)
            {
                var vertex1 = (i + leftMostIdx) % n;
                var vertex2 = (vertex1 + 1) % n;
                var vertex3 = (vertex2 + 1) % n;

                var edge1 = new Vector(A[vertex1], A[vertex2]);
                var edge2 = new Vector(A[vertex2], A[vertex3]);

                var angle = edge1.AngleOfRotationRelativeTo(edge2, clockwise, degrees: true);

                if (angle > 180)
                {
                    return vertex2;
                }
            }

            return -1;
        }
    }
}
