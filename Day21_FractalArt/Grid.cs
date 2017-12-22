using System.Collections.Generic;
using System.Linq;

namespace Day21_FractalArt
{
    internal class Grid
    {
        private char[][] _gridData;

        public Grid(int size)
        {
            _gridData = new char[size][];
            Size = size;

            for (var i = 0; i < size; i++)
            {
                _gridData[i] = new char[size];
                for (var j = 0; j < size; j++)
                {
                    _gridData[i][j] = 'X';
                }
            }
        }

        internal int Size { get; set; }

        internal char Get(int row, int column)
        {
            return _gridData[row][column];
        }

        internal void Set(int row, int column, char value)
        {
            _gridData[row][column] = value;
        }

        internal Grid[][] Split(int smallGridSize)
        {
            var gridsArray = new Grid[Size / smallGridSize][];
            for (int i = 0; i < Size / smallGridSize; i++)
            {
                gridsArray[i] = new Grid[Size / smallGridSize];
                for (int j = 0; j < gridsArray[i].Length; j++)
                {
                    gridsArray[i][j] = new Grid(smallGridSize);
                }
            }

            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    gridsArray[i / smallGridSize][j / smallGridSize]
                    .Set(i % smallGridSize, j % smallGridSize, Get(i, j));
                }
            }

            return gridsArray;

        }

        internal void Transform(Dictionary<string, string> rules)
        {
            var input = ToString();
            var output = rules[input];
            _gridData = ParseFromString(rules[input]);
            Size++;
        }

        private char[][] ParseFromString(string gridRepresentation)
        {
            return gridRepresentation.Split('/').Select(rowText => rowText.ToCharArray()).ToArray();
        }

        internal static Grid Create(Grid[][] smallGrids)
        {
            var smallGridSize = smallGrids[0][0].Size;
            var grid = new Grid(smallGrids.Length * smallGridSize);

            for (int i = 0; i < grid.Size; i++)
            {
                for (int j = 0; j < grid.Size; j++)
                {
                    var value =
                        smallGrids[i / smallGridSize][j / smallGridSize]
                        .Get(i % smallGridSize, j % smallGridSize);
                    grid.Set(i, j, value);
                }
            }

            return grid;
        }

        internal int Count(char value)
        {
            var count = 0;
            for (var i = 0; i < Size; i++)
            {
                for (var j = 0; j < Size; j++)
                {
                    if (_gridData[i][j] == value)
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        public override string ToString()
        {
            return string.Join("/", _gridData.Select(row => string.Concat(row)));
        }
    }
}
