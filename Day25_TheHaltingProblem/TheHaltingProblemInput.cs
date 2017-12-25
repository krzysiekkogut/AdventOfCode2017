using Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Day25_TheHaltingProblem
{
    public class TheHaltingProblemInput : IPuzzleInput<TheHaltingProblemInput>
    {
        public char CurrentState { get; set; }
        public int Steps { get; set; }
        public IDictionary<char, StateChangeDefinition> StateChangeDefinitions { get; set; } = new Dictionary<char, StateChangeDefinition>();

        public TheHaltingProblemInput ParseFromText(string textInput)
        {
            var inputLines = textInput.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            CurrentState = inputLines[0][inputLines[0].Length - 2];
            var lineWithSteps = inputLines[1].Split(' ');
            Steps = int.Parse(lineWithSteps[lineWithSteps.Length - 2]);

            var stateChangesDefinitionsCount = inputLines.Count(line => line.StartsWith("In state "));
            for (var i = 0; i < stateChangesDefinitionsCount; i++)
            {
                var stateChangeDefinition = StateChangeDefinition.Parse(inputLines.Skip(2 + i * 9).Take(9).ToArray());
                StateChangeDefinitions.Add(stateChangeDefinition.Name, stateChangeDefinition);
            }

            return this;
        }
    }
}