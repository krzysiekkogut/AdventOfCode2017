using System;

namespace Day16_PermutationPromenade
{
    internal abstract class DanceMove
    {
        internal static DanceMove ParseDanceMoveText(string danceMoveText)
        {
            switch (danceMoveText[0])
            {
                case 's':
                    return new SpinMove(int.Parse(danceMoveText.Substring(1)));
                case 'x':
                    return new ExchangeMove(
                        int.Parse(danceMoveText.Substring(1, danceMoveText.IndexOf('/') - 1)),
                        int.Parse(danceMoveText.Substring(danceMoveText.IndexOf('/') + 1)));
                case 'p':
                    return new PartnerMove(danceMoveText[1], danceMoveText[3]);
                default:
                    throw new Exception("Wrong input.");
            }
        }

        internal abstract void MoveOn(char[] programs);
    }
}