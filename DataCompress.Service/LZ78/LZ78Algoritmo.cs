using BenchmarkDotNet.Attributes;
using DataCompress.Service.PDF;

namespace DataCompress.Service.LZ78
{


    public class LZ78
    {
        [Benchmark]
        public List<Tuple<int, char>> CompressLz78(string inputFile)
        {
            string input = PDFService.LerPDF(inputFile);

            Dictionary<string, int> dictionary = new();
            List<Tuple<int, char>> compressed = new();
            int nextCode = 1;
            string currentMatch = "";

            foreach (char c in input)
            {
                string current = currentMatch + c;
                if (dictionary.ContainsKey(current))
                {
                    currentMatch = current;
                }
                else
                {
                    if (!string.IsNullOrEmpty(currentMatch))
                    {
                        compressed.Add(new Tuple<int, char>(dictionary[currentMatch], c));
                        dictionary[current] = nextCode++;
                        currentMatch = "";
                    }
                    else
                    {
                        compressed.Add(new Tuple<int, char>(0, c));
                        dictionary[current] = nextCode++;
                    }
                }
            }

            if (!string.IsNullOrEmpty(currentMatch))
                compressed.Add(new Tuple<int, char>(dictionary[currentMatch], '\0'));

            return compressed;
        }
        public static double GetCompressedSize(List<Tuple<int, char>> compressed)
        {
            // Tamanho da mensagem comprimida em bits
            double compressedSizeInBits = compressed.Sum(tuple => Math.Ceiling(Math.Log(tuple.Item1 + 1, 2)) + 8);

            // Converter para megabytes (MB)
            double compressedSizeInMB = compressedSizeInBits / (8 * 1024 * 1024);

            return compressedSizeInMB;
        }
    }
}