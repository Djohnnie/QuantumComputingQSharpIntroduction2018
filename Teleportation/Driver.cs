using System;
using Microsoft.Quantum.Simulation.Simulators;

namespace Quantum.Teleportation
{
    class Driver
    {
        static void Main(string[] args)
        {
            System.Random randomGenerator = new System.Random();
            using (var simulator = new QuantumSimulator())
            {
                for (int i = 0; i < 10; i++)
                {
                    bool randomMessage = randomGenerator.Next(0, 2) == 1;
                    bool result = Teleport.Run(simulator, randomMessage).Result;
                    Console.WriteLine($"Teleported ({randomMessage}) resulted in ({result})");
                }
            }

            Console.ReadKey();
        }
    }
}