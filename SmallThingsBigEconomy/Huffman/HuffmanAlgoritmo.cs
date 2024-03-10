using BenchmarkDotNet.Attributes;

namespace LZ78.DataCompress.Benchmark.Huffman
{
    [RankColumn]
    [MemoryDiagnoser]
    public class HuffmanTree
    {
        private Dictionary<char, string> _encodingTable;

        [Benchmark(Baseline = true)]
        public void HuffmanCompress()
        {
            string input = "ABCABCBABCBABBCBCBCBEBEBDBEBABDBABBDBABABABABABABABABABABABABAABAB";
            _encodingTable = new Dictionary<char, string>();
            Dictionary<char, int> frequencyTable = new();

            foreach (char c in input)
            {
                if (!frequencyTable.ContainsKey(c))
                    frequencyTable[c] = 0;
                frequencyTable[c]++;
            }

            List<HuffmanNode> nodes = frequencyTable.Select(kv => new HuffmanNode { Data = kv.Key, Frequency = kv.Value }).ToList();

            while (nodes.Count > 1)
            {
                nodes.Sort((x, y) => x.Frequency.CompareTo(y.Frequency));
                HuffmanNode left = nodes[0];
                HuffmanNode right = nodes[1];
                nodes.Remove(left);
                nodes.Remove(right);
                HuffmanNode parent = new HuffmanNode { Data = '*', Frequency = left.Frequency + right.Frequency, Left = left, Right = right };
                nodes.Add(parent);
            }

            HuffmanNode root = nodes.FirstOrDefault();
            BuildEncodingTable(root, "");
            string encodedString = string.Join("", input.Select(c => _encodingTable[c]));
            //Console.WriteLine("Encoded string: " + encodedString);
        }

        private void BuildEncodingTable(HuffmanNode node, string code)
        {
            if (node == null) return;
            if (node.Left == null && node.Right == null)
            {
                _encodingTable[node.Data] = code;
                return;
            }
            BuildEncodingTable(node.Left, code + "0");
            BuildEncodingTable(node.Right, code + "1");
        }
    }

    //decompress
    //    using System;
    //using System.Collections.Generic;

    //class HuffmanNode
    //    {
    //        public char Data { get; set; }
    //        public int Frequency { get; set; }
    //        public HuffmanNode Left { get; set; }
    //        public HuffmanNode Right { get; set; }
    //    }

    //    class HuffmanTree
    //    {
    //        private static Dictionary<char, string> _encodingTable;

    //        public static void Compress(string input)
    //        {
    //            _encodingTable = new Dictionary<char, string>();
    //            Dictionary<char, int> frequencyTable = new Dictionary<char, int>();

    //            foreach (char c in input)
    //            {
    //                if (!frequencyTable.ContainsKey(c))
    //                    frequencyTable[c] = 0;
    //                frequencyTable[c]++;
    //            }

    //            List<HuffmanNode> nodes = frequencyTable.Select(kv => new HuffmanNode { Data = kv.Key, Frequency = kv.Value }).ToList();

    //            while (nodes.Count > 1)
    //            {
    //                nodes.Sort((x, y) => x.Frequency.CompareTo(y.Frequency));
    //                HuffmanNode left = nodes[0];
    //                HuffmanNode right = nodes[1];
    //                nodes.Remove(left);
    //                nodes.Remove(right);
    //                HuffmanNode parent = new HuffmanNode { Data = '*', Frequency = left.Frequency + right.Frequency, Left = left, Right = right };
    //                nodes.Add(parent);
    //            }

    //            HuffmanNode root = nodes.FirstOrDefault();
    //            BuildEncodingTable(root, "");
    //            string encodedString = string.Join("", input.Select(c => _encodingTable[c]));
    //            Console.WriteLine("Encoded string: " + encodedString);
    //        }

    //        private static void BuildEncodingTable(HuffmanNode node, string code)
    //        {
    //            if (node == null) return;
    //            if (node.Left == null && node.Right == null)
    //            {
    //                _encodingTable[node.Data] = code;
    //                return;
    //            }
    //            BuildEncodingTable(node.Left, code + "0");
    //            BuildEncodingTable(node.Right, code + "1");
    //        }

    //        public static string Decompress(string encodedString)
    //        {
    //            string result = "";
    //            HuffmanNode current = root;
    //            foreach (char bit in encodedString)
    //            {
    //                if (bit == '0')
    //                    current = current.Left;
    //                else
    //                    current = current.Right;

    //                if (current.Left == null && current.Right == null)
    //                {
    //                    result += current.Data;
    //                    current = root;
    //                }
    //            }
    //            return result;
    //        }
    //    }

    //    class Program
    //    {
    //        static void Main(string[] args)
    //        {
    //            string input = "hello world";
    //            Console.WriteLine("Original string: " + input);
    //            HuffmanTree.Compress(input);
    //        }
    //    }

}
