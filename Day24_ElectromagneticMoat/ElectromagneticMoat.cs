using Shared;
using System;
using System.Collections.Immutable;
using System.Linq;

namespace Day24_ElectromagneticMoat
{
    public class ElectromagneticMoat : PuzzleSolver<ElectromagneticMoatInput>
    {
        private readonly bool _longestBridge;

        public ElectromagneticMoat(bool longestBridge)
        {
            _longestBridge = longestBridge;
        }

        protected override IPuzzleSolution SolveInternal(ElectromagneticMoatInput input)
        {
            var elements = ImmutableList<Tuple<int, int>>.Empty;
            foreach (var element in input.Elements)
            {
                elements = elements.Add(element);
            }

            return new ElectromagneticMoatSolution(
                _longestBridge 
                ? FindLongestBridgeStrength(elements, 0, 0, 0).Item1
                : FindMaxStrength(elements, 0, 0));
        }

        private int FindMaxStrength(IImmutableList<Tuple<int, int>> elements, int currentElementPart, int currentStrength)
        {
            var candidatesForNextElement = elements.Where(elem => elem.Item1 == currentElementPart || elem.Item2 == currentElementPart);
            var maxCandidates = candidatesForNextElement
                .Select(element =>
                    FindMaxStrength(
                        elements.Remove(element),
                        element.Item1 == currentElementPart ? element.Item2 : element.Item1,
                        currentStrength + element.Item1 + element.Item2))
                .Concat(Enumerable.Repeat(currentStrength, 1));
            return maxCandidates.Max();
        }

        private Tuple<int, int> FindLongestBridgeStrength(IImmutableList<Tuple<int, int>> elements, int currentElementPart, int currentStrength, int currentLenght)
        {
            var candidatesForNextElement = elements.Where(elem => elem.Item1 == currentElementPart || elem.Item2 == currentElementPart);
            var maxCandidates = candidatesForNextElement
                .Select(element =>
                    FindLongestBridgeStrength(
                        elements.Remove(element),
                        element.Item1 == currentElementPart ? element.Item2 : element.Item1,
                        currentStrength + element.Item1 + element.Item2,
                        currentLenght + 1))
                .Concat(Enumerable.Repeat(Tuple.Create(currentStrength, currentLenght), 1));
            return maxCandidates
                .OrderByDescending(element => element.Item2)
                .ThenByDescending(element => element.Item1)
                .First(); ;
        }
    }
}
