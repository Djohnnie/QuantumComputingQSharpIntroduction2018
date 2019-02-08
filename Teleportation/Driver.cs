using System;
using System.Threading.Tasks;
using Microsoft.Quantum.Simulation.Simulators;
using Tools;
using static System.Console;

namespace Teleportation
{
    class Driver
    {
        static void Main(string[] args)
        {
            MainAsync().GetAwaiter().GetResult();
            ReadKey();
        }

        static async Task MainAsync()
        {
            Random randomGenerator = new System.Random();
            using (var simulator = new QuantumSimulator())
            {
                for (int i = 0; i < 10; i++)
                {
                    bool randomMessage = randomGenerator.Next(0, 2) == 1;
                    bool result = await Teleport.Run(simulator, randomMessage);
                    WriteLine($"Teleported ({randomMessage.ToQubitNotation()}) resulted in ({result.ToQubitNotation()})");
                }
            }
        }
    }
}