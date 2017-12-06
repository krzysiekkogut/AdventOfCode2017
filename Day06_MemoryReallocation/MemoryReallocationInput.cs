using Shared;
using System.Linq;

namespace Day06_MemoryReallocation
{
    public class MemoryReallocationInput : IPuzzleInput<MemoryReallocationInput>
    {
        public int[] Banks { get; set; }

        public bool ShouldReturnOnlyCycleLength { get; set; }

        public MemoryReallocationInput ParseFromText(string textInput)
        {
            Banks = textInput.Split('\t').Select(numberText => int.Parse(numberText)).ToArray();
            return this;
        }

        public override string ToString()
        {
            return string.Join(",", Banks);
        }
    }
}