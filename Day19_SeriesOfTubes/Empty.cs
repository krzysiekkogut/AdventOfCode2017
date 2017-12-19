using System.Text;

namespace Day19_SeriesOfTubes
{
    internal class Empty : RoutingCell
    {
        internal override (bool CanMove, (int Row, int Column) Coordinates, Direction NewDirection) Move(
            (int Row, int Column) coordinates, 
            Direction direction, 
            RoutingCell[,] routingDiagram, 
            StringBuilder visitedLetters)
        {
            return (false, coordinates, direction);
        }
    }
}