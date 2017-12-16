namespace Day16_PermutationPromenade
{
    internal class ExchangeMove : DanceMove
    {
        private int _positionA;
        private int _positionB;

        public ExchangeMove(int positionA, int positionB)
        {
            _positionA = positionA;
            _positionB = positionB;
        }

        internal override void MoveOn(char[] programs)
        {
            var tmp = programs[_positionA];
            programs[_positionA] = programs[_positionB];
            programs[_positionB] = tmp;
        }
    }
}