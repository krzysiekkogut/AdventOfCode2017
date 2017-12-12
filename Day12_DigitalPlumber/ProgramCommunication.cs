using System.Collections.Generic;

namespace Day12_DigitalPlumber
{
    internal class ProgramCommunication
    {
        public int ProgramId { get; set; }
        public int GroupId { get; set; } = -1;
        public IList<int> ProgramReferences { get; set; }

        public override int GetHashCode()
        {
            return ProgramId.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return (obj as ProgramCommunication)?.ProgramId == ProgramId;
        }
    }
}