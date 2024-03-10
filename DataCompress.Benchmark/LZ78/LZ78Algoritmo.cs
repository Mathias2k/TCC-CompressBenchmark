using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCompress.Benchmark.LZ78
{
    [RankColumn]
    [MemoryDiagnoser]
    public class LZ78
    {
        [Benchmark(Baseline = true)]
        public void LZ78Compress()
        {
            string input = "ABCABCBABCBABBCBCBCBEBEBDBEBABDBABBDBABABABABABABABABABABABABAABAB";
            Dictionary<string, int> dictionary = new();
            List<Tuple<int, char>> compressed = new();
            string current = "";
            int nextCode = 1;

            foreach (char c in input)
            {
                string temp = current + c;
                if (dictionary.ContainsKey(temp))
                {
                    current = temp;
                }
                else
                {
                    if (current != "")
                    {
                        compressed.Add(new Tuple<int, char>(dictionary[current], c));
                    }
                    else
                    {
                        compressed.Add(new Tuple<int, char>(0, c));
                    }
                    dictionary[temp] = nextCode++;
                    current = "";
                }
            }

            if (current != "")
            {
                compressed.Add(new Tuple<int, char>(dictionary[current], '\0'));
            }
        }

        //[Benchmark]
        //public static string Decompress(List<Tuple<int, char>> compressed)
        //{
        //    Dictionary<int, string> dictionary = new Dictionary<int, string>();
        //    string current = "";
        //    string decompressed = "";

        //    int nextCode = 1;

        //    foreach (Tuple<int, char> tuple in compressed)
        //    {
        //        if (tuple.Item1 == 0)
        //        {
        //            current = tuple.Item2.ToString();
        //            decompressed += current;
        //        }
        //        else
        //        {
        //            current = dictionary[tuple.Item1] + tuple.Item2;
        //            decompressed += current;
        //        }
        //        dictionary[nextCode++] = current;
        //    }

        //    return decompressed;
        //}

        //public static void Main(string[] args)
        //{

        //List<Tuple<int, char>> compressed = Compress();


        //string decompressed = Decompress(compressed);
        //Console.WriteLine("\nDecompressed: " + decompressed);
        //}
    }
}
