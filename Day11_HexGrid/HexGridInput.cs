using System;
using System.Collections.Generic;
using System.Linq;
using Shared;

namespace Day11_HexGrid
{
    public class HexGridInput : IPuzzleInput<HexGridInput>
    {
        internal IList<Step> Steps { get; set; }

        public HexGridInput ParseFromText(string textInput)
        {
            Steps = textInput.Split(',').Select(stepText =>
            {
                switch (stepText)
                {
                    case "n":
                        return Step.North;
                    case "ne":
                        return Step.NorthEast;
                    case "nw":
                        return Step.NorthWest;
                    case "s":
                        return Step.South;
                    case "se":
                        return Step.SouthEast;
                    case "sw":
                        return Step.SouthWest;
                    default:
                        throw new Exception("Wrong input");
                }
            }).ToList();
            return this;
        }
    }
}