using System;
using Shared;

namespace Day03_SpiralMemory
{
    public class SpiralMemory : PuzzleSolver<SpiralMemoryInput>
    {
        protected override IPuzzleSolution SolveInternal(SpiralMemoryInput input)
        {
            int result;
            var layerOrder = Convert.ToInt32(Math.Ceiling(Math.Sqrt(input.RegistryNumber)));
            if (layerOrder % 2 == 0)
            {
                layerOrder++;
            }
            var numberOfLayers = Convert.ToInt32(Math.Ceiling(layerOrder / 2d));

            var maxRegistryNumber = Convert.ToInt32(Math.Pow(layerOrder, 2));
            var currentRegistryNumber = maxRegistryNumber;

            // look for given registry input in the bottom side
            var xCoordinate = numberOfLayers - 1;
            var yCoordinate = numberOfLayers - 1;
            for (var i = 0; i < layerOrder; i++, currentRegistryNumber--, xCoordinate--)
            {
                if (currentRegistryNumber == input.RegistryNumber)
                {
                    result = CountSteps(xCoordinate, yCoordinate);
                    return new SpiralMemorySolution(result);
                }
            }

            // look for given registry input in the left side
            xCoordinate = -(numberOfLayers - 1);
            yCoordinate = numberOfLayers - 2;
            for (var i = 0; i < layerOrder - 1; i++, currentRegistryNumber--, yCoordinate--)
            {
                if (currentRegistryNumber == input.RegistryNumber)
                {
                    result = CountSteps(xCoordinate, yCoordinate);
                    return new SpiralMemorySolution(result);
                }
            }

            // look for given registry input in the top side
            xCoordinate = -(numberOfLayers - 2);
            yCoordinate = -(numberOfLayers - 1);
            for (var i = 0; i < layerOrder - 1; i++, currentRegistryNumber--, xCoordinate++)
            {
                if (currentRegistryNumber == input.RegistryNumber)
                {
                    result = CountSteps(xCoordinate, yCoordinate);
                    return new SpiralMemorySolution(result);
                }
            }

            // look for given registry input in the right side
            xCoordinate = numberOfLayers - 1;
            yCoordinate = -(numberOfLayers - 2);
            for (var i = 0; i < layerOrder - 2; i++, currentRegistryNumber--, yCoordinate++)
            {
                if (currentRegistryNumber == input.RegistryNumber)
                {
                    result = CountSteps(xCoordinate, yCoordinate);
                    return new SpiralMemorySolution(result);
                }
            }

            throw new Exception("Wrong input.");
        }

        private int CountSteps(int xCoordinate, int yCoordinate)
        {
            return Math.Abs(xCoordinate) + Math.Abs(yCoordinate);
        }
    }
}
