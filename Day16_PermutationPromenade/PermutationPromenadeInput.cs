using Shared;
using System.Collections.Generic;
using System.Linq;

namespace Day16_PermutationPromenade
{
    public class PermutationPromenadeInput : IPuzzleInput<PermutationPromenadeInput>
    {
        internal IList<DanceMove> DanceMoves { get; set; }

        public PermutationPromenadeInput ParseFromText(string textInput)
        {
            DanceMoves = textInput.Split(',').Select(DanceMove.ParseDanceMoveText).ToList();
            return this;
        }
    }
}