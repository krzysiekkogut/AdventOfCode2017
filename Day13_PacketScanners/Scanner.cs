namespace Day13_PacketScanners
{
    internal class Scanner
    {
        public int Depth { get; set; }
        public int Range { get; set; }
        private int _mod = -1;
        public int Mod => _mod == -1 ? (_mod = (Range - 1) * 2) : _mod;
    }
}