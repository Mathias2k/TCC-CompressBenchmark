using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LZ78.DataCompress.Service.LZ78
{
    public class LZ78
    {
        public static List<Tuple<int, char>> LZ78Compress(string input)
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            List<Tuple<int, char>> compressed = new List<Tuple<int, char>>();
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

            return compressed;
        }
        public static string Decompress(List<Tuple<int, char>> compressed)
        {
            Dictionary<int, string> dictionary = new();
            string current = "";
            string decompressed = "";

            int nextCode = 1;

            foreach (Tuple<int, char> tuple in compressed)
            {
                if (tuple.Item1 == 0)
                {
                    current = tuple.Item2.ToString();
                    decompressed += current;
                }
                else
                {
                    current = dictionary[tuple.Item1] + tuple.Item2;
                    decompressed += current;
                }
                dictionary[nextCode++] = current;
            }

            return decompressed;
        }
    }
}
