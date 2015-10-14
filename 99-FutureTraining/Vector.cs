using System;

namespace Codility
{
    public class Vector
    {
        #region Fields

        private readonly string name;

        private double x;

        private double y;

        #endregion

        #region Constructors

        public Vector(Point2D tail, Point2D head, string name)
        {
            this.name = name;

            x = head.x - tail.x;
            y = head.y - tail.y;
        }

        public Vector(Point2D tail, Point2D head)
            : this(tail, head, "V")
        {
        }

        #endregion

        #region Public Properties

        public double X
        {
            get
            {
                return x;
            }
        }

        public double Y
        {
            get
            {
                return y;
            }
        }

        public double Direction
        {
            get
            {
                return GetDirection();
            }
        }

        public double Magnitude
        {
            get
            {
                return GetMagnitude();
            }
        }

        #endregion

        #region Public Methods

        public void Normalise()
        {
            var m = Magnitude;

            x /= m;
            y /= m;
        }

        public void InvertDirection()
        {
            x *= -1;
            y *= -1;
        }

        public double AngleOfRotationRelativeToThis(Vector v2, bool degrees = false)
        {
            var angle = Math.Atan2(v2.y, v2.x) - Math.Atan2(y, x);

            if (angle < 0)
            {
                angle += 2 * Math.PI;
            }

            return degrees ? RadToDeg(angle) : angle;
        }

        public override string ToString()
        {
            return string.Format(
                "({0} : Δx = {1,7:N3}, Δy = {2,7:N3}, m = {3:N2}, α = {4,6:N2}°)",
                name, x, y, Magnitude, RadToDeg(Direction));
        }

        #endregion

        #region Methods

        private static double RadToDeg(double angle)
        {
            return angle * 180 / Math.PI;
        }

        private static double DegToRad(double angle)
        {
            return angle * Math.PI / 180;
        }

        private double GetDirection()
        {
            var angle = Math.Atan2(y, x);
            return angle >= 0 ? angle : 2 * Math.PI + angle;
        }

        private double GetMagnitude()
        {
            return Math.Sqrt(x * x + y * y);
        }

        #endregion
    }
}
