using System.Collections.Generic;
using Shared;

namespace Day17_Spinlock
{
    public class Spinlock : PuzzleSolver<SpinlockInput>
    {
        private readonly int _numberOfValues;
        private readonly bool _complexSpinlock;

        public Spinlock(bool complexSpinlock)
        {
            _complexSpinlock = complexSpinlock;
            _numberOfValues = complexSpinlock ? 50_000_000 : 2017;
        }

        protected override PuzzleSolution SolveInternal(SpinlockInput input)
        {
            return new SpinlockSolution(_complexSpinlock ? FindValueOnSecondPosition(input.Step) : FindValueAfterLastAdded(input.Step));
        }

        private int FindValueAfterLastAdded(int step)
        {
            var circullarBuffer = new LinkedList<int>();
            circullarBuffer.AddFirst(0);
            var currentNode = circullarBuffer.First;
            for (var currentValue = 1; currentValue <= _numberOfValues; currentValue++)
            {
                for (var i = 0; i < step; i++)
                {
                    currentNode = MoveToNext(currentNode);
                }

                currentNode = circullarBuffer.AddAfter(currentNode, currentValue);
            }

            return MoveToNext(currentNode).Value;
        }

        private int FindValueOnSecondPosition(int step)
        {
            var valueOnSecondPosition = 1;
            var insertIndex = 1;

            for (int currentValue = 2; currentValue <= _numberOfValues; currentValue++)
            {
                insertIndex += step;
                insertIndex %= currentValue;
                insertIndex++;

                if (insertIndex == 1)
                {
                    valueOnSecondPosition = currentValue;
                }
            }

            return valueOnSecondPosition;
        }

        private LinkedListNode<int> MoveToNext(LinkedListNode<int> node)
        {
            return node.Next ?? node.List.First;
        }
    }
}
