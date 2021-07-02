``` ini

BenchmarkDotNet=v0.13.0, OS=Windows 10.0.19042.1052 (20H2/October2020Update)
AMD Ryzen 9 4900HS with Radeon Graphics, 1 CPU, 16 logical and 8 physical cores
.NET SDK=5.0.300
  [Host]     : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT  [AttachedDebugger]
  DefaultJob : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT


```
|     Method |       Mean |    Error |   StdDev |
|----------- |-----------:|---------:|---------:|
|  Fibonacci |   205.7 ns |  4.07 ns |  3.80 ns |
| Fibonacci2 |   159.7 ns |  1.52 ns |  2.23 ns |
| Fibonacci4 | 3,228.5 ns | 47.62 ns | 39.76 ns |
