using System.Linq;
using Shared;

namespace Day20_ParticleSwarm
{
    public class ParticleSwarmSimulation : PuzzleSolver<ParticleSwarmInput>
    {
        protected override IPuzzleSolution SolveInternal(ParticleSwarmInput input)
        {
            for (int i = 0; i < 1000; i++)
            {
                MoveParticles(input.Particles);
                RemoveCollisions(input.Particles);
            }

            return new ParticleSwarmSolution(input.Particles.Count(p => p.Active));
        }

        private void MoveParticles(Particle[] particles)
        {
            foreach (var particle in particles)
            {
                particle.Move();
            }
        }

        private void RemoveCollisions(Particle[] particles)
        {
            for (var particleNumber = 0; particleNumber < particles.Length - 1; particleNumber++)
            {
                if (particles[particleNumber].Active)
                {
                    for (var otherParticleNumber = particleNumber + 1; otherParticleNumber < particles.Length; otherParticleNumber++)
                    {
                        if (particles[otherParticleNumber].Active)
                        {
                            if (particles[particleNumber].Position.Equals(particles[otherParticleNumber].Position))
                            {
                                particles[particleNumber].Active = false;
                                particles[otherParticleNumber].Active = false;
                            }
                        }
                    }
                }
            }
        }
    }
}
