using Microsoft.Quantum.Simulation.Simulators;
using System;
using System.Collections.Generic;

namespace Quantum.Entanglement
{
    class Driver
    {
        static void Main(string[] args)
        {
            Dictionary<(bool, bool), int> results = new Dictionary<(bool, bool), int>();
            using (var simulator = new QuantumSimulator())
            {
                for (int i = 0; i < 10000; i++)
                {
                    var bits = Entangle.Run(simulator).Result;
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
                Console.WriteLine($"{result}: {results[result]} times");
            }

            Console.ReadKey();
        }
    }
}