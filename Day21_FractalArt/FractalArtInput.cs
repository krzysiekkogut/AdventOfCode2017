using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day21_FractalArt
{
    public class FractalArtInput : IPuzzleInput<FractalArtInput>
    {
        public Dictionary<string, string> Rules { get; set; } = new Dictionary<string, string>();

        public FractalArtInput ParseFromText(string textInput)
        {
            var rulesTexts = textInput.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            foreach (var ruleText in rulesTexts)
            {
                var split = ruleText.Split(" => ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                var ruleInput = split[0];
                var ruleOutput = split[1];

                TryAddRule(ruleInput, ruleOutput);
                TryAddRule(ruleInput.Rotate(), ruleOutput);
                TryAddRule(ruleInput.Rotate().Rotate(), ruleOutput);
                TryAddRule(ruleInput.Rotate().Rotate().Rotate(), ruleOutput);

                TryAddRule(ruleInput.FlipVertical(), ruleOutput);
                TryAddRule(ruleInput.Rotate().FlipVertical(), ruleOutput);
                TryAddRule(ruleInput.Rotate().Rotate().FlipVertical(), ruleOutput);
                TryAddRule(ruleInput.Rotate().Rotate().Rotate().FlipVertical(), ruleOutput);
            }

            return this;
        }

        private void TryAddRule(string ruleInput, string ruleOutput)
        {
            if (!Rules.ContainsKey(ruleInput))
            {
                Rules.Add(ruleInput, ruleOutput);
            }
        }
    }
}