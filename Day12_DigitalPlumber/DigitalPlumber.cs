using System.Collections.Generic;
using System.Linq;
using Shared;

namespace Day12_DigitalPlumber
{
    public class DigitalPlumber : PuzzleSolver<DigitalPlumberInput>
    {
        private readonly bool _showNumberOfGroups;

        public DigitalPlumber(bool showNumberOfGroups)
        {
            _showNumberOfGroups = showNumberOfGroups;
        }

        protected override PuzzleSolution SolveInternal(DigitalPlumberInput input)
        {
            var graph = input
                .ProgramsCommunication
                .ToDictionary(p => p.ProgramId, p => p);

            var currentGroupNumber = 0;
            while (graph.Any(p => p.Value.GroupId < 0))
            {
                var nodeToStart = graph.First(p => p.Value.GroupId < 0);
                var queue = new Queue<int>();
                var processedPrograms = new HashSet<int>();
                queue.Enqueue(nodeToStart.Key);

                while (queue.Any())
                {
                    var processedProgram = queue.Dequeue();
                    if (processedPrograms.Add(processedProgram))
                    {
                        graph[processedProgram].GroupId = currentGroupNumber;
                        foreach (var programId in graph[processedProgram].ProgramReferences)
                        {
                            if (!processedPrograms.Contains(programId))
                            {
                                queue.Enqueue(programId);
                            }
                        }
                    }
                }

                currentGroupNumber++;
            }

            return new DigitalPlumberSolution(_showNumberOfGroups ? currentGroupNumber : graph.Count(p => p.Value.GroupId == graph[0].GroupId));
        }
    }
}
