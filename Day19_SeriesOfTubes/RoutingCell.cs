using System.Text;

namespace Day19_SeriesOfTubes
{
    public abstract class RoutingCell
    {
        public static RoutingCell Create(char c)
        {
            switch (c)
            {
                case '|':
                    return new VerticalMove() as RoutingCell;
                case '-':
                    return new HorizontalMove() as RoutingCell;
                case '+':
                    return new Junction() as RoutingCell;
                case ' ':
                    return new Empty() as RoutingCell;
                default:
                    return new Letter(c) as RoutingCell;
            }
        }

        internal virtual (bool CanMove, (int Row, int Column) Coordinates, Direction NewDirection) Move(
            (int Row, int Column) coordinates,
            Direction direction,
            RoutingCell[,] routingDiagram,
            StringBuilder visitedLetters)
        {
            var row = coordinates.Row;
            var column = coordinates.Column;
            switch (direction)
            {
                case Direction.Down:
                    row++;
                    break;
                case Direction.Up:
                    row--;
                    break;
                case Direction.Left:
                    column--;
                    break;
                case Direction.Right:
                    column++;
                    break;
            }

            return (true, (row, column), direction);
        }
    }
}