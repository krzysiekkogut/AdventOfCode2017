using System;

namespace Day20_ParticleSwarm
{
    internal class Point
    {
        public Point(string text)
        {
            var split = text.Split(',');
            X = Convert.ToInt64(split[0]);
            Y = Convert.ToInt64(split[1]);
            Z = Convert.ToInt64(split[2]);
        }

        public long X { get; set; }
        public long Y { get; set; }
        public long Z { get; set; }

        public long Distance => Math.Abs(X) + Math.Abs(Y) + Math.Abs(Z);

        public override bool Equals(object obj)
        {
            if (obj is Point other)
            {
                return other.X == X && other.Y == Y && other.Z == Z;
            }

            return false;
        }
    }
}
