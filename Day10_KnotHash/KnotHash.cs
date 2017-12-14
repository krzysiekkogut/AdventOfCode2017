using Shared;
using System.Linq;
using System.Collections.Generic;
using System;

namespace Day10_KnotHash
{
    public class KnotHash : PuzzleSolver<KnotHashInput>
    {
        const int _listLength = 256;
        const int _sparseHashFragmentLength = 16;
        private int _skipSize = 0;
        private int _currentPosition = 0;
        private readonly int[] _list;
        private readonly bool _complexHashing;

        public KnotHash(bool complexHashing)
        {
            _list = Enumerable.Range(0, _listLength).ToArray();
            _complexHashing = complexHashing;
        }

        private int NumberOfRounds => _complexHashing ? 64 : 1;

        protected override PuzzleSolution SolveInternal(KnotHashInput input)
        {
            var knotLengths = _complexHashing ? input.KnotLengthsFromASCII : input.KnotLengths;
            PerformKnotHashing(knotLengths);
            return
                _complexHashing
                    ? new ComplexKnotHashSolution(FormatHashToHex(DensifyHash())) as PuzzleSolution
                    : new KnotHashSolution(_list[0] * _list[1]) as PuzzleSolution;
        }

        private void PerformKnotHashing(IList<int> knotLengths)
        {
            for (var i = 0; i < NumberOfRounds; i++)
            {
                foreach (var length in knotLengths)
                {
                    ReverseFragment(_currentPosition, _currentPosition + length - 1);
                    _currentPosition += length + _skipSize;
                    _skipSize++;
                }
            }
        }

        private void ReverseFragment(int startPosition, int endPosition)
        {
            while (startPosition < endPosition)
            {
                var tmp = _list[startPosition % _listLength];
                _list[startPosition % _listLength] = _list[endPosition % _listLength];
                _list[endPosition % _listLength] = tmp;

                startPosition++;
                endPosition--;
            }
        }

        private IEnumerable<int> DensifyHash()
        {
            return Enumerable.Range(0, _sparseHashFragmentLength)
                .Select(i => _list.Skip(i * _sparseHashFragmentLength).Take(_sparseHashFragmentLength))
                .Select(sparseHashFragment => sparseHashFragment.Aggregate((x, y) => x ^ y));
        }

        private string FormatHashToHex(IEnumerable<int> denseHash)
        {
            return string.Concat(denseHash.Select(x => Convert.ToString(x, 16).PadLeft(2, '0')));
        }
    }
}
