using System;
using System.Text;

namespace Day19_SeriesOfTubes
{
    internal class Junction : RoutingCell
    {
        internal override (bool CanMove, (int Row, int Column) Coordinates, Direction NewDirection) Move((int Row, int Column) coordinates, Direction direction, RoutingCell[,] routingDiagram, StringBuilder visitedLetters)
        {
            switch (direction)
            {
                case Direction.Down:
                case Direction.Up:
                    return ChangeDirectionFromVertical(routingDiagram, coordinates, direction);
                case Direction.Left:
                case Direction.Right:
                    return ChangeDirectionFromHorizontal(routingDiagram, coordinates, direction);
                default:
                    throw new Exception("Wrong input");
            }
        }

        private (bool CanMove, (int Row, int Column) Coordinates, Direction NewDirection) ChangeDirectionFromVertical(
            RoutingCell[,] routingDiagram,
            (int Row, int Column) coordinates,
            Direction direction)
        {
            var left = GetLeft(routingDiagram, coordinates);
            var right = GetRight(routingDiagram, coordinates);

            if (left is Empty && right is Empty)
            {
                return (false, coordinates, direction);
            }

            if (left is Empty)
            {
                return (true, (coordinates.Row, coordinates.Column + 1), Direction.Right);
            }

            return (true, (coordinates.Row, coordinates.Column - 1), Direction.Left);
        }

        private (bool CanMove, (int Row, int Column) Coordinates, Direction NewDirection) ChangeDirectionFromHorizontal(
            RoutingCell[,] routingDiagram,
            (int Row, int Column) coordinates,
            Direction direction)
        {
            var up = GetUp(routingDiagram, coordinates);
            var down = GetDown(routingDiagram, coordinates);

            if (up is Empty && down is Empty)
            {
                return (false, coordinates, direction);
            }

            if (up is Empty)
            {
                return (true, (coordinates.Row + 1, coordinates.Column), Direction.Down);
            }

            return (true, (coordinates.Row - 1, coordinates.Column), Direction.Up);
        }

        private RoutingCell GetLeft(RoutingCell[,] routingDiagram, (int Row, int Column) coordinates)
        {
            return routingDiagram[coordinates.Row, coordinates.Column - 1];
        }

        private RoutingCell GetRight(RoutingCell[,] routingDiagram, (int Row, int Column) coordinates)
        {
            return routingDiagram[coordinates.Row, coordinates.Column + 1];
        }

        private RoutingCell GetUp(RoutingCell[,] routingDiagram, (int Row, int Column) coordinates)
        {
            return routingDiagram[coordinates.Row - 1, coordinates.Column];
        }

        private RoutingCell GetDown(RoutingCell[,] routingDiagram, (int Row, int Column) coordinates)
        {
            return routingDiagram[coordinates.Row + 1, coordinates.Column];

        }
    }
}