using Shared;

namespace Day03_SpiralMemory
{
    public class SpiralMemoryInput : IPuzzleInput<SpiralMemoryInput>
    {
        public int RegistryNumber { get; set; }

        public SpiralMemoryInput ParseFromText(string textInput)
        {
            RegistryNumber = int.Parse(textInput);
            return this;
        }
    }
}