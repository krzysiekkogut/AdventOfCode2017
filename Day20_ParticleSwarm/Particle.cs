namespace Day20_ParticleSwarm
{
    public class Particle
    {
        internal Point Position { get; set; }
        internal Point Velocity { get; set; }
        internal Point Acceleration { get; set; }

        internal void Move()
        {
            Velocity.X += Acceleration.X;
            Velocity.Y += Acceleration.Y;
            Velocity.Z += Acceleration.Z;

            Position.X += Velocity.X;
            Position.Y += Velocity.Y;
            Position.Z += Velocity.Z;
        }
    }
}