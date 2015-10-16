using System;

namespace Codility
{
    public class Vector
    {
        #region Fields

        private readonly string name;

        private bool isNomrmalised;

        private double x;

        private double y;

        #endregion

        #region Constructors

        public Vector(double x, double y, string name)
        {
            this.name = name;
            this.x = x;
            this.y = y;

            isNomrmalised = Magnitude.CompareTo(1) == 0;
        }

        public Vector(double x, double y)
            : this(x, y, "V")
        {
        }

        public Vector(Point2D tail, Point2D head, string name)
            : this(head.x - tail.x, head.y - tail.y, name)
        {
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

        public bool IsNormalised
        {
            get
            {
                return isNomrmalised;
            }
        }

        public Vector UnitVector
        {
            get
            {
                return GetUnitVector();
            }
        }

        #endregion

        #region Public Methods

        public void Normalise()
        {
            if (!isNomrmalised)
            {
                var m = Magnitude;

                x /= m;
                y /= m;   

                isNomrmalised = true;
            }
        }

        public void InvertDirection()
        {
            x *= -1;
            y *= -1;
        }

        public double AngleOfRotationRelativeTo(Vector otherVector, bool clockwise = true, bool degrees = false)
        {
            var v1 = clockwise ? otherVector.UnitVector : UnitVector;
            var v2 = clockwise ? UnitVector : otherVector.UnitVector;

            var angle = Math.Atan2(v2.y, v2.x) - Math.Atan2(v1.y, v1.x);

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

        private Vector GetUnitVector()
        {
            var m = Magnitude;
            return new Vector(x / m, y / m);
        }

        #endregion
    }
}
