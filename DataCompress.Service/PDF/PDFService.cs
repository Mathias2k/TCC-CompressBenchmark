using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Layout;
using iText.Layout.Element;
using System.Text;

namespace DataCompress.Service.PDF
{
    public class PDFService
    {
        public static string LerPDF(string inputFile)
        {
            using PdfReader reader = new(inputFile);
            //Console.WriteLine($"tamanho original do arquivo: {reader.GetFileLength() / (1024 * 1024)} Mb");
            //Console.WriteLine("\n");
            using PdfDocument pdfDoc = new(reader);

            StringBuilder texto = new();
            for (int pageNum = 1; pageNum <= pdfDoc.GetNumberOfPages(); pageNum++)
                texto.Append(PdfTextExtractor.GetTextFromPage(pdfDoc.GetPage(pageNum)));

            pdfDoc.Close();
            reader.Close();

            return texto.ToString();
        }
        public static void ComprimirPDF(string inputFile, string outputFile)
        {
            using PdfDocument pdfDoc = new(new PdfReader(inputFile), new PdfWriter(outputFile));
            // Configuração do nível de compressão
            pdfDoc.GetWriter().SetCompressionLevel(CompressionConstants.BEST_COMPRESSION);
        }
        public static void GerarPDF()
        {
            string outputPath = "repetitive_text_file_10mb.pdf";
            double targetFileSizeMB = 10;

            // Create a new PDF document
            using (var writer = new PdfWriter(outputPath))
            using (var pdf = new PdfDocument(writer))
            {
                var document = new Document(pdf);

                // Add text until the PDF reaches the target size
                double currentFileSizeMB = 0;
                while (currentFileSizeMB < targetFileSizeMB)
                {
                    //string randomPhrase = GenerateRandomWord(new Random().Next(3, 12)) + " "
                    //                     + GenerateRandomWord(new Random().Next(3, 12)) + " "
                    //                     + GenerateRandomWord(new Random().Next(3, 12)) + " "
                    //                     + GenerateRandomWord(new Random().Next(3, 12)) + " "
                    //                     + GenerateRandomWord(new Random().Next(3, 12)) + " "
                    //                     + GenerateRandomWord(new Random().Next(3, 12)) + " "
                    //                     + GenerateRandomWord(new Random().Next(3, 12)) + " "
                    //                     + GenerateRandomWord(new Random().Next(3, 12)) + " "
                    //                     + GenerateRandomWord(new Random().Next(3, 12)) + " "
                    //                     + GenerateRandomWord(new Random().Next(3, 12)) + " "
                    //                     + GenerateRandomWord(new Random().Next(3, 12)) + " ";
                    string randomPhrase = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum. ";

                    document.Add(new Paragraph(randomPhrase));
                    currentFileSizeMB = GetFileSizeMB(outputPath);
                }
            }

            Console.WriteLine("PDF file created successfully.");
        }
        static double GetFileSizeMB(string filePath)
        {
            FileInfo fileInfo = new(filePath);
            return fileInfo.Length / (1024f * 1024f);
        }
        static string GenerateRandomWord(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            StringBuilder stringBuilder = new();
            Random random = new();

            // Adicionar caracteres aleatórios até atingir o comprimento desejado
            for (int i = 0; i < length; i++)
            {
                int index = random.Next(chars.Length);
                stringBuilder.Append(chars[index]);
            }

            return stringBuilder.ToString();
        }
    }
}