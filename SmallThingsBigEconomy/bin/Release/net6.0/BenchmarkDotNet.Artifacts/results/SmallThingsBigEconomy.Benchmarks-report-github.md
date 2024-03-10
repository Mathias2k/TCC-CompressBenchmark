```

BenchmarkDotNet v0.13.8, Windows 10 (10.0.19045.3448/22H2/2022Update)
AMD FX(tm)-6300, 1 CPU, 6 logical and 3 physical cores
.NET SDK 6.0.402
  [Host]     : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT AVX [AttachedDebugger]
  DefaultJob : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT AVX


```
| Method                    | Mean       | Error     | StdDev    | Median     | Ratio | RatioSD | Rank | Gen0   | Allocated | Alloc Ratio |
|-------------------------- |-----------:|----------:|----------:|-----------:|------:|--------:|-----:|-------:|----------:|------------:|
| Equals_OrdinalIgnoreCase  |   3.922 ns | 0.1173 ns | 0.3364 ns |   3.994 ns |  1.00 |    0.00 |    1 |      - |         - |          NA |
| Compare_OrdinalIgnoreCase |   3.843 ns | 0.1252 ns | 0.3632 ns |   3.700 ns |  0.99 |    0.17 |    1 |      - |         - |          NA |
| ToLower                   | 132.409 ns | 2.6881 ns | 5.6700 ns | 134.049 ns | 34.83 |    3.36 |    3 | 0.0229 |      96 B |          NA |
| ToUpper                   |  75.128 ns | 1.2763 ns | 2.2354 ns |  74.929 ns | 20.45 |    2.16 |    2 |      - |         - |          NA |
