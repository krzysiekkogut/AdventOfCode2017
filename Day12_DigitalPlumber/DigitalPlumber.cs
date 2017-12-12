using System.Collections.Generic;
using System.Linq;
using Shared;

namespace Day12_DigitalPlumber
{
    public class DigitalPlumber : PuzzleSolver<DigitalPlumberInput>
    {
        protected override PuzzleSolution SolveInternal(DigitalPlumberInput input)
        {
            var graph = input
                .ProgramsCommunication
                .ToDictionary(p => p.ProgramId, p => p);

            var queue = new Queue<int>();
            queue.Enqueue(0);
            var processedPrograms = new HashSet<int>();

            while (queue.Any())
            {
                var processedProgram = queue.Dequeue();
                if (processedPrograms.Add(processedProgram))
                {
                    foreach (var programId in graph[processedProgram].ProgramReferences)
                    {
                        if (!processedPrograms.Contains(programId))
                        {
                            queue.Enqueue(programId);
                        }
                    }
                }
            }

            return new DigitalPlumberSolution(processedPrograms.Count);
        }
    }
}
