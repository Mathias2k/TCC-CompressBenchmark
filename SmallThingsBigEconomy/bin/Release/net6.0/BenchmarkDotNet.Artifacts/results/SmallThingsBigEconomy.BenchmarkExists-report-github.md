```

BenchmarkDotNet v0.13.8, Windows 10 (10.0.19045.4046/22H2/2022Update)
AMD Ryzen 5 5600, 1 CPU, 12 logical and 6 physical cores
.NET SDK 6.0.402
  [Host]     : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT AVX2 [AttachedDebugger]
  DefaultJob : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT AVX2


```
| Method | Mean     | Error     | StdDev    | Ratio | Rank | Allocated | Alloc Ratio |
|------- |---------:|----------:|----------:|------:|-----:|----------:|------------:|
| Any    | 7.009 ms | 0.0708 ms | 0.0662 ms |  1.00 |    2 |      45 B |        1.00 |
| Exists | 2.038 ms | 0.0172 ms | 0.0144 ms |  0.29 |    1 |       2 B |        0.04 |
