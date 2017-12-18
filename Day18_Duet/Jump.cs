using System.Collections.Generic;

namespace Day18_Duet
{
    internal class Jump : Operation
    {
        private string _checkValue;
        private string _offsetValue;

        public Jump(string checkValue, string offsetValue)
        {
            _checkValue = checkValue;
            _offsetValue = offsetValue;
        }

        public override (int NextIndex, long? Solution) Perform(IDictionary<string, long> registers, int currentOperationIndex)
        {
            var offset = 
                GetValue(registers, _checkValue) > 0
                    ? (int)GetValue(registers, _offsetValue)
                    : 1;
            return (NextIndex: currentOperationIndex + offset,
                    Solution: null);
        }
    }
}