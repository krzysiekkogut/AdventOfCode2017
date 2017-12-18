using System.Collections.Generic;

namespace Day18_Duet
{
    internal class Multiplicate : Operation
    {
        private string _registerName;
        private string _value;

        public Multiplicate(string registerName, string value)
        {
            _registerName = registerName;
            _value = value;
        }

        public override (int NextIndex, long? Solution) Perform(IDictionary<string, long> registers, int currentOperationIndex)
        {
            registers[_registerName] *= GetValue(registers, _value);
            return (NextIndex: currentOperationIndex + 1,
                    Solution: null);
        }
    }
}