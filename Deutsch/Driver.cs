using System;
using System.Threading.Tasks;
using Microsoft.Quantum.Simulation.Simulators;
using Tools;

namespace Deutsch
{
    class Driver
    {
        static void Main(string[] args)
        {
            MainAsync().GetAwaiter().GetResult();
            Console.ReadKey();
        }

        static async Task MainAsync()
        {
            using (var simulator = new QuantumSimulator())
            {
                await RunDeutschTestConstantZero(simulator);
                await RunDeutschTestConstantOne(simulator);
                await RunDeutschTestIdentity(simulator);
                await RunDeutschTestNegation(simulator);
            }
        }

        private static async Task RunDeutschTestConstantZero(QuantumSimulator simulator)
        {
            var result = await DeutschTestConstantZero.Run(simulator);
            CheckResult(result, "Constant-Zero");
        }

        private static async Task RunDeutschTestConstantOne(QuantumSimulator simulator)
        {
            var result = await DeutschTestConstantOne.Run(simulator);
            CheckResult(result, "Constant-One");
        }

        private static async Task RunDeutschTestIdentity(QuantumSimulator simulator)
        {
            var result = await DeutschTestIdentity.Run(simulator);
            CheckResult(result, "Identity");
        }

        private static async Task RunDeutschTestNegation(QuantumSimulator simulator)
        {
            var result = await DeutschTestNegation.Run(simulator);
            CheckResult(result, "Negation");
        }

        private static void CheckResult((bool, bool) result, String operation)
        {
            if (result.Item1 && result.Item2)
            {
                Console.WriteLine($"The {operation} function is CONSTANT ({result.ToQubitNotation()})");
            }
            else if (!result.Item1 && result.Item2)
            {
                Console.WriteLine($"The {operation} function is VARIABLE ({result.ToQubitNotation()})");
            }
            else
            {
                Console.WriteLine($"SOMETHING IS WRONG  ({result.ToQubitNotation()})");
            }
        }
    }
}