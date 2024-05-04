```

BenchmarkDotNet v0.13.8, Windows 10 (10.0.19045.4291/22H2/2022Update)
AMD Ryzen 5 5600, 1 CPU, 12 logical and 6 physical cores
.NET SDK 6.0.402
  [Host]     : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT AVX2 [AttachedDebugger]
  DefaultJob : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT AVX2


```
| Method                         | Mean        | Error     | StdDev    | Rank | Gen0         | Gen1        | Gen2       | Allocated   |
|------------------------------- |------------:|----------:|----------:|-----:|-------------:|------------:|-----------:|------------:|
| Huffman_Ebook_2Mb              |    285.1 ms |   2.35 ms |   2.20 ms |    1 |   22500.0000 |   2500.0000 |   500.0000 |   368.23 MB |
| LZ78_Ebook_2Mb                 |    341.6 ms |   6.43 ms |   6.02 ms |    2 |   25000.0000 |   2000.0000 |  1000.0000 |   405.53 MB |
| Huffman_Random_Text_File_100mb | 38,010.1 ms | 642.54 ms | 569.59 ms |    3 | 3263000.0000 | 221000.0000 |  8000.0000 | 52636.04 MB |
| LZ78_Random_Text_File_100mb    | 71,845.8 ms | 526.80 ms | 466.99 ms |    4 | 3628000.0000 | 392000.0000 | 16000.0000 | 59654.99 MB |
