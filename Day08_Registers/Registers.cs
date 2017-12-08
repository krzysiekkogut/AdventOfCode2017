using Shared;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Day08_Registers
{
    public class Registers : PuzzleSolver<RegistersInput>
    {
        private bool _shouldReturnMaxRegisterEver;
        private int _maxDuringProcess;

        public Registers(bool shouldReturnMaxRegisterEver)
        {
            _shouldReturnMaxRegisterEver = shouldReturnMaxRegisterEver;
            _maxDuringProcess = 0;
        }

        protected override RegistersInput ParseInput(string inputText)
        {
            return new RegistersInput().ParseFromText(inputText);
        }

        protected override IPuzzleSolution SolveInternal(RegistersInput input)
        {
            var registers = input.Operations.Select(op => op.RegisterName).Distinct().ToDictionary(reg => reg, reg => 0);
            foreach (var operation in input.Operations)
            {
                if (CheckCondition(operation.Condition, registers))
                {
                    MakeOperation(operation, registers);
                }
            }

            return new RegistersSolution(_shouldReturnMaxRegisterEver ? _maxDuringProcess : registers.Values.Max());
        }

        private bool CheckCondition(Condition condition, Dictionary<string, int> registers)
        {
            var registerValue = registers[condition.RegisterNameToCompare];
            switch (condition.ComparisonType)
            {
                case ComparisonType.LessThan:
                    return registerValue < condition.CompareToValue;
                case ComparisonType.LessThanOrEqualTo:
                    return registerValue <= condition.CompareToValue;
                case ComparisonType.GreaterThan:
                    return registerValue > condition.CompareToValue;
                case ComparisonType.GreaterThanOrEqualTo:
                    return registerValue >= condition.CompareToValue;
                case ComparisonType.EqualTo:
                    return registerValue == condition.CompareToValue;
                case ComparisonType.NotEqualTo:
                    return registerValue != condition.CompareToValue;
                default:
                    throw new Exception("Wrong input.");
            }
        }

        private void MakeOperation(Operation operation, Dictionary<string, int> registers)
        {
            switch (operation.OperationType)
            {
                case OperationType.Increase:
                    registers[operation.RegisterName] += operation.OperandValue;
                    break;
                case OperationType.Decrease:
                    registers[operation.RegisterName] -= operation.OperandValue;
                    break;
            }

            _maxDuringProcess = Math.Max(_maxDuringProcess, registers[operation.RegisterName]);
        }
    }
}
