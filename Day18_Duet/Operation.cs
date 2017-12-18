using System.Collections.Generic;

namespace Day18_Duet
{
    internal abstract class Operation
    {
        protected const string LastPlayedSoundRegisterName = "sound";

        public abstract (int NextIndex, long? Solution) Perform(IDictionary<string, long> registers, int currentOperationIndex);

        public virtual int Perform(IDictionary<string, long> registers, int currentOperationIndex, Queue<long> queue, Queue<long> otherProgramQueue)
        {
            return Perform(registers, currentOperationIndex).NextIndex;
        }

        protected long GetValue(IDictionary<string, long> registers, string valueText)
        {
            return long.TryParse(valueText, out long x) ? x : registers[valueText];
        }
    }
}