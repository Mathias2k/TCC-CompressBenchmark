```

BenchmarkDotNet v0.13.8, Windows 10 (10.0.19045.4291/22H2/2022Update)
AMD Ryzen 5 5600, 1 CPU, 12 logical and 6 physical cores
.NET SDK 6.0.402
  [Host]     : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT AVX2 [AttachedDebugger]
  DefaultJob : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT AVX2


```
| Method       | Mean     | Error   | StdDev  | Rank | Gen0       | Gen1      | Gen2      | Allocated |
|------------- |---------:|--------:|--------:|-----:|-----------:|----------:|----------:|----------:|
| CompressLz78 | 334.6 ms | 4.49 ms | 3.98 ms |    1 | 25000.0000 | 2000.0000 | 1000.0000 | 405.53 MB |
