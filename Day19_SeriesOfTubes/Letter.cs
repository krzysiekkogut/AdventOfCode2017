using System.Text;

namespace Day19_SeriesOfTubes
{
    internal class Letter : RoutingCell
    {
        public Letter(char c)
        {
            Value = c;
        }

        public char Value { get; }

        internal override (bool CanMove, (int Row, int Column) Coordinates, Direction NewDirection) Move(
            (int Row, int Column) coordinates,
            Direction direction,
            RoutingCell[,] routingDiagram,
            StringBuilder visitedLetters)
        {
            visitedLetters.Append(Value);
            return base.Move(coordinates, direction, routingDiagram, visitedLetters);
        }
    }
}