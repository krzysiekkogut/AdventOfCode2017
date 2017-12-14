using Shared;
using System.Linq;

namespace Day13_PacketScanners
{
    public class PacketScanners : PuzzleSolver<PacketScannersInput>
    {
        private readonly bool _findDeleay;

        public PacketScanners(bool foundDeleay)
        {
            _findDeleay = foundDeleay;
        }

        protected override PuzzleSolution SolveInternal(PacketScannersInput input)
        {
            if (!_findDeleay)
            {
                var result = input.Scanners.Sum(scanner => (scanner.Depth % scanner.Mod) == 0 ? scanner.Depth * scanner.Range : 0);
                return new PacketScannersSolution(result);
            }
            else
            {
                var delay = 1;
                while (input.Scanners.Any(scanner => ((scanner.Depth + delay) % scanner.Mod) == 0))
                {
                    delay++;
                }

                return new PacketScannersSolution(delay);
            }
        }
    }
}