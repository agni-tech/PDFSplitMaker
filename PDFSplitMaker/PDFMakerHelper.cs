using PdfSharpCore.Pdf;
using PdfSharpCore.Pdf.IO;

namespace PDFSplitMaker
{
    public static class PDFMakerHelper
    {
        public static void PdfMaker(string origin, string destiny, int[] pages)
        {
            if (!File.Exists(origin))
                throw new Exception("File not found!");

            var doc = PdfReader.Open(origin, PdfDocumentOpenMode.Import);
            var newDoc = new PdfDocument();
            int currentPage = 1;

            foreach (var page in doc.Pages)
            {
                if (pages.Any(pg => pg == currentPage))
                    newDoc.AddPage(page);

                currentPage++;
            }

            if (newDoc.Pages.Count == 0)
                throw new Exception("No pages!");

            newDoc.Save(destiny);

        }
    }
}