using BenchmarkDotNet.Running;

BenchmarkRunner.Run<DataCompress.Benchmark.Huffman.HuffmanTree>();
BenchmarkRunner.Run<DataCompress.Benchmark.LZ78.LZ78>();