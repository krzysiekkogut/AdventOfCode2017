using Shared;

namespace Day15_DuelingGenerators
{
    public class DuelingGenerators : PuzzleSolver<DuelingGeneratorsInput>
    {
        private const int TrialNumber = 40000000;
        private const int FactorA = 16807;
        private const int FactorB = 48271;
        private const long Mod = 2147483647;
        private const int Last16BitsOperand = 0xffff;

        protected override PuzzleSolution SolveInternal(DuelingGeneratorsInput input)
        {
            var count = 0;
            long a = input.InititalValueA;
            long b = input.InititalValueB;
            for (int i = 0; i < TrialNumber; i++)
            {
                a *= FactorA;
                a %= Mod;
                b *= FactorB;
                b %= Mod;

                if ((a & Last16BitsOperand) == (b & Last16BitsOperand))
                {
                    count++;
                }
            }

            return new DuelingGeneratorsSolution(count);
        }
    }
}
