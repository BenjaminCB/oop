using System;

namespace hello_world
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Stars(5);
            STDINSqrt();
        }

        public static double ToRadians(double degrees)
        {
            double Radians = degrees * (Math.PI / 180),
                   Tau = 2 * Math.PI;

            while (Radians >= Tau) Radians -= Tau;

            return Radians;
        }

        public static double ToDegrees(double radians)
        {
            double Degrees = radians * (180 / Math.PI);

            while (Degrees >= 360) Degrees -= 360;

            return Degrees;
        }

        public static void Stars(int n)
        {
            string str = "";
            for (int i = 1; i <= n; i++)
            {
                str += '*';
                Console.WriteLine(str);
            }
        }

        public static void STDINSqrt()
        {
            Console.WriteLine( Math.Sqrt( double.Parse( Console.ReadLine() ) ) );
        }
    }
}
