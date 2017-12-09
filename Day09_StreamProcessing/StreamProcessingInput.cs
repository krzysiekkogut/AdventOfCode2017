using Shared;

namespace Day09_StreamProcessing
{
    public class StreamProcessingInput : IPuzzleInput<StreamProcessingInput>
    {
        public string Stream { get; private set; }

        public StreamProcessingInput ParseFromText(string textInput)
        {
            Stream = textInput;
            return this;
        }
    }
}