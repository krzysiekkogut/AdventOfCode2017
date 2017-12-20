using System;
using System.Collections.Generic;
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

            return new ParticleSwarmSolution(input.Particles.Count);
        }

        private void MoveParticles(IDictionary<int, Particle> particles)
        {
            foreach (var particle in particles)
            {
                particle.Value.Move();
            }
        }

        private void RemoveCollisions(IDictionary<int, Particle> particles)
        {
            var particlesToRemove = new HashSet<int>();

            foreach (var particleNumber in particles.Keys.Where(p => !particlesToRemove.Contains(p)))
            {
                if (particlesToRemove.Contains(particleNumber))
                {
                    continue;
                }

                foreach (var otherParticleNumber in particles.Keys)
                {
                    if (otherParticleNumber <= particleNumber || particlesToRemove.Contains(particleNumber))
                    {
                        continue;
                    }

                    if (particles[particleNumber].Position.Equals(particles[otherParticleNumber].Position))
                    {
                        particlesToRemove.Add(particleNumber);
                        particlesToRemove.Add(otherParticleNumber);
                    }
                }
            }

            foreach (var particleNumber in particlesToRemove)
            {
                particles.Remove(particleNumber);
            }
        }
    }
}
