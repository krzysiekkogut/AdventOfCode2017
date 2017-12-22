namespace Day22_SporificaVirus
{
    internal class Point
    {
        public Point(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public int Row { get; set; }
        public int Column { get; set; }

        internal void Move(Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    Row--;
                    break;
                case Direction.Down:
                    Row++;
                    break;
                case Direction.Left:
                    Column--;
                    break;
                case Direction.Right:
                    Column++;
                    break;
            }
        }
    }
}