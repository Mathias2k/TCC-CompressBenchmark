```

BenchmarkDotNet v0.13.8, Windows 10 (10.0.19045.3448/22H2/2022Update)
AMD FX(tm)-6300, 1 CPU, 6 logical and 3 physical cores
.NET SDK 6.0.402
  [Host]     : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT AVX [AttachedDebugger]
  DefaultJob : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT AVX


```
| Method                    | Mean       | Error     | StdDev    | Median     | Ratio | RatioSD | Rank | Gen0   | Allocated | Alloc Ratio |
|-------------------------- |-----------:|----------:|----------:|-----------:|------:|--------:|-----:|-------:|----------:|------------:|
| Equals_OrdinalIgnoreCase  |   3.667 ns | 0.1025 ns | 0.0856 ns |   3.674 ns |  1.00 |    0.00 |    1 |      - |         - |          NA |
| Compare_OrdinalIgnoreCase |   3.742 ns | 0.1213 ns | 0.3500 ns |   3.609 ns |  1.14 |    0.09 |    1 |      - |         - |          NA |
| ToLower                   | 143.175 ns | 2.8803 ns | 4.2220 ns | 142.050 ns | 39.20 |    1.37 |    3 | 0.0229 |      96 B |          NA |
| ToUpper                   |  72.549 ns | 1.4538 ns | 1.3599 ns |  72.541 ns | 19.82 |    0.49 |    2 |      - |         - |          NA |
