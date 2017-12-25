using System.Linq;

namespace Day25_TheHaltingProblem
{
    public class StateChangeDefinition
    {
        public char Name { get; set; }
        public StateChange ChangeFrom0 { get; set; } = new StateChange();
        public StateChange ChangeFrom1 { get; set; } = new StateChange();

        internal static StateChangeDefinition Parse(string[] definitonLines)
        {
            var stateChangeDefinition = new StateChangeDefinition();
            stateChangeDefinition.Name = definitonLines[0][definitonLines[0].Length - 2];
            stateChangeDefinition.ChangeFrom0.NewValue = definitonLines[2][definitonLines[2].Length - 2] == '1';
            stateChangeDefinition.ChangeFrom0.Move = definitonLines[3].Split(' ').Last() == "left." ? Move.Back : Move.Forward;
            stateChangeDefinition.ChangeFrom0.NextState = definitonLines[4][definitonLines[4].Length - 2];

            stateChangeDefinition.ChangeFrom1.NewValue = definitonLines[6][definitonLines[6].Length - 2] == '1';
            stateChangeDefinition.ChangeFrom1.Move = definitonLines[7].Split(' ').Last() == "left." ? Move.Back : Move.Forward;
            stateChangeDefinition.ChangeFrom1.NextState = definitonLines[8][definitonLines[8].Length - 2];

            return stateChangeDefinition;
        }
    }
}