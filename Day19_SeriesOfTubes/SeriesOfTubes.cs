using System;
using System.Text;
using Shared;

namespace Day19_SeriesOfTubes
{
    public class SeriesOfTubes : PuzzleSolver<SeriesOfTubesInput>
    {
        private (int Row, int Column) _coordinates;
        private Direction _direction = Direction.Down;
        private StringBuilder _visitedLetters = new StringBuilder();
        private readonly bool _letters;

        public SeriesOfTubes(bool letters)
        {
            _letters = letters;
        }

        protected override IPuzzleSolution SolveInternal(SeriesOfTubesInput input)
        {
            _coordinates = FindStartingPoint(input.RoutingDiagram);
            var count = 0;
            while (Move(input.RoutingDiagram))
            {
                count++;
            }

            return _letters
                ? new SeriesOfTubesSolution(_visitedLetters.ToString()) as IPuzzleSolution
                : new SeriesOfTubesCountSolution(count) as IPuzzleSolution;
        }

        private bool Move(RoutingCell[,] routingDiagram)
        {
            var moveResult = routingDiagram[_coordinates.Row, _coordinates.Column].Move(_coordinates, _direction, routingDiagram, _visitedLetters);
            _coordinates = moveResult.Coordinates;
            _direction = moveResult.NewDirection;
            return moveResult.CanMove;
        }

        private (int Row, int Column) FindStartingPoint(RoutingCell[,] routingDiagram)
        {
            for (var i = 1; i <= routingDiagram.GetLength(1) - 2; i++)
            {
                if (routingDiagram[1, i] is VerticalMove)
                {
                    return (1, i);
                }
            }

            throw new Exception("Wrong input.");
        }
    }
}
