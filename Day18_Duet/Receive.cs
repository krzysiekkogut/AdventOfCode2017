using System;
using System.Collections.Generic;

namespace Day18_Duet
{
    internal class Receive : Operation
    {
        private string _registerName;

        public Receive(string registerName)
        {
            _registerName = registerName;
        }

        public override (int NextIndex, long? Solution) Perform(IDictionary<string, long> registers, int currentOperationIndex)
        {
            throw new NotSupportedException();
        }

        public override int Perform(IDictionary<string, long> registers, int currentOperationIndex, Queue<long> queue, Queue<long> otherProgramQueue)
        {
            if (queue.Count == 0)
            {
                return currentOperationIndex;
            }

            registers[_registerName] = queue.Dequeue();
            return currentOperationIndex + 1;
        }
    }
}