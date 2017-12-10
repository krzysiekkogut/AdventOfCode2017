using Shared;
using System.Linq;
using System;
using System.Collections.Generic;

namespace Day10_KnotHash
{
    public class KnotHash : PuzzleSolver<KnotHashInput>
    {
        const int _listLength = 256;
        const int _sparseHashFragmentLength = 16;
        private readonly int[] _list;
        private readonly bool _complexHashing;

        public KnotHash(bool complexHashing)
        {
            _list = Enumerable.Range(0, _listLength).ToArray();
            _complexHashing = complexHashing;
        }

        private int NumberOfRounds => _complexHashing ? 64 : 1;

        protected override IPuzzleSolution SolveInternal(KnotHashInput input)
        {
            var skipSize = 0;
            var currentPosition = 0;

            var knotLengths = _complexHashing ? input.KnotLengthsFromASCII : input.KnotLengths;
            for (var i = 0; i < NumberOfRounds; i++)
            {
                foreach (var length in knotLengths)
                {
                    ReverseFragment(currentPosition, currentPosition + length - 1);
                    currentPosition += length + skipSize;
                    skipSize++;
                }
            }

            if (!_complexHashing)
            {
                return new KnotHashSolution(_list[0] * _list[1]);
            }

            var denseHash = DensifyHash();
            var hexRepresentation = FormatHashToHex(denseHash);
            return new ComplesKnotHashSolution(hexRepresentation);
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
            return string.Concat(denseHash.Select(x => x.ToString("x2")));
        }
    }
}
