namespace DSD603VM2025.Services
{
    public class TextFileOperations: ITextFileOperations
    {
        private IWebHostEnvironment _webHostEnvironment { get; set; }

        public TextFileOperations(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public IEnumerable<string> LoadConditionsOfAcceptance()
        {
            string rootPath = _webHostEnvironment.WebRootPath;
            FileInfo filePath = new FileInfo(Path.Combine(rootPath, "ConditionsForAcceptance.txt"));

            string[] lines = File.ReadAllLines(filePath.ToString());

            return lines.ToList();
        }
    }
}
