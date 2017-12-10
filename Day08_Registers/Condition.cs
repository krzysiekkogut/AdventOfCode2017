using System;

namespace Day08_Registers
{
    internal class Condition
    {
        public Condition(string comparisonType)
        {
            switch (comparisonType)
            {
                case "<":
                    ComparisonType = ComparisonType.LessThan;
                    break;
                case "<=":
                    ComparisonType = ComparisonType.LessThanOrEqualTo;
                    break;
                case ">":
                    ComparisonType = ComparisonType.GreaterThan;
                    break;
                case ">=":
                    ComparisonType = ComparisonType.GreaterThanOrEqualTo;
                    break;
                case "==":
                    ComparisonType = ComparisonType.EqualTo;
                    break;
                case "!=":
                    ComparisonType = ComparisonType.NotEqualTo;
                    break;
                default:
                    throw new Exception("Wrong input.");
            }
        }

        public string RegisterNameToCompare { get; set; }
        public int CompareToValue { get; set; }
        public ComparisonType ComparisonType { get; set; }
    }
}