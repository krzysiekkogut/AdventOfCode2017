using Shared;
using System;
using System.Linq;

namespace Day05_Trampolines
{
    public class TrampolinesInput : IPuzzleInput<TrampolinesInput>
    {
        public int[] Instructions { get; set; }

        public TrampolinesInput ParseFromText(string textInput)
        {
            Instructions = textInput.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(instructionText => int.Parse(instructionText)).ToArray();
            return this;
        }
    }
}