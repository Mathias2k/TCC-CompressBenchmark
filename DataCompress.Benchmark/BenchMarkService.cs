using BenchmarkDotNet.Attributes;
using DataCompress.Service.Huffman;
using DataCompress.Service.LZ78;
using DataCompress.Service.PDF;

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
            string rawText = PDFService.LerPDF(inputFile);
            new LZ78().CompressLz78(rawText);
        }

        [Benchmark]
        public void LZ78_Repetitive_Text_File_5mb()
        {
            string inputFile = @"C:\\Users\\dddd\\Desktop\\repetitive_text_file_5mb.pdf";
            string rawText = PDFService.LerPDF(inputFile);
            new LZ78().CompressLz78(rawText);
        }

        [Benchmark]
        public void LZ78_Repetitive_Text_File_10mb()
        {
            string inputFile = @"C:\\Users\\dddd\\Desktop\\repetitive_text_file_10mb.pdf";
            string rawText = PDFService.LerPDF(inputFile);
            new LZ78().CompressLz78(rawText);
        }

        [Benchmark]
        public void LZ78_Random_Text_File_10mb()
        {
            string inputFile = @"C:\\Users\\dddd\\Desktop\\random_text_file_10mb.pdf";
            string rawText = PDFService.LerPDF(inputFile);
            new LZ78().CompressLz78(rawText);
        }

        [Benchmark]
        public void LZ78_Random_Text_File_25mb()
        {
            string inputFile = @"C:\\Users\\dddd\\Desktop\\random_text_file_25mb.pdf";
            string rawText = PDFService.LerPDF(inputFile);
            new LZ78().CompressLz78(rawText);
        }
        #endregion

        #region Huffman
        [Benchmark]
        public void Huffman_Ebook_2Mb()
        {
            string inputFile = @"C:\\Users\\dddd\\Desktop\\104The Pragmatic Programmer, From Journeyman To Master - Andrew Hunt, David Thomas - Addison Wesley - 1999.pdf";
            string rawText = PDFService.LerPDF(inputFile);
            new Huffman().CompressHuffman(rawText);
        }

        [Benchmark]
        public void Huffman_Repetitive_Text_File_5mb()
        {
            string inputFile = @"C:\\Users\\dddd\\Desktop\\repetitive_text_file_5mb.pdf";
            string rawText = PDFService.LerPDF(inputFile);
            new Huffman().CompressHuffman(rawText);
        }

        [Benchmark]
        public void Huffman_Repetitive_Text_File_10mb()
        {
            string inputFile = @"C:\\Users\\dddd\\Desktop\\repetitive_text_file_10mb.pdf";
            string rawText = PDFService.LerPDF(inputFile);
            new Huffman().CompressHuffman(rawText);
        }

        [Benchmark]
        public void Huffman_Random_Text_File_10mb()
        {
            string inputFile = @"C:\\Users\\dddd\\Desktop\\random_text_file_10mb.pdf";
            string rawText = PDFService.LerPDF(inputFile);
            new Huffman().CompressHuffman(rawText);
        }

        [Benchmark]
        public void Huffman_Random_Text_File_25mb()
        {
            string inputFile = @"C:\\Users\\dddd\\Desktop\\random_text_file_25mb.pdf";
            string rawText = PDFService.LerPDF(inputFile);
            new Huffman().CompressHuffman(rawText);
        }
        #endregion
    }
}