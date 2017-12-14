using Shared;

namespace Day14_DiskDefragmentation
{
    public class DiskDefragmentationInput : IPuzzleInput<DiskDefragmentationInput>
    {
        public string KeyPrefix { get; set; }

        public DiskDefragmentationInput ParseFromText(string textInput)
        {
            KeyPrefix = $"{textInput}-";
            return this;
        }
    }
}