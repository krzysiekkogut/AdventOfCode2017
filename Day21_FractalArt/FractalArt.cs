using System.Collections.Generic;
using Shared;

namespace Day21_FractalArt
{
    public class FractalArt : PuzzleSolver<FractalArtInput>
    {
        private const int MaxGridSize = 18;
        private readonly int _iterationsNumber;
        private Grid _grid;

        public FractalArt(int iterationsNumber)
        {
            _iterationsNumber = iterationsNumber;
            _grid = new Grid(3);
            _grid.Set(0, 0, '.');
            _grid.Set(0, 1, '#');
            _grid.Set(0, 2, '.');
            _grid.Set(1, 0, '.');
            _grid.Set(1, 1, '.');
            _grid.Set(1, 2, '#');
            _grid.Set(2, 0, '#');
            _grid.Set(2, 1, '#');
            _grid.Set(2, 2, '#');
        }

        protected override IPuzzleSolution SolveInternal(FractalArtInput input)
        {
            for (int i = 0; i < _iterationsNumber; i++)
            {
                var smallGrids = SplitGrids(_grid.Size % 2 == 0 ? 2 : 3);
                TransformGrids(smallGrids, input.Rules);
                MergeGrids(smallGrids);
            }

            return new FractalArtSolution(_grid.Count('#'));
        }

        private Grid[][] SplitGrids(int smallGridSize)
        {
            return _grid.Split(smallGridSize);
        }

        private void TransformGrids(Grid[][] smallGrids, Dictionary<string, string> rules)
        {
            foreach (var gridsRow in smallGrids)
            {
                foreach (var grid in gridsRow)
                {
                    grid.Transform(rules);
                }
            }
        }

        private void MergeGrids(Grid[][] smallGrids)
        {
            _grid = Grid.Create(smallGrids);
        }
    }
}
