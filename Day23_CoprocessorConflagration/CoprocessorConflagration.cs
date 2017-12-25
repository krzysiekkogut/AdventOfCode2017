using Shared;
using System;
using System.Collections.Generic;

namespace Day23_CoprocessorConflagration
{
    public class CoprocessorConflagration : PuzzleSolver<CoprocessorConflagrationInput>
    {
        private readonly bool _debugMode;

        public CoprocessorConflagration(bool debugMode)
        {
            _debugMode = debugMode;
        }

        protected override IPuzzleSolution SolveInternal(CoprocessorConflagrationInput input)
        {
            return new CoprocessorConflagrationSolution(_debugMode ? CountMultiplications(input.Operations) : FindValueOfLastRegister());
        }

        private long CountMultiplications(Operation[] operations)
        {
            var registers = new Dictionary<string, long>();
            for (char c = 'a'; c <= 'h'; c++)
            {
                registers.Add(c.ToString(), 0);
            }

            var currentOperationIndex = 0;
            var multilplicationsCount = 0;
            while (currentOperationIndex >= 0 && currentOperationIndex < operations.Length)
            {
                if (operations[currentOperationIndex] is Multiplicate)
                {
                    multilplicationsCount++;
                }

                currentOperationIndex =
                    operations[currentOperationIndex]
                    .Perform(registers, currentOperationIndex);
            }

            return multilplicationsCount;
        }

        private long FindValueOfLastRegister()
        {
            // rewritten and optimized code from assembunny to C#
            var nonPrimeCount = 0;

            for (var i = 106500; i <= 123500; i += 17)
            {
                if (!IsPrime(i))
                {
                    nonPrimeCount++;
                }
            }

            return nonPrimeCount;
        }

        private bool IsPrime(int a)
        {
            var arr = new bool[a + 1];
            arr[0] = arr[1] = false;
            for (int i = 2; i <= a; i++)
            {
                arr[i] = true;
            }

            for (int i = 2; i * i <= a; i++)
            {
                if (arr[i])
                {
                    for (int j = 2 * i; j <= a; j += i)
                    {
                        arr[j] = false;
                    }
                }
            }

            return arr[a];
        }
    }
}
