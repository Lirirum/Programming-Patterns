using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator
{
    public abstract class Iterator: IEnumerator<string>
    {
        public abstract string Current { get; }

        object IEnumerator.Current => Current;

        public abstract void Dispose();
        public abstract bool MoveNext();
        public abstract void Reset();
    }

    public class FileIterator : Iterator
    {
        private FileCollection _collection;
        private readonly Stack<IEnumerator<string>> _stack = new();
        private string _current;

        public FileIterator(FileCollection collection )
        {
            this._collection = collection;
            _stack.Push(GetFilesAndDirectories(collection.getRootPath()).GetEnumerator());
        }

        public override string Current => _current;

        public override void Dispose()
        {
            _stack.Clear();
        }

        public override bool MoveNext()
        {
            while (_stack.Count > 0)
            {
                var enumerator = _stack.Peek();
                if (enumerator.MoveNext())
                {
                    string path = enumerator.Current;
                    if (Directory.Exists(path))
                    {
                        _stack.Push(GetFilesAndDirectories(path).GetEnumerator());
                    }
                    else
                    {
                        _current = path;
                        return true;
                    }
                }
                else
                {
                    _stack.Pop();
                }
            }
            return false;
        }

        public override void Reset()
        {
            throw new NotSupportedException("Reset is not supported.");
        }


        private IEnumerable<string> GetFilesAndDirectories(string path)        {
          
            foreach (var dir in Directory.GetDirectories(path))
            {
                yield return dir;
            }
            foreach (var file in Directory.GetFiles(path))
            {
                yield return file;
            }
        }
    }
}
