namespace Garbage_Collector_test
{
    public class CustomWriter : IDisposable
    {
        private string _path;
        private StreamWriter _sw;
        private bool _disposed = false;

        public CustomWriter(string path)
        {
            _path = path;
            _sw = new StreamWriter(path, true);
        }

        public void WriteLine(string line, int number)
        {
            _sw.WriteLine($"{number}. {line}");
            _sw.Flush();
        }

        private void Dispose(bool disposing)
        {
            if(_disposed) return;

            if (disposing)
            {
                //managed
                GC.SuppressFinalize(this);
            }
            //unmanaged
            _sw.Dispose();
            _path = null;
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);


            //if (!_disposed)
            //{

            //}
        }

        ~CustomWriter()
        {
            Dispose(false);
        }
    }
}
