namespace TransmitterCalculator
{
    public struct PointD
    {
        public double X { get; set; }
        public double Y { get; set; }

        public PointD(double x, double y)
        {
            X = x;
            Y = y;
        }

        public override bool Equals(object obj)
        {
            if (obj is PointD)
            {
                var point = (PointD)obj;
                return point.X == X && point.Y == Y;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode();
        }

        public static bool operator ==(PointD left, PointD right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(PointD left, PointD right)
        {
            return !(left == right);
        }
    }
}
