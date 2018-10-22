using Microsoft.Quantum.Simulation.Simulators;
using System;
using System.Collections.Generic;

namespace Quantum.Introduction
{
    class Driver
    {
        static void Main(string[] args)
        {
            using (var simulator = new QuantumSimulator())
            {
                RunBitFlip(simulator);
                RunHadamard(simulator);
            }

            Console.ReadKey();
        }

        static void RunBitFlip(QuantumSimulator simulator)
        {
            var bf1 = BitFlip.Run(simulator, true).Result;
            Console.WriteLine($"BitFlip ({true}) produces ({bf1})!");
            var bf2 = BitFlip.Run(simulator, false).Result;
            Console.WriteLine($"BitFlip ({false}) produces ({bf2})!");
        }

        static void RunHadamard(QuantumSimulator simulator)
        {
            Dictionary<bool, int> results1 = new Dictionary<bool, int>();
            for (int i = 0; i < 10000; i++)
            {
                var h1 = Hadamard.Run(simulator, true).Result;
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
                Console.WriteLine($"Hadamard of ({true}) is ({result}): {results1[result]} times");
            }

            Dictionary<bool, int> results2 = new Dictionary<bool, int>();
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
                Console.WriteLine($"Hadamard of ({false}) is ({result}): {results2[result]} times");
            }
        }
    }
}