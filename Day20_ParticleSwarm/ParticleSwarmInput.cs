using Shared;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day20_ParticleSwarm
{
    public class ParticleSwarmInput : IPuzzleInput<ParticleSwarmInput>
    {
        public Particle[] Particles { get; set; }

        public ParticleSwarmInput ParseFromText(string textInput)
        {
            Particles = textInput
                .Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(particleText =>
                {
                    var regex = new Regex(@"p=<(-?\d+,-?\d+,-?\d+)>, v=<(-?\d+,-?\d+,-?\d+)>, a=<(-?\d+,-?\d+,-?\d+)>");
                    var match = regex.Match(particleText);

                    var particle = new Particle
                    {
                        Position = new Point(match.Groups[1].Value),
                        Velocity = new Point(match.Groups[2].Value),
                        Acceleration = new Point(match.Groups[3].Value)
                    };

                    return particle;
                })
                .ToArray();
            return this;
        }
    }
}