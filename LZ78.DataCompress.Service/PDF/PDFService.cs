using iText.Kernel.Pdf;
using iText.Kernel.Utils;
using iText.Kernel.Pdf.Canvas.Parser;

namespace LZ78.DataCompress.Service.PDF
{
    public class PDFService
    {
        public static string LerPDF(string inputFile)
        {
            using PdfReader reader = new(inputFile);
            using PdfDocument pdfDoc = new(reader);

            string texto = "";
            for (int pageNum = 1; pageNum <= pdfDoc.GetNumberOfPages(); pageNum++)
            {
                texto += PdfTextExtractor.GetTextFromPage(pdfDoc.GetPage(pageNum));
            }
            return texto;
        }
        public static void ComprimirPDF(string inputFile, string outputFile)
        {
            using PdfDocument pdfDoc = new(new PdfReader(inputFile), new PdfWriter(outputFile));
            // Configuração do nível de compressão
            pdfDoc.GetWriter().SetCompressionLevel(CompressionConstants.BEST_COMPRESSION);
        }
    }
}