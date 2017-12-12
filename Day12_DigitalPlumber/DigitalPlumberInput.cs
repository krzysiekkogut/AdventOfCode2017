using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Shared;

namespace Day12_DigitalPlumber
{
    public class DigitalPlumberInput : IPuzzleInput<DigitalPlumberInput>
    {
        internal IEnumerable<ProgramCommunication> ProgramsCommunication { get; private set; }

        public DigitalPlumberInput ParseFromText(string textInput)
        {
            ProgramsCommunication = textInput
                .Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(programReferencesText =>
                {
                    var regex = new Regex(@"(\d+) <-> ([\d, ]+)");
                    var match = regex.Match(programReferencesText);
                    return new ProgramCommunication
                    {
                        ProgramId = int.Parse(match.Groups[1].Value),
                        ProgramReferences =
                            match.Groups[2].Value
                            .Split(',')
                            .Select(id => int.Parse(id.Trim()))
                            .ToList()
                    };
                });

            return this;
        }
    }
}