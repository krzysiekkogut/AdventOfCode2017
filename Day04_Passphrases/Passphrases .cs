using Shared;
using System.Linq;

namespace Day04_Passphrases
{
    public class Passphrases : PuzzleSolver<PassphrasesInput>
    {
        private bool _areAnagramsAllowed;

        public Passphrases(bool areAnagramsAllowed)
        {
            _areAnagramsAllowed = areAnagramsAllowed;
        }

        protected override PassphrasesInput ParseInput(string inputText)
        {
            return new PassphrasesInput().ParseFromText(inputText);
        }

        protected override IPuzzleSolution SolveInternal(PassphrasesInput input)
        {
            var result = input
                .Passphrases
                .Select(passphraseWords =>
                    _areAnagramsAllowed
                        ? passphraseWords
                        : passphraseWords.Select(password => string.Concat(password.OrderBy(character => character))))
                .Where(passphraseWords => passphraseWords.Count() == passphraseWords.Distinct().Count())
                .Count();
            return new PassphrasesSolution(result);
        }
    }
}
