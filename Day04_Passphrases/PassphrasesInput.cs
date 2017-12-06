using Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Day04_Passphrases
{
    public class PassphrasesInput : IPuzzleInput<PassphrasesInput>
    {
        public IEnumerable<IEnumerable<string>> Passphrases { get; set; }

        public PassphrasesInput ParseFromText(string textInput)
        {
            Passphrases = textInput.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(passphraseText => passphraseText.Split(' '));
            return this;
        }
    }
}