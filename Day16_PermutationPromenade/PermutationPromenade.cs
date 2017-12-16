using Shared;
using System.Collections.Generic;

namespace Day16_PermutationPromenade
{
    public class PermutationPromenade : PuzzleSolver<PermutationPromenadeInput>
    {
        private const int NumberOfPrograms = 16;
        private readonly int _numberOfDances;
        private char[] _programs;

        public PermutationPromenade(bool oneDance)
        {
            _programs = new char[NumberOfPrograms];
            var character = 'a';
            for (var i = 0; i < NumberOfPrograms; i++)
            {
                _programs[i] = character;
                character++;
            }

            _numberOfDances = oneDance ? 1 : 1_000_000_000;
        }

        protected override PuzzleSolution SolveInternal(PermutationPromenadeInput input)
        {
            if (_numberOfDances == 1)
            {
                Dance(input.DanceMoves);
                return new PermutationPromenadeSolution(string.Concat(_programs));
            }

            var cycleLength = 0;
            do
            {
                cycleLength++;
                Dance(input.DanceMoves);
            } while (!IsInitialState());

            var dancesToPerform = _numberOfDances % cycleLength;
            for (int i = 0; i < dancesToPerform; i++)
            {
                Dance(input.DanceMoves);
            }

            return new PermutationPromenadeSolution(string.Concat(_programs));
        }

        private void Dance(IEnumerable<DanceMove> danceMoves)
        {
            foreach (var danceMove in danceMoves)
            {
                danceMove.MoveOn(_programs);
            }
        }

        private bool IsInitialState()
        {
            for (int i = 0; i < NumberOfPrograms - 1; i++)
            {
                if (_programs[i] > _programs[i + 1])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
