using Shared;
using System.Collections.Generic;

namespace Day20_ParticleSwarm
{
    public class ParticleSwarm : PuzzleSolver<ParticleSwarmInput>
    {
        protected override IPuzzleSolution SolveInternal(ParticleSwarmInput input)
        {
            var minAcceleration = long.MaxValue;
            var particlesWithLowestAcceleration = new List<int>();
            for (var i = 0; i < input.Particles.Length; i++)
            {
                if (input.Particles[i].Acceleration.Distance == minAcceleration)
                {
                    particlesWithLowestAcceleration.Add(i);
                }

                if (input.Particles[i].Acceleration.Distance < minAcceleration)
                {
                    minAcceleration = input.Particles[i].Acceleration.Distance;
                    particlesWithLowestAcceleration.Clear();
                    particlesWithLowestAcceleration.Add(i);
                }
            }

            var minVelocity = long.MaxValue;
            var particleWithLowestVelocity = -1;
            foreach (var particleIndex in particlesWithLowestAcceleration)
            {
                if (input.Particles[particleIndex].Velocity.Distance < minVelocity)
                {
                    minVelocity = input.Particles[particleIndex].Velocity.Distance;
                    particleWithLowestVelocity = particleIndex;
                }
            }

            return new ParticleSwarmSolution(particleWithLowestVelocity);
        }
    }
}
