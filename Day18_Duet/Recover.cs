using System.Collections.Generic;

namespace Day18_Duet
{
    internal class Recover : Operation
    {
        public Recover(string value)
        {
            Value = value;
        }

        public string Value { get; set; }

        public override (int NextIndex, long? Solution) Perform(IDictionary<string, long> registers, int currentOperationIndex)
        {
            if (GetValue(registers, Value) != 0)
            {
                return (NextIndex: currentOperationIndex + 1,
                        Solution: registers[LastPlayedSoundRegisterName]);
            }

            return (NextIndex: currentOperationIndex + 1, 
                    Solution: null);
        }
    }
}