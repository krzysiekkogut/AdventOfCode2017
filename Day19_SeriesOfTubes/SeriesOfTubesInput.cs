using Shared;
using System;

namespace Day19_SeriesOfTubes
{
    public class SeriesOfTubesInput : IPuzzleInput<SeriesOfTubesInput>
    {
        public RoutingCell[,] RoutingDiagram { get; set; }

        public SeriesOfTubesInput ParseFromText(string textInput)
        {
            var rows = textInput.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            var rowsCount = rows.Length;
            var columnsCount = rows[0].Length;
            RoutingDiagram = new RoutingCell[rowsCount + 2, columnsCount + 2];

            // empty first and last row 
            for (int i = 0; i < columnsCount + 2; i++)
            {
                RoutingDiagram[0, i] = RoutingCell.Create(' ');
                RoutingDiagram[rowsCount + 1, i] = RoutingCell.Create(' ');
            }

            // empty first and last column
            for (int i = 0; i < rowsCount + 2; i++)
            {
                RoutingDiagram[i, 0] = RoutingCell.Create(' ');
                RoutingDiagram[i, columnsCount + 1] = RoutingCell.Create(' ');
            }

            // set actual cells
            for (int i = 0; i < rowsCount; i++)
            {
                for (int j = 0; j < columnsCount; j++)
                {
                    RoutingDiagram[i + 1, j + 1] = RoutingCell.Create(rows[i][j]);
                }
            }

            return this;
        }
    }
}