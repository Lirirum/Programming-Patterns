using System.Collections;

namespace Iterator
{
    public class FileCollection : IEnumerable<string>
    {
        readonly string _rootPath;

        public FileCollection(string rootDirectory)
        {
            if (!Directory.Exists(rootDirectory))
                throw new DirectoryNotFoundException($"Directory not found: {rootDirectory}");
            _rootPath = rootDirectory;
        }


        public IEnumerator<string> GetEnumerator()
        {
            return new FileIterator(this);
        }

       IEnumerator IEnumerable.GetEnumerator() =>
            GetEnumerator();

        public string getRootPath()
        {
            return _rootPath;
        }

    }
}
