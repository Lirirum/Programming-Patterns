using iText.Kernel.Pdf;
using iText.Layout.Element;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using ClosedXML.Excel;

namespace Decorator
{
    public class BasicReportDecorator : IReportGenerator
    {
        protected IReportGenerator _reportGenerator;
        public BasicReportDecorator(IReportGenerator reportGenerator)
        {
            _reportGenerator = reportGenerator;
        }

        public virtual void GenerateReport(string filePath, string data)
        {
            _reportGenerator.GenerateReport(filePath, data);
        }
    }
    
    public  class PDFReportDecorator : BasicReportDecorator
    {
        private readonly string fileExtension = ".pdf";
        public PDFReportDecorator(IReportGenerator reportGenerator) : base(reportGenerator)
        {
        }

        public override void GenerateReport(string filePath, string data)
        {
            base.GenerateReport(filePath, data);
            string path = $"{filePath}{fileExtension}";
            using (PdfWriter writer = new PdfWriter(path))
            {
                using (PdfDocument pdf = new PdfDocument(writer))
                {
                    Document document = new Document(pdf);
                    document.Add(new Paragraph($"Report created. Creation Date: {DateTime.Now}. Data: {data}"));
                    document.Close();
                }
            }
            Console.WriteLine($"[Файл {filePath} створений]. Версiя: PDF репорт");

        }
    }

    public class ExcelReportDecorator : BasicReportDecorator
    {
        private readonly string fileExtension = ".xlsx";
        public ExcelReportDecorator(IReportGenerator reportGenerator) : base(reportGenerator)
        {
        }

        public override void GenerateReport(string filePath, string data)
        {
            base.GenerateReport(filePath, data);
            string path = $"{filePath}{fileExtension}";
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Звіт");
                worksheet.Cell(1, 1).Value = $"Звіт створений. Дата Створення: {DateTime.Now}. Data: {data}";
                workbook.SaveAs(path);
                Console.WriteLine($"[Файл {path} створений]. Версiя: Excel репорт");
            }
        }
    }

}
