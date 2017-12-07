using Shared;

namespace Day03_SpiralMemory
{
    public class SpiralMemorySumOfAdjacentRegistries : PuzzleSolver<SpiralMemoryInput>
    {
        protected override SpiralMemoryInput ParseInput(string inputText)
        {
            return new SpiralMemoryInput().ParseFromText(inputText);
        }

        protected override IPuzzleSolution SolveInternal(SpiralMemoryInput input)
        {
            var spiralTable = new SpiralTable(input.RegistryNumber);
            var result = spiralTable.FillWithSumOfAdjacentRegistriesUntilMax(input.RegistryNumber);
            return new SpiralMemorySolution(result);
        }
    }
}
