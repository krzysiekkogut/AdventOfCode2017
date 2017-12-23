using Shared;
using System;
using System.Linq;

namespace Day23_CoprocessorConflagration
{
    public class CoprocessorConflagrationInput : IPuzzleInput<CoprocessorConflagrationInput>
    {
        internal Operation[] Operations { get; set; }

        public CoprocessorConflagrationInput ParseFromText(string textInput)
        {
            Operations = textInput
                            .Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                            .Select(opText =>
                            {
                                var commandAndArgs = opText.Split(' ');
                                switch (commandAndArgs[0])
                                {
                                    case "set":
                                        return new Set(commandAndArgs[1], commandAndArgs[2]) as Operation;
                                    case "sub":
                                        return new Substract(commandAndArgs[1], commandAndArgs[2]) as Operation;
                                    case "mul":
                                        return new Multiplicate(commandAndArgs[1], commandAndArgs[2]) as Operation;
                                    case "jnz":
                                        return new Jump(commandAndArgs[1], commandAndArgs[2]) as Operation;
                                    default:
                                        throw new Exception("Wrong input.");
                                }
                            })
                            .ToArray();
            return this;
        }
    }
}