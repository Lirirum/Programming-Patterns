namespace Decorator
{
    public interface IReportGenerator
    {
        void GenerateReport(string filePath, string data);
    }

    public class ReportGenerator : IReportGenerator
    {
        private readonly string fileExtension= ".txt";
        public void GenerateReport(string filePath ,string data)
        {
            string path = $"{filePath}{fileExtension}";
            File.WriteAllText(path, $"Звіт створений. Дата Створення: {DateTime.Now}. Data: {data}") ;
            Console.WriteLine($"[Файл {filePath} створений]. Версiя: Базовий репорт");
        }
    }
}
