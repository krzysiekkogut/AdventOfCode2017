using Shared;
using System.Collections.Generic;

namespace Day04_Passphrases
{
    public class PassphrasesInput : IPuzzleInput
    {
        public IEnumerable<IEnumerable<string>> Passphrases { get; set; }
        public bool AreAnagramsAllowed { get; set; }
    }
}