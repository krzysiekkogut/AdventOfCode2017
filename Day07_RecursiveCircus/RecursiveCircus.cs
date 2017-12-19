using Shared;
using System.Collections.Generic;
using System.Linq;

namespace Day07_RecursiveCircus
{
    public class RecursiveCircus : PuzzleSolver<RecursiveCircusInput>
    {
        private bool _showCorrectProgramWeight;

        public RecursiveCircus(bool showCorrectProgramWeight)
        {
            _showCorrectProgramWeight = showCorrectProgramWeight;
        }

        protected override IPuzzleSolution SolveInternal(RecursiveCircusInput input)
        {
            var dictOfProgramNodes = BuildGraph(input.Programs);
            var bottomProgramNode = dictOfProgramNodes.Single(node => node.Value.NodeBelow == null).Value;
            var correctProgramWeight = FindCorrectProgramWeight(bottomProgramNode);
            var result = (BottomProgramName: bottomProgramNode.Name, CorrectProgramWeight: correctProgramWeight);
            return new RecursiveCircusSolution(result, _showCorrectProgramWeight);
        }

        private Dictionary<string, ProgramNode> BuildGraph(IEnumerable<ProgramNode> programs)
        {
            var dict = programs.ToDictionary(program => program.Name);
            foreach (var program in programs.Where(p => p.ReferencesNames.Any()))
            {
                foreach (var referenceName in program.ReferencesNames)
                {
                    dict[referenceName].NodeBelow = program;
                    program.NodesAbove.Add(dict[referenceName]);
                    program.SubtreeWeight += dict[referenceName].SubtreeWeight;
                    var nodeBelow = program.NodeBelow;
                    while (nodeBelow != null)
                    {
                        nodeBelow.SubtreeWeight += dict[referenceName].SubtreeWeight;
                        nodeBelow = nodeBelow.NodeBelow;
                    }
                }
            }

            return dict;
        }

        private int FindCorrectProgramWeight(ProgramNode currentNode)
        {
            while (!currentNode.IsBalanced)
            {
                if (currentNode.NodesAbove.All(node => node.IsBalanced))
                {
                    var otherWeight = -1;
                    var hashSet = new HashSet<int>();
                    foreach (var subtreeWeight in currentNode.NodesAbove.Select(n => n.SubtreeWeight))
                    {
                        if (!hashSet.Add(subtreeWeight))
                        {
                            otherWeight = hashSet.Single(w => w != subtreeWeight);
                            break;
                        }
                    }

                    currentNode = currentNode.NodesAbove.Single(node => node.SubtreeWeight == otherWeight);
                }
                else
                {
                    currentNode = currentNode.NodesAbove.Single(node => !node.IsBalanced);
                }
            }

            var correctSubtreeWeight = currentNode.NodeBelow.NodesAbove.First(node => !node.Equals(currentNode)).SubtreeWeight;
            return correctSubtreeWeight - currentNode.NodesAbove.Sum(n => n.SubtreeWeight);
        }
    }
}
