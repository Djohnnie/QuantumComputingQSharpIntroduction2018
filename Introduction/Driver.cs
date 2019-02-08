using Microsoft.Quantum.Simulation.Simulators;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tools;
using static System.Console;

namespace Introduction
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
            using (var simulator = new QuantumSimulator())
            {
                await RunBitFlip(simulator);
                await RunHadamard(simulator);
            }
        }

        static async Task RunBitFlip(QuantumSimulator simulator)
        {
            var bf1 = await BitFlip.Run(simulator, true);
            WriteLine($"BitFlip {true.ToQubitNotation()} produces {bf1.ToQubitNotation()}");
            var bf2 = BitFlip.Run(simulator, false).Result;
            WriteLine($"BitFlip {false.ToQubitNotation()} produces {bf2.ToQubitNotation()}");
        }

        static async Task RunHadamard(QuantumSimulator simulator)
        {
            var results1 = new Dictionary<bool, int>();
            for (int i = 0; i < 10000; i++)
            {
                var h1 = await Hadamard.Run(simulator, true);
                if (results1.ContainsKey(h1))
                {
                    results1[h1]++;
                }
                else
                {
                    results1.Add(h1, 1);
                }
            }
            foreach (var result in results1.Keys)
            {
                WriteLine($"Hadamard of {true.ToQubitNotation()} produces {result.ToQubitNotation()} {results1[result]} times");
            }

            var results2 = new Dictionary<bool, int>();
            for (int i = 0; i < 10000; i++)
            {
                var h2 = Hadamard.Run(simulator, false).Result;
                if (results2.ContainsKey(h2))
                {
                    results2[h2]++;
                }
                else
                {
                    results2.Add(h2, 1);
                }
            }
            foreach (var result in results2.Keys)
            {
                WriteLine($"Hadamard of {false.ToQubitNotation()} produces {result.ToQubitNotation()} {results2[result]} times");
            }
        }
    }
}