```

BenchmarkDotNet v0.13.8, Windows 10 (10.0.19045.4046/22H2/2022Update)
AMD Ryzen 5 5600, 1 CPU, 12 logical and 6 physical cores
.NET SDK 6.0.402
  [Host]     : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT AVX2 [AttachedDebugger]
  DefaultJob : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT AVX2


```
| Method   | Mean     | Error   | StdDev  | Ratio | Rank | Gen0   | Allocated | Alloc Ratio |
|--------- |---------:|--------:|--------:|------:|-----:|-------:|----------:|------------:|
| Compress | 382.1 ns | 3.44 ns | 3.05 ns |  1.00 |    1 | 0.1011 |   1.66 KB |        1.00 |
