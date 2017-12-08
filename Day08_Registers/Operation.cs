namespace Day08_Registers
{
    public class Operation
    {
        public string RegisterName { get; set; }
        public OperationType OperationType { get; set; }
        public int OperandValue { get; set; }
        public Condition Condition { get; set; }
    }
}