using Shared;

namespace Day03_SpiralMemory
{
    public class SpiralMemorySumOfAdjacentRegistries : PuzzleSolver<SpiralMemoryInput>
    {
        protected override PuzzleSolution SolveInternal(SpiralMemoryInput input)
        {
            var spiralTable = new SpiralTable(input.RegistryNumber);
            var result = spiralTable.FillWithSumOfAdjacentRegistriesUntilMax(input.RegistryNumber);
            return new SpiralMemorySolution(result);
        }
    }
}
