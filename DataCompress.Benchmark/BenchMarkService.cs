using BenchmarkDotNet.Attributes;
using DataCompress.Service.Huffman;
using DataCompress.Service.LZ78;

namespace DataCompress.Benchmark
{
    [RankColumn]
    [MemoryDiagnoser]
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    public class BenchMarkService
    {
        #region LZ78
        [Benchmark]
        public void LZ78_Ebook_2Mb()
        {
            string inputFile = @"C:\\Users\\dddd\\Desktop\\104The Pragmatic Programmer, From Journeyman To Master - Andrew Hunt, David Thomas - Addison Wesley - 1999.pdf";
            new LZ78().CompressLz78(inputFile);
        }

        [Benchmark]
        public void LZ78_Random_Text_File_25mb()
        {
            string inputFile = @"C:\\Users\\dddd\\Desktop\\random_text_file_25mb.pdf";
            new LZ78().CompressLz78(inputFile);
        }

        [Benchmark]
        public void LZ78_Repetitive_Text_File_50mb()
        {
            string inputFile = @"C:\\Users\\dddd\\Desktop\\random_text_file_50mb.pdf";
            new LZ78().CompressLz78(inputFile);
        }

        [Benchmark]
        public void LZ78_Random_Text_File_100mb()
        {
            string inputFile = @"C:\\Users\\dddd\\Desktop\\random_text_file_100mb.pdf";
            new LZ78().CompressLz78(inputFile);
        }
        #endregion

        #region Huffman
        [Benchmark]
        public void Huffman_Ebook_2Mb()
        {
            string inputFile = @"C:\\Users\\dddd\\Desktop\\104The Pragmatic Programmer, From Journeyman To Master - Andrew Hunt, David Thomas - Addison Wesley - 1999.pdf";
            new Huffman().CompressHuffman(inputFile);
        }

        [Benchmark]
        public void Huffman_Repetitive_Text_File_50mb()
        {
            string inputFile = @"C:\\Users\\dddd\\Desktop\\random_text_file_50mb.pdf";
            new Huffman().CompressHuffman(inputFile);
        }

        [Benchmark]
        public void Huffman_Random_Text_File_25mb()
        {
            string inputFile = @"C:\\Users\\dddd\\Desktop\\random_text_file_25mb.pdf";
            new Huffman().CompressHuffman(inputFile);
        }

        [Benchmark]
        public void Huffman_Random_Text_File_100mb()
        {
            string inputFile = @"C:\\Users\\dddd\\Desktop\\random_text_file_100mb.pdf";
            new Huffman().CompressHuffman(inputFile);
        }
        #endregion
    }
}