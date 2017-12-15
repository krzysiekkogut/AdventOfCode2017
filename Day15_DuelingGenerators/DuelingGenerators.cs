using Shared;
using System.Collections.Generic;
using System.Linq;

namespace Day15_DuelingGenerators
{
    public class DuelingGenerators : PuzzleSolver<DuelingGeneratorsInput>
    {
        private const int FactorA = 16807;
        private const int FactorB = 48271;
        private const long Mod = 2147483647;
        private const int Last16BitsOperand = 0xffff;
        private readonly bool _additionalCriteria;
        private readonly int _comparisonsCount;

        public DuelingGenerators(bool additionalCriteria)
        {
            _additionalCriteria = additionalCriteria;
            _comparisonsCount = additionalCriteria ? 5_000_000 : 40_000_000;
        }

        protected override PuzzleSolution SolveInternal(DuelingGeneratorsInput input)
        {
            var count = 0;
            var compareCount = 0;

            long a = input.InititalValueA;
            var queueA = new Queue<long>();

            long b = input.InititalValueB;
            var queueB = new Queue<long>();

            while (compareCount < _comparisonsCount)
            {
                a *= FactorA;
                a %= Mod;
                if (a % 4 == 0)
                {
                    queueA.Enqueue(a);
                }

                b *= FactorB;
                b %= Mod;
                if (b % 8 == 0)
                {
                    queueB.Enqueue(b);
                }

                if (_additionalCriteria && queueA.Any() && queueB.Any())
                {
                    compareCount++;
                    count += AreLast16BitsEqual(queueA.Dequeue(), queueB.Dequeue()) ? 1 : 0;
                }
                else if(!_additionalCriteria)
                {
                    compareCount++;
                    count += AreLast16BitsEqual(a, b) ? 1 : 0;
                }
            }

            return new DuelingGeneratorsSolution(count);
        }

        private bool AreLast16BitsEqual(long a, long b)
        {
            return (a & Last16BitsOperand) == (b & Last16BitsOperand);
        }
    }
}
