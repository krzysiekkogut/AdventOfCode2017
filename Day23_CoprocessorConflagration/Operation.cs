using System.Collections.Generic;

namespace Day23_CoprocessorConflagration
{
    internal abstract class Operation
    {
        public abstract int Perform(IDictionary<string, long> registers, int currentOperationIndex);

        protected long GetValue(IDictionary<string, long> registers, string valueText)
        {
            return long.TryParse(valueText, out long x) ? x : registers[valueText];
        }
    }
}