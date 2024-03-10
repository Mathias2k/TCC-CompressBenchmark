using BenchmarkDotNet.Running;

BenchmarkRunner.Run<LZ78.DataCompress.Benchmark.Huffman.HuffmanTree>();
BenchmarkRunner.Run<LZ78.DataCompress.Benchmark.LZ78.LZ78>();