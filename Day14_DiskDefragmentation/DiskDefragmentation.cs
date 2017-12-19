using Day10_KnotHash;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Day14_DiskDefragmentation
{
    public class DiskDefragmentation : PuzzleSolver<DiskDefragmentationInput>
    {
        private const int GridSize = 128;
        private readonly bool _countRegions;
        private bool[][] _disk;
        private bool[][] _processed;

        public DiskDefragmentation(bool countRegions)
        {
            _disk = new bool[GridSize][];
            _processed = new bool[GridSize][];
            _countRegions = countRegions;
        }

        protected override IPuzzleSolution SolveInternal(DiskDefragmentationInput input)
        {
            for (var i = 0; i < GridSize; i++)
            {
                var hash = new KnotHash(true).Solve($"{input.KeyPrefix}{i}").PrintSolution();
                _disk[i] = ConvertToBinary(hash);
                _processed[i] = Enumerable.Repeat(false, GridSize).ToArray();
            }

            return _countRegions
                ? new DiskDefragmentationSolution(FindRegions())
                : new DiskDefragmentationSolution(CountOnBits());
        }

        private bool[] ConvertToBinary(string hex)
        {
            var partsNumber = 4;
            var partLength = hex.Length / partsNumber;
            var parts = new string[partsNumber];

            for (var i = 0; i < partsNumber; i++)
            {
                parts[i] = Convert.ToString(Convert.ToUInt32(hex.Substring(i * partLength, partLength), 16), 2).PadLeft(partLength * 4, '0');
            }

            return string.Concat(parts).Select(c => c == '1').ToArray();
        }

        private int FindRegions()
        {
            var region = 0;
            for (var i = 0; i < GridSize; i++)
            {
                for (var j = 0; j < GridSize; j++)
                {
                    if (_disk[i][j] && !_processed[i][j])
                    {
                        var queue = new Queue<(int row, int column)>();
                        queue.Enqueue((row: i, column: j));
                        while (queue.Any())
                        {
                            var currentCell = queue.Dequeue();
                            _processed[currentCell.row][currentCell.column] = true;

                            AddUpNeighbor(queue, currentCell.row, currentCell.column);
                            AddBottomNeighbor(queue, currentCell.row, currentCell.column);
                            AddLeftNeighbor(queue, currentCell.row, currentCell.column);
                            AddRightNeighbor(queue, currentCell.row, currentCell.column);
                        }

                        region++;
                    }
                }
            }

            return region;
        }

        private void AddUpNeighbor(Queue<(int row, int column)> queue, int row, int column)
        {
            if (row > 0 && !_processed[row - 1][column] && _disk[row - 1][column])
            {
                queue.Enqueue((row: row - 1, column: column));
            }
        }

        private void AddBottomNeighbor(Queue<(int row, int column)> queue, int row, int column)
        {
            if (row < GridSize - 1 && !_processed[row + 1][column] && _disk[row + 1][column])
            {
                queue.Enqueue((row: row + 1, column: column));
            }
        }

        private void AddLeftNeighbor(Queue<(int row, int column)> queue, int row, int column)
        {
            if (column > 0 && !_processed[row][column - 1] && _disk[row][column - 1])
            {
                queue.Enqueue((row: row, column: column - 1));
            }
        }

        private void AddRightNeighbor(Queue<(int row, int column)> queue, int row, int column)
        {
            if (column < GridSize - 1 && !_processed[row][column + 1] && _disk[row][column + 1])
            {
                queue.Enqueue((row: row, column: column + 1));
            }
        }

        private int CountOnBits()
        {
            return _disk.Sum(diskRow => diskRow.Count(diskCell => diskCell));
        }
    }
}
