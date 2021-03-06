﻿using System.Collections.Generic;

namespace Day23_CoprocessorConflagration
{
    internal class Set : Operation
    {
        private string _registerName;
        private string _value;

        public Set(string registerName, string value)
        {
            _registerName = registerName;
            _value = value;
        }

        public override int Perform(IDictionary<string, long> registers, int currentOperationIndex)
        {
            registers[_registerName] = GetValue(registers, _value);
            return currentOperationIndex + 1;
        }
    }
}