using Shared;
using System;
using System.Linq;

namespace Day18_Duet
{
    public class DuetInput : IPuzzleInput<DuetInput>
    {
        internal Operation[] Operations { get; set; }

        public DuetInput ParseFromText(string textInput)
        {
            Operations = textInput
                .Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(opText =>
                {
                    var commandAndArgs = opText.Split(' ');
                    switch (commandAndArgs[0])
                    {
                        case "snd":
                            return new Sound(commandAndArgs[1]) as Operation;
                        case "set":
                            return new Set(commandAndArgs[1], commandAndArgs[2]) as Operation;
                        case "add":
                            return new Add(commandAndArgs[1], commandAndArgs[2]) as Operation;
                        case "mul":
                            return new Multiplicate(commandAndArgs[1], commandAndArgs[2]) as Operation;
                        case "mod":
                            return new Modulo(commandAndArgs[1], commandAndArgs[2]) as Operation;
                        case "rcv":
                            return new Recover(commandAndArgs[1]) as Operation;
                        case "jgz":
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