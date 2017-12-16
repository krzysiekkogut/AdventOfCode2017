using System;

namespace Day16_PermutationPromenade
{
    internal class PartnerMove : DanceMove
    {
        private char _programA;
        private char _programB;

        public PartnerMove(char programA, char programB)
        {
            _programA = programA;
            _programB = programB;
        }

        internal override void MoveOn(char[] programs)
        {
            var positionA = IndexOf(_programA, programs);
            var positionB = IndexOf(_programB, programs);
            var tmp = programs[positionA];
            programs[positionA] = programs[positionB];
            programs[positionB] = tmp;
        }

        private int IndexOf(char program, char[] programs)
        {
            for (var i = 0; i < programs.Length; i++)
            {
                if (programs[i] == program)
                {
                    return i;
                }
            }

            throw new Exception("Wrong input.");
        }
    }
}