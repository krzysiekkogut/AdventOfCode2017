using Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Day18_Duet
{
    public class Duet : PuzzleSolver<DuetInput>
    {
        private readonly bool _programCommunication;

        public Duet(bool programCommunication)
        {
            _programCommunication = programCommunication;
        }

        protected override PuzzleSolution SolveInternal(DuetInput input)
        {
            return _programCommunication
                ? new DuetSolution(SolveProgramsDuet(ExchangeSoundRelatedOperations(input.Operations)))
                : new DuetSolution(SolveSoundDuet(input));
        }

        private static long SolveSoundDuet(DuetInput input)
        {
            var registers = PrepareRegisters();
            var currentOperationIndex = 0;
            while (true)
            {
                var operationResult =
                    input
                    .Operations[currentOperationIndex]
                    .Perform(registers, currentOperationIndex);
                currentOperationIndex = operationResult.NextIndex;
                if (operationResult.Solution.HasValue)
                {
                    return operationResult.Solution.Value;
                }
            }
        }

        private Operation[] ExchangeSoundRelatedOperations(Operation[] operations)
        {
            return operations
                .Select(op =>
                {
                    switch (op)
                    {
                        case Sound s:
                            return new Send(s.Value) as Operation;
                        case Recover r:
                            return new Receive(r.Value) as Operation;
                        default:
                            return op; ;
                    }
                })
                .ToArray();
        }

        private long SolveProgramsDuet(Operation[] operations)
        {
            var currentOperationIndexA = 0;
            var registersA = PrepareRegisters();
            registersA["p"] = 0;
            var queueA = new Queue<long>();

            var currentOperationIndexB = 0;
            var registersB = PrepareRegisters();
            registersB["p"] = 1;
            var queueB = new Queue<long>();
            var sendCountsB = 0;
            while (AreIndexesInRange(operations, currentOperationIndexA, currentOperationIndexB)
                && CanProgramsWork(operations, currentOperationIndexA, queueA, currentOperationIndexB, queueB))
            {
                currentOperationIndexA = operations[currentOperationIndexA].Perform(registersA, currentOperationIndexA, queueA, queueB);

                if (operations[currentOperationIndexB] is Send)
                {
                    sendCountsB++;
                }

                currentOperationIndexB = operations[currentOperationIndexB].Perform(registersB, currentOperationIndexB, queueB, queueA);
            }

            return sendCountsB;
        }

        private bool AreIndexesInRange(Operation[] operations, long indexA, long indexB)
        {
            if (indexA < 0 || indexA >= operations.Length)
            {
                return false;
            }

            if (indexB < 0 || indexB >= operations.Length)
            {
                return false;
            }

            return true;
        }

        private bool CanProgramsWork(Operation[] operations, int currentOperationIndexA, Queue<long> queueA, int currentOperationIndexB, Queue<long> queueB)
        {
            if (operations[currentOperationIndexA] is Receive
             && operations[currentOperationIndexB] is Receive
             && queueA.Count == 0
             && queueB.Count == 0)
            {
                return false;
            }

            return true;
        }

        private static IDictionary<string, long> PrepareRegisters()
        {
            var registers = new Dictionary<string, long>();
            for (char c = 'a'; c <= 'z'; c++)
            {
                registers.Add(c.ToString(), 0);
            }

            return registers;
        }
    }
}
