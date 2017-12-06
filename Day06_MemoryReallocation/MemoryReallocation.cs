﻿using Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Day06_MemoryReallocation
{
    public class MemoryReallocation : PuzzleSolver<MemoryReallocationInput>, IPuzzleSolver
    {
        private bool _shouldReturnOnlyCycleLength;

        public MemoryReallocation(bool shouldReturnOnlyCycleLength)
        {
            _shouldReturnOnlyCycleLength = shouldReturnOnlyCycleLength;
        }

        protected override MemoryReallocationInput ParseInput(string inputText)
        {
            return new MemoryReallocationInput().ParseFromText(inputText);
        }

        protected override int SolveInternal(MemoryReallocationInput input)
        {
            var numberOfBanks = input.Banks.Length;
            var memoryStates = new Dictionary<string, int>();
            var statesCount = 0;
            var currentState = input.ToString();
            while (!memoryStates.ContainsKey(currentState))
            {
                memoryStates.Add(input.ToString(), statesCount);
                var indexOfBankWithMostMemoryBlocks = Array.IndexOf(input.Banks, input.Banks.Max());
                var numberOfBlocksToDistribute = input.Banks[indexOfBankWithMostMemoryBlocks];
                input.Banks[indexOfBankWithMostMemoryBlocks] = 0;

                var currentIndex = (indexOfBankWithMostMemoryBlocks + 1) % numberOfBanks;
                while (numberOfBlocksToDistribute > 0)
                {
                    input.Banks[currentIndex]++;
                    numberOfBlocksToDistribute--;
                    currentIndex = (currentIndex + 1) % numberOfBanks;
                }

                statesCount++;
                currentState = input.ToString();
            }

            return _shouldReturnOnlyCycleLength ? statesCount - memoryStates[currentState] : statesCount;
        }
    }
}
