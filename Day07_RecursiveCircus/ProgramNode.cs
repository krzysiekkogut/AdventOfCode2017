using System.Collections.Generic;
using System.Linq;

namespace Day07_RecursiveCircus
{
    internal class ProgramNode
    {
        public ProgramNode()
        {
            NodesAbove = new List<ProgramNode>();
        }

        public string Name { get; set; }

        public int Weight { get; set; }

        public int SubtreeWeight { get; set; }

        public IEnumerable<string> ReferencesNames { get; set; }

        public ProgramNode NodeBelow { get; set; }

        public IList<ProgramNode> NodesAbove { get; set; }

        public bool IsBalanced => NodesAbove.Select(nodeAbove => nodeAbove.SubtreeWeight).Distinct().Count() == 1;
    }
}