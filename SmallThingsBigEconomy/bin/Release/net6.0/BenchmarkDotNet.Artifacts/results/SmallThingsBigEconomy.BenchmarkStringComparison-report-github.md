```

BenchmarkDotNet v0.13.8, Windows 10 (10.0.19045.4046/22H2/2022Update)
AMD Ryzen 5 5600, 1 CPU, 12 logical and 6 physical cores
.NET SDK 6.0.402
  [Host]     : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT AVX2 [AttachedDebugger]
  DefaultJob : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT AVX2


```
| Method                    | Mean      | Error     | StdDev    | Ratio | RatioSD | Rank | Gen0   | Allocated | Alloc Ratio |
|-------------------------- |----------:|----------:|----------:|------:|--------:|-----:|-------:|----------:|------------:|
| Equals_OrdinalIgnoreCase  |  1.048 ns | 0.0102 ns | 0.0085 ns |  1.00 |    0.00 |    1 |      - |         - |          NA |
| Compare_OrdinalIgnoreCase |  2.557 ns | 0.0085 ns | 0.0076 ns |  2.44 |    0.02 |    2 |      - |         - |          NA |
| ToLower                   | 47.913 ns | 0.6798 ns | 0.6359 ns | 45.75 |    0.70 |    4 | 0.0057 |      96 B |          NA |
| ToUpper                   | 30.003 ns | 0.0793 ns | 0.0742 ns | 28.61 |    0.25 |    3 |      - |         - |          NA |
