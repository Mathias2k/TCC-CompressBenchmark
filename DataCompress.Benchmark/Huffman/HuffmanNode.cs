namespace DataCompress.Benchmark.Huffman
{
    class HuffmanNode
    {
        public char Data { get; set; }
        public int Frequency { get; set; }
        public HuffmanNode Left { get; set; }
        public HuffmanNode Right { get; set; }
    }
}