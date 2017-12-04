using System;

namespace Day03_SpiralMemory
{
    internal class SpiralTable
    {
        private int[,] _array;
        private int _arraySize;
        private Direction _currentDirection;

        // real indexing
        private int _x;
        private int _y;

        // logic indexing
        private int X
        {
            get
            {
                return _x - _arraySize / 2;
            }
            set
            {
                _x = value + _arraySize / 2; ;
            }
        }

        private int Y
        {
            get
            {
                return _y - _arraySize / 2;

            }
            set
            {
                _y = value + _arraySize / 2; ;
            }
        }

        public SpiralTable(int maxValue)
        {
            var sqrt = Convert.ToInt32(Math.Ceiling(Math.Sqrt(maxValue)));
            _arraySize = sqrt % 2 == 0 ? sqrt + 1 : sqrt;
            _array = new int[_arraySize, _arraySize];
            X = 0;
            Y = 0;
            _array[_x, _y] = 1;
            _currentDirection = Direction.Right;
        }

        public int FillWithSumOfAdjacentRegistriesUntilMax(int maxValue)
        {
            while (_array[_x, _y] <= maxValue)
            {
                MoveToNextCell();
                _array[_x, _y] = CalculateSumOfAdjacentRegistries();
            }

            return _array[_x, _y];
        }

        private void MoveToNextCell()
        {
            if (Math.Abs(X) == Math.Abs(Y))
            {
                ChangeDirection();
            }
            else
            {
                switch (_currentDirection)
                {
                    case Direction.Up:
                        Y--;
                        break;
                    case Direction.Down:
                        Y++;
                        break;
                    case Direction.Right:
                        X++;
                        break;
                    case Direction.Left:
                        X--;
                        break;
                }
            }
        }

        private void ChangeDirection()
        {
            if (X >= 0 && Y >= 0)
            {
                X++;
                _currentDirection = Direction.Up;
            }
            else if(X > 0 && Y < 0)
            {
                X--;
                _currentDirection = Direction.Left;
            }
            else if (X < 0 && Y < 0)
            {
                Y++;
                _currentDirection = Direction.Down;
            }
            else
            {
                X++;
                _currentDirection = Direction.Right;
            }

        }

        private int CalculateSumOfAdjacentRegistries()
        {
            var sum = 0;

            // top left
            if (_x - 1 >= 0 && _y - 1 >= 0)
            {
                sum += _array[_x - 1, _y - 1];
            }

            // top 
            if (_y - 1 >= 0)
            {
                sum += _array[_x, _y - 1];
            }

            // top right
            if (_x + 1 < _arraySize && _y - 1 >= 0)
            {
                sum += _array[_x + 1, _y - 1];
            }

            // left
            if (_x - 1 >= 0)
            {
                sum += _array[_x - 1, _y];
            }

            // right
            if (_x + 1 < _arraySize)
            {
                sum += _array[_x + 1, _y];
            }

            // bottom left
            if (_x - 1 >= 0 && _y + 1 < _arraySize)
            {
                sum += _array[_x - 1, _y + 1];
            }

            // bottom 
            if (_y + 1 < _arraySize)
            {
                sum += _array[_x, _y + 1];
            }

            // bottom right
            if (_x + 1 < _arraySize && _y + 1 < _arraySize)
            {
                sum += _array[_x + 1, _y + 1];
            }

            return sum;
        }
    }
}