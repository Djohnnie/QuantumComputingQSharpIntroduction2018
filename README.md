# QuantumComputingQSharpIntroduction2018

This Visual Studio Solution uses the Quantum Development Kit extension for Visual Studio 2017 and contains four Q# projects plus an additional C# class library. Each Q# project is an example of an algorithm talked about during the [Quantum Computing Deep Dive](https://www.slideshare.net/djohnnieke/quantum-computing-deep-dive) talk.

## 1. Introduction

This example will run the bitflip (X) gate on a qubit with state |0> and a qubit with state |1> and it will put a qubit in superposition ,measuring it 10.000 times, resulting in about 5.000 times |0> and about 5.000 times |1>.

## 2. Deutschs Algorithm

This example implements the Deutsch algorithm to evaluate if a blackbox function (Constant-Zero, Constant-One, Identity, Negation) is a constant or variable function.

## 3. Entanglement

This example entangles two qubits and measures them 10.000 times, resulting in about 5.000 times the state |00> and about 5.000 times the state |11>.

## 4. Teleportation

This example teleports a message qubit between two entangled qubits, one from Alice and one from Bob. The experiment is executed 10 times where the message is a random qubit state of |0> or |1>.
