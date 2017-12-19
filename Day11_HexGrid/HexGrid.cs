using Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Day11_HexGrid
{
    public class HexGrid : PuzzleSolver<HexGridInput>
    {
        private readonly bool _showMaxSteps;
        private readonly Dictionary<Step, int> _distances;

        public HexGrid(bool showMaxSteps)
        {
            _showMaxSteps = showMaxSteps;
            _distances = new Dictionary<Step, int>
            {
                [Step.North] = 0,
                [Step.NorthEast] = 0,
                [Step.NorthWest] = 0,
                [Step.South] = 0,
                [Step.SouthEast] = 0,
                [Step.SouthWest] = 0
            };
        }

        protected override IPuzzleSolution SolveInternal(HexGridInput input)
        {
            var maxDistance = 0;
            var distanceToStart = 0;

            var dict = input.Steps.Distinct().ToDictionary(step => step, step => input.Steps.Count(s => s == step));

            foreach (var step in input.Steps)
            {
                _distances[step]++;
                distanceToStart = NormalizeDistancesAndReturnCurrentDistanceFromStart();
                if (distanceToStart > maxDistance)
                {
                    maxDistance = distanceToStart;
                }
            }

            return new HexGridSolution((DistanceToStart: distanceToStart, MaxSteps: maxDistance), _showMaxSteps);
        }

        private int NormalizeDistancesAndReturnCurrentDistanceFromStart()
        {
            NormalizeByDirections(Step.North, Step.South);
            NormalizeByDirections(Step.NorthEast, Step.SouthWest);
            NormalizeByDirections(Step.NorthWest, Step.SouthEast);

            NormalizeSkewDirections(Step.North, Step.SouthEast, Step.NorthEast);
            NormalizeSkewDirections(Step.North, Step.SouthWest, Step.NorthWest);
            NormalizeSkewDirections(Step.South, Step.NorthEast, Step.SouthEast);
            NormalizeSkewDirections(Step.South, Step.NorthWest, Step.SouthWest);
            NormalizeSkewDirections(Step.NorthWest, Step.NorthEast, Step.North);
            NormalizeSkewDirections(Step.SouthWest, Step.SouthEast, Step.South);

            return _distances.Sum(d => d.Value);
        }

        private void NormalizeByDirections(Step direction, Step otherDirection)
        {
            if (_distances[direction] > _distances[otherDirection])
            {
                _distances[direction] -= _distances[otherDirection];
                _distances[otherDirection] = 0;
            }
            else
            {
                _distances[otherDirection] -= _distances[direction];
                _distances[direction] = 0;
            }
        }

        private void NormalizeSkewDirections(Step direction, Step secondDirection, Step resultDirection)
        {
            var minDistance = Math.Min(_distances[direction], _distances[secondDirection]);
            _distances[direction] -= minDistance;
            _distances[secondDirection] -= minDistance;
            _distances[resultDirection] += minDistance;
        }
    }
}
