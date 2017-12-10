using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day07_RecursiveCircus
{
    public class RecursiveCircusInput : IPuzzleInput<RecursiveCircusInput>
    {
        internal IList<ProgramNode> Programs { get; set; }

        public RecursiveCircusInput ParseFromText(string textInput)
        {
            Programs = textInput
                .Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(programReferencesText =>
                {
                    var regex = new Regex(@"(\w+) \((\d+)\)( -> ([\w, ]*))?");
                    var match = regex.Match(programReferencesText);
                    return new ProgramNode
                    {
                        Name = match.Groups[1].Value,
                        Weight = int.Parse(match.Groups[2].Value),
                        SubtreeWeight = int.Parse(match.Groups[2].Value),
                        ReferencesNames =
                            match
                            .Groups[4]
                            .Value
                            .Split(',')
                            .Where(s => !string.IsNullOrWhiteSpace(s))
                            .Select(s => s.Trim())
                    };
                })
                .ToList();

            return this;
        }
    }
}
