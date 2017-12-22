using Shared;

namespace Day22_SporificaVirus
{
    public class SporificaVirus : PuzzleSolver<SporificaVirusInput>
    {
        private readonly int _numberOfBursts = 10000;
        private readonly bool _complex;

        public SporificaVirus(bool complex)
        {
            _numberOfBursts = complex ? 10_000_000 : 10_000;
            _complex = complex;
        }

        protected override IPuzzleSolution SolveInternal(SporificaVirusInput input)
        {
            var countOfInfections = 0;
            for (int i = 0; i < _numberOfBursts; i++)
            {
                switch (input.Map.Current)
                {
                    case State.Clean:
                        input.Map.Direction = input.Map.Direction.TurnLeft();
                        break;
                    case State.Weakened:
                        break;
                    case State.Infected:
                        input.Map.Direction = input.Map.Direction.TurnRight();
                        break;
                    case State.Flagged:
                        input.Map.Direction = input.Map.Direction.TurnAround();
                        break;
                }

                input.Map.ChangeState(_complex);
                countOfInfections += input.Map.Current == State.Infected ? 1 : 0;
                input.Map.Position.Move(input.Map.Direction);
            }

            return new SporificaVirusSolution(countOfInfections);
        }
    }
}
