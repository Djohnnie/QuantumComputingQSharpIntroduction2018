using Microsoft.Quantum.Simulation.Simulators;
using System;

namespace Quantum.Deutsch
{
    class Driver
    {
        static void Main(string[] args)
        {
            using (var simulator = new QuantumSimulator())
            {
                RunDeutschTestConstantZero(simulator);
                RunDeutschTestConstantOne(simulator);
                RunDeutschTestIdentity(simulator);
                RunDeutschTestNegation(simulator);
                Console.ReadKey();
            }
        }

        private static void RunDeutschTestConstantZero(QuantumSimulator simulator)
        {
            var result = DeutschTestConstantZero.Run(simulator).Result;
            CheckResult(result, "Constant-Zero");
        }

        private static void RunDeutschTestConstantOne(QuantumSimulator simulator)
        {
            var result = DeutschTestConstantOne.Run(simulator).Result;
            CheckResult(result, "Constant-One");
        }
        
        private static void RunDeutschTestIdentity(QuantumSimulator simulator)
        {
            var result = DeutschTestIdentity.Run(simulator).Result;
            CheckResult(result, "Identity");
        }

        private static void RunDeutschTestNegation(QuantumSimulator simulator)
        {
            var result = DeutschTestNegation.Run(simulator).Result;
            CheckResult(result, "Negation");
        }

        private static void CheckResult((bool, bool) result, String operation)
        {
            if (result.Item1 && result.Item2)
            {
                Console.WriteLine($"The {operation} function is CONSTANT");
            }
            else if (!result.Item1 && result.Item2)
            {
                Console.WriteLine($"The {operation} function is VARIABLE");
            }
            else
            {
                Console.WriteLine("SOMETHING IS WRONG!!!");
            }
        }
    }
}