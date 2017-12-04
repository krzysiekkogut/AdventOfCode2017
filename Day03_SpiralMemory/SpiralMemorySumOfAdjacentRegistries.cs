using Shared;

namespace Day03_SpiralMemory
{
    public class SpiralMemorySumOfAdjacentRegistries : PuzzleSolver<SpiralMemoryInput>, IPuzzleSolver
    {
        protected override int SolveInternal(SpiralMemoryInput input)
        {
            var spiralTable = new SpiralTable(input.RegistryNumber);
            return spiralTable.FillWithSumOfAdjacentRegistriesUntilMax(input.RegistryNumber);
        }
    }
}
