using Shared;
using System.Collections.Generic;

namespace Day25_TheHaltingProblem
{
    public class TheHaltingProblem : PuzzleSolver<TheHaltingProblemInput>
    {
        protected override IPuzzleSolution SolveInternal(TheHaltingProblemInput input)
        {
            var registers = new HashSet<int>();
            var currentPosition = 0;
            for (var i = 0; i < input.Steps; i++)
            {
                var currentValue = registers.Contains(currentPosition);
                var stateChangeDef = currentValue
                    ? input.StateChangeDefinitions[input.CurrentState].ChangeFrom1
                    : input.StateChangeDefinitions[input.CurrentState].ChangeFrom0;

                if (stateChangeDef.NewValue && !currentValue)
                {
                    registers.Add(currentPosition);
                }
                else if (!stateChangeDef.NewValue && currentValue)
                {
                    registers.Remove(currentPosition);
                }
                currentPosition += stateChangeDef.Move == Move.Forward ? 1 : -1;
                input.CurrentState = stateChangeDef.NextState;
            }

            return new TheHaltingProblemSolution(registers.Count);
        }
    }
}
