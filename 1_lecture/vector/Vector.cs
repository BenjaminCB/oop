

namespace vector
{
    class Vector
    {
        public int X;
        public int Y;

        public Vector()
        {
            X = 0;
            Y = 0;
        }

        public Vector(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static Vector Add(Vector a, Vector b)
        {
            return new Vector(a.X + b.X, a.Y + b.Y);
        }

        public static Vector Sub(Vector a, Vector b)
        {
            return new Vector(a.X - b.X, a.Y - b.Y);
        }

        public static Vector Scale(Vector a, int b)
        {
            return new Vector(a.X * b, a.Y * b);
        }
    }
}
