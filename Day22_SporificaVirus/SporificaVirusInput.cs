using Shared;
using System;

namespace Day22_SporificaVirus
{
    public class SporificaVirusInput : IPuzzleInput<SporificaVirusInput>
    {
        internal Map Map { get; set; } = new Map();

        public SporificaVirusInput ParseFromText(string textInput)
        {
            var mapRows = textInput.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < mapRows.Length; i++)
            {
                for (int j = 0; j < mapRows[i].Length; j++)
                {
                    Map.SetState(new Point(i, j), mapRows[i][j] == '#' ? State.Infected : State.Clean);
                }
            }

            Map.Position = new Point(mapRows.Length / 2, mapRows[0].Length / 2);
            Map.Direction = Direction.Up;
            return this;
        }
    }
}