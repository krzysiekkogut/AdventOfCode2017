using Shared;
using System.Collections.Generic;
using System.Linq;

namespace Day12_DigitalPlumber
{
    public class DigitalPlumberGroupsCounter : PuzzleSolver<DigitalPlumberInput>
    {
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

            return new DigitalPlumberSolution(currentGroupNumber);
        }
    }
}
