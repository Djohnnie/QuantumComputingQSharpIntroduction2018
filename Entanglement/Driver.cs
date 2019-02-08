using Microsoft.Quantum.Simulation.Simulators;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tools;
using static System.Console;

namespace Entanglement
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
            Dictionary<(bool, bool), int> results = new Dictionary<(bool, bool), int>();
            using (var simulator = new QuantumSimulator())
            {
                for (int i = 0; i < 10000; i++)
                {
                    var bits = await Entangle.Run(simulator);
                    if (results.ContainsKey(bits))
                    {
                        results[bits]++;
                    }
                    else
                    {
                        results.Add(bits, 1);
                    }
                }
            }

            foreach (var result in results.Keys)
            {
                WriteLine($"{result.ToQubitNotation()}: {results[result]} times");
            }
        }
    }
}