namespace Day25_TheHaltingProblem
{
    public class StateChange
    {
        public bool NewValue { get; set; }
        public char NextState { get; set; }
        internal Move Move { get; set; }
    }
}