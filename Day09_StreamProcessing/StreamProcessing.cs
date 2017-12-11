using System;
using Shared;
using System.Text;

namespace Day09_StreamProcessing
{
    public class StreamProcessing : PuzzleSolver<StreamProcessingInput>
    {
        private readonly bool _countGarbageCharacters;

        public StreamProcessing(bool countGarbageCharacters)
        {
            _countGarbageCharacters = countGarbageCharacters;
        }

        protected override PuzzleSolution SolveInternal(StreamProcessingInput input)
        {
            var stremWithoutCanceledCharacters = RemoveCanceled(input.Stream);
            var cleanedStreamWithGarbageCount = RemoveGarbage(stremWithoutCanceledCharacters);
            return new StreamProcessingSolution(
                _countGarbageCharacters
                ? cleanedStreamWithGarbageCount.GarbageCharactersCount
                : ScoreGroups(cleanedStreamWithGarbageCount.CleanedStream));
        }

        private string RemoveCanceled(string stream)
        {
            var builder = new StringBuilder();
            for (var i = 0; i < stream.Length; i++)
            {
                if (stream[i] != '!')
                {
                    builder.Append(stream[i]);
                }
                else
                {
                    i++;
                }
            }

            return builder.ToString();
        }

        private (string CleanedStream, int GarbageCharactersCount) RemoveGarbage(string stream)
        {
            var garbageCharactersCount = 0;
            while (stream.Contains("<"))
            {
                var garbageStartIndex = stream.IndexOf('<');
                var garbageEndIndex = stream.IndexOf('>');
                stream = stream.Remove(garbageStartIndex, garbageEndIndex - garbageStartIndex + 1);
                garbageCharactersCount += garbageEndIndex - garbageStartIndex - 1;
            }

            return (CleanedStream: stream, GarbageCharactersCount: garbageCharactersCount);
        }

        private string RemoveNotNecessaryCommas(string stream)
        {
            while (stream.Contains("{,"))
            {
                var index = stream.IndexOf("{,");
                stream = stream.Remove(index + 1, 1);
            }

            return stream;
        }

        private int ScoreGroups(string stream)
        {
            var totalScore = 0;
            var currentScoring = 1;

            foreach (var character in stream)
            {
                switch (character)
                {
                    case '{':
                        totalScore += currentScoring;
                        currentScoring++;
                        break;
                    case '}':
                        currentScoring--;
                        break;
                }
            }

            return totalScore;
        }
    }
}
