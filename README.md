# Tournament Simulation

This project simulates tennis tournaments with both league and elimination formats. The updated version adds **seed-based randomness**, allowing the entire season to be fully reproducible. Using the same input JSON and the same seed always produces identical results.

## Features

* Deterministic results through a **seeded RNG**
* League and elimination tournament structures
* Player skills, surface types, experience gain
* Season and tournament definitions via JSON
* Modular controllers for matches, rounds, and tournaments

## Running the Simulation

```bash
dotnet run <seed>
```

Example:

```bash
dotnet run 42
```

Using the same seed with the same data reproduces the exact same season results.
