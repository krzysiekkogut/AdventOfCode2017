using System;
using System.Linq;

namespace Day16_PermutationPromenade
{
    internal class SpinMove : DanceMove
    {
        private int _numberOfProgramsToSpin;

        public SpinMove(int numberOfProgramsToSpin)
        {
            _numberOfProgramsToSpin = numberOfProgramsToSpin;
        }

        internal override void MoveOn(char[] programs)
        {
            var partToSpin = programs.Skip(programs.Length - _numberOfProgramsToSpin).ToArray();
            MoveToRight(programs);
            InsertInFront(partToSpin, programs);
        }

        private void MoveToRight(char[] programs)
        {
            for (var i = programs.Length - 1; i >= _numberOfProgramsToSpin ; i--)
            {
                programs[i] = programs[i - _numberOfProgramsToSpin];
            }
        }

        private void InsertInFront(char[] partToSpin, char[] programs)
        {
            for (var i = 0; i < _numberOfProgramsToSpin; i++)
            {
                programs[i] = partToSpin[i];
            }
        }
    }
}