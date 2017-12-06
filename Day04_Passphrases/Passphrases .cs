using Shared;
using System.Linq;

namespace Day04_Passphrases
{
    public class Passphrases : PuzzleSolver<PassphrasesInput>, IPuzzleSolver
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

        protected override int SolveInternal(PassphrasesInput input)
        {
            return input
                .Passphrases
                .Select(passphraseWords =>
                    _areAnagramsAllowed
                        ? passphraseWords
                        : passphraseWords.Select(password => string.Concat(password.OrderBy(character => character))))
                .Where(passphraseWords => passphraseWords.Count() == passphraseWords.Distinct().Count())
                .Count();
        }
    }
}
