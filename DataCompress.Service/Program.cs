using DataCompress.Service.Huffman;
using DataCompress.Service.LZ78;
using DataCompress.Service.PDF;
using static DataCompress.Service.Huffman.Huffman;

static class Program
{
    static double compressedSizeInMB = 0;
    public static void Main()
    {
        //PDFService.GerarPDF();

        //ebook
        string rawTextEbook = RawTextEbook2Mb();
        //repetitive text files
        string rawTextRepetitive5Mb = RawTextRepetitive5Mb();
        string rawTextRepetitive10Mb = RawTextRepetitive10Mb();
        //random text files
        string rawTextRandomText10Mb = RawTextRandomText10Mb();
        string rawTextRandomText25Mb = RawTextRandomText25Mb();

        LZ78_Ebook_2Mb(rawTextEbook);
        Console.WriteLine("\n");
        LZ78_Repetitive_Text_File_5mb(rawTextRepetitive5Mb);
        Console.WriteLine("\n");
        LZ78_Repetitive_Text_File_10mb(rawTextRepetitive10Mb);
        Console.WriteLine("\n");
        LZ78_Random_Text_File_10mb(rawTextRandomText10Mb);
        Console.WriteLine("\n");
        LZ78_Random_Text_File_25mb(rawTextRandomText25Mb);

        Console.WriteLine("\n");
        Console.WriteLine("***************************************************************");
        Console.WriteLine("\n");

        Huffman_Ebook_2Mb(rawTextEbook);
        Console.WriteLine("\n");
        Huffman_Repetitive_Text_File_5mb(rawTextRepetitive5Mb);
        Console.WriteLine("\n");
        Huffman_Repetitive_Text_File_10mb(rawTextRepetitive10Mb);
        Console.WriteLine("\n");
        Huffman_Random_Text_File_10mb(rawTextRandomText10Mb);
        Console.WriteLine("\n");
        Huffman_Random_Text_File_25mb(rawTextRandomText25Mb);
    }
    static string RawTextEbook2Mb()
    {
        string inputFile = @"C:\\Users\\dddd\\Desktop\\104The Pragmatic Programmer, From Journeyman To Master - Andrew Hunt, David Thomas - Addison Wesley - 1999.pdf";
        string rawText = PDFService.LerPDF(inputFile);

        return rawText;
    }
    static string RawTextRepetitive5Mb()
    {
        string inputFile = @"C:\\Users\\dddd\\Desktop\\repetitive_text_file_5mb.pdf";
        string rawText = PDFService.LerPDF(inputFile);

        return rawText;
    }
    static string RawTextRepetitive10Mb()
    {
        string inputFile = @"C:\\Users\\dddd\\Desktop\\repetitive_text_file_10mb.pdf";
        string rawText = PDFService.LerPDF(inputFile);

        return rawText;
    }
    static string RawTextRandomText10Mb()
    {
        string inputFile = @"C:\\Users\\dddd\\Desktop\\random_text_file_10mb.pdf";
        string rawText = PDFService.LerPDF(inputFile);

        return rawText;
    }
    static string RawTextRandomText25Mb()
    {
        string inputFile = @"C:\\Users\\dddd\\Desktop\\random_text_file_25mb.pdf";
        string rawText = PDFService.LerPDF(inputFile);

        return rawText;
    }

    #region LZ78
    static void LZ78_Ebook_2Mb(string rawText)
    {
        Console.WriteLine("LZ78_Ebook_2Mb");
        List<Tuple<int, char>> compressedLz78 = new LZ78().CompressLz78(rawText);
        compressedSizeInMB = LZ78.GetCompressedSize(compressedLz78);
        Console.WriteLine($"Tamanho Original: 2Mb - Tamanho da mensagem comprimida  {Math.Round(compressedSizeInMB, 2)} Mb");
    }
    static void LZ78_Repetitive_Text_File_5mb(string rawText)
    {
        Console.WriteLine("LZ78_Repetitive_Text_File_5mb");
        List<Tuple<int, char>> compressedLz78 = new LZ78().CompressLz78(rawText);
        compressedSizeInMB = LZ78.GetCompressedSize(compressedLz78);
        Console.WriteLine($"Tamanho Original: 5Mb - Tamanho da mensagem comprimida  {Math.Round(compressedSizeInMB, 2)} Mb");
    }
    static void LZ78_Repetitive_Text_File_10mb(string rawText)
    {
        Console.WriteLine("LZ78_Repetitive_Text_File_10mb");
        List<Tuple<int, char>> compressedLz78 = new LZ78().CompressLz78(rawText);
        compressedSizeInMB = LZ78.GetCompressedSize(compressedLz78);
        Console.WriteLine($"Tamanho Original: 10Mb - Tamanho da mensagem comprimida  {Math.Round(compressedSizeInMB, 2)} Mb");
    }

    static void LZ78_Random_Text_File_10mb(string rawText)
    {
        Console.WriteLine("LZ78_Random_Text_File_10mb");
        List<Tuple<int, char>> compressedLz78 = new LZ78().CompressLz78(rawText);
        compressedSizeInMB = LZ78.GetCompressedSize(compressedLz78);
        Console.WriteLine($"Tamanho Original: 10Mb - Tamanho da mensagem comprimida  {Math.Round(compressedSizeInMB, 2)} Mb");
    }
    static void LZ78_Random_Text_File_25mb(string rawText)
    {
        Console.WriteLine("LZ78_Random_Text_File_25mb");
        List<Tuple<int, char>> compressedLz78 = new LZ78().CompressLz78(rawText);
        compressedSizeInMB = LZ78.GetCompressedSize(compressedLz78);
        Console.WriteLine($"Tamanho Original: 25Mb - Tamanho da mensagem comprimida  {Math.Round(compressedSizeInMB, 2)} Mb");
    }
    #endregion

    #region Huffman
    static void Huffman_Ebook_2Mb(string rawText)
    {
        Console.WriteLine("Huffman_Ebook_2Mb");
        Dictionary<char, string> encodingMap = new Huffman().CompressHuffman(rawText);
        string compressedHuffman = string.Join("", rawText.Select(c => encodingMap[c]));
        compressedSizeInMB = GetCompressedSize(compressedHuffman);
        Console.WriteLine($"Tamanho Original: 2Mb - Tamanho da mensagem comprimida {Math.Round(compressedSizeInMB, 2)} Mb");
    }
    static void Huffman_Repetitive_Text_File_5mb(string rawText)
    {
        Console.WriteLine("Huffman_Repetitive_Text_File_5mb");
        Dictionary<char, string> encodingMap = new Huffman().CompressHuffman(rawText);
        string compressedHuffman = string.Join("", rawText.Select(c => encodingMap[c]));
        compressedSizeInMB = GetCompressedSize(compressedHuffman);
        Console.WriteLine($"Tamanho Original: 5Mb - Tamanho da mensagem comprimida {Math.Round(compressedSizeInMB, 2)} Mb");
    }
    static void Huffman_Repetitive_Text_File_10mb(string rawText)
    {
        Console.WriteLine("Huffman_Repetitive_Text_File_10mb");
        Dictionary<char, string> encodingMap = new Huffman().CompressHuffman(rawText);
        string compressedHuffman = string.Join("", rawText.Select(c => encodingMap[c]));
        compressedSizeInMB = GetCompressedSize(compressedHuffman);
        Console.WriteLine($"Tamanho Original: 10Mb - Tamanho da mensagem comprimida {Math.Round(compressedSizeInMB, 2)} Mb");
    }

    static void Huffman_Random_Text_File_10mb(string rawText)
    {
        Console.WriteLine("Huffman_Random_Text_File_10mb");
        Dictionary<char, string> encodingMap = new Huffman().CompressHuffman(rawText);
        string compressedHuffman = string.Join("", rawText.Select(c => encodingMap[c]));
        compressedSizeInMB = GetCompressedSize(compressedHuffman);
        Console.WriteLine($"Tamanho Original: 10Mb - Tamanho da mensagem comprimida {Math.Round(compressedSizeInMB, 2)} Mb");
    }
    static void Huffman_Random_Text_File_25mb(string rawText)
    {
        Console.WriteLine("Huffman_Random_Text_File_25mb");
        Dictionary<char, string> encodingMap = new Huffman().CompressHuffman(rawText);
        string compressedHuffman = string.Join("", rawText.Select(c => encodingMap[c]));
        compressedSizeInMB = GetCompressedSize(compressedHuffman);
        Console.WriteLine($"Tamanho Original: 25Mb - Tamanho da mensagem comprimida {Math.Round(compressedSizeInMB, 2)} Mb");
    }
    #endregion
}