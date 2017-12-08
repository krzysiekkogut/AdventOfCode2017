using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day08_Registers
{
    public class RegistersInput : IPuzzleInput<RegistersInput>
    {
        public IList<Operation> Operations{ get; set; }
        public RegistersInput ParseFromText(string textInput)
        {
            var regex = new Regex(@"(\w+) (inc|dec) (-?\d+) if (\w+) (>=|>|<=|<|==|!=) (-?\d+)");
            var operationsTexts = textInput.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            Operations = operationsTexts
                .Select(operationText =>
                {
                    var match = regex.Match(operationText);
                    return new Operation
                    {
                        RegisterName = match.Groups[1].Value,
                        OperationType = match.Groups[2].Value.Equals("inc", StringComparison.OrdinalIgnoreCase) ? OperationType.Increase : OperationType.Decrease,
                        OperandValue = int.Parse(match.Groups[3].Value),
                        Condition = new Condition(match.Groups[5].Value)
                        {
                            RegisterNameToCompare = match.Groups[4].Value,
                            CompareToValue = int.Parse(match.Groups[6].Value)
                        }
                    };
                })
                .ToList();
            return this;
        }
    }
}