using BenchmarkDotNet.Attributes;
using DataCompress.Service.PDF;
using iText.Forms.Form.Element;

namespace DataCompress.Service.Huffman
{
    [RankColumn]
    [MemoryDiagnoser]
    public class Huffman
    {
        [Benchmark]
        public Dictionary<char, string> CompressHuffman(string inputFile)
        {
            string input = PDFService.LerPDF(inputFile);

            Dictionary<char, int> frequencyMap = input.GroupBy(c => c).ToDictionary(g => g.Key, g => g.Count());
            List<HuffmanNode> nodes = frequencyMap.Select(pair => new HuffmanNode { Symbol = pair.Key, Frequency = pair.Value }).ToList();

            while (nodes.Count > 1)
            {
                nodes = nodes.OrderBy(node => node.Frequency).ToList();
                HuffmanNode parent = new()
                {
                    Frequency = nodes[0].Frequency + nodes[1].Frequency,
                    Left = nodes[0],
                    Right = nodes[1]
                };
                nodes.RemoveRange(0, 2);
                nodes.Add(parent);
            }

            HuffmanNode root = nodes.Single();

            Dictionary<char, string> encodingMap = new();
            Traverse(root, "", encodingMap);

            return encodingMap;
        }
        private static void Traverse(HuffmanNode node, string encoding, Dictionary<char, string> encodingMap)
        {
            if (node.Left == null && node.Right == null)
            {
                encodingMap.Add(node.Symbol, encoding);
                return;
            }

            Traverse(node.Left, encoding + "0", encodingMap);
            Traverse(node.Right, encoding + "1", encodingMap);
        }
        public static double GetCompressedSize(string compressed)
        {
            // Tamanho da mensagem comprimida em bits
            int compressedSizeInBits = compressed.Length;

            // Converter para megabytes (MB)
            double compressedSizeInMB = (double)compressedSizeInBits / (8 * 1024 * 1024);

            return compressedSizeInMB;
        }
    }
}