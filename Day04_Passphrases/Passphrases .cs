using Shared;
using System.Linq;

namespace Day04_Passphrases
{
    public class Passphrases : PuzzleSolver<PassphrasesInput>, IPuzzleSolver
    {
        protected override int SolveInternal(PassphrasesInput input)
        {
            return input
                .Passphrases
                .Select(passphraseWords => 
                    input.AreAnagramsAllowed 
                        ? passphraseWords 
                        : passphraseWords.Select(password => string.Concat(password.OrderBy(character => character))))
                .Where(passphraseWords => passphraseWords.Count() == passphraseWords.Distinct().Count())
                .Count();
        }
    }
}
