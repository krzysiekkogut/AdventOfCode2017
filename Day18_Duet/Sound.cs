using System.Collections.Generic;

namespace Day18_Duet
{
    internal class Sound : Operation
    {
        public Sound(string value)
        {
            Value = value;
        }

        public string Value { get; }

        public override (int NextIndex, long? Solution) Perform(IDictionary<string, long> registers, int currentOperationIndex)
        {
            if (registers.ContainsKey(LastPlayedSoundRegisterName))
            {
                registers[LastPlayedSoundRegisterName] = GetValue(registers, Value);
            }
            else
            {
                registers.Add(LastPlayedSoundRegisterName, GetValue(registers, Value));
            }

            return (NextIndex: currentOperationIndex + 1,
                    Solution: null);
        }
    }
}