using System;
using System.Collections.Generic;

namespace Day18_Duet
{
    internal class Send : Operation
    {
        private string _value;

        public Send(string value)
        {
            _value = value;
        }

        public override (int NextIndex, long? Solution) Perform(IDictionary<string, long> registers, int currentOperationIndex)
        {
            throw new NotSupportedException();
        }

        public override int Perform(IDictionary<string, long> registers, int currentOperationIndex, Queue<long> queue, Queue<long> otherProgramQueue)
        {
            otherProgramQueue.Enqueue(GetValue(registers, _value));
            return currentOperationIndex + 1;
        }
    }
}