using Serilog;

namespace Logger
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File(@"Logs\logs-.txt",rollingInterval: RollingInterval.Minute)
                .MinimumLevel.Information()
                .CreateLogger();

            for (var i = 0; i < 10; i++)
            {
                var student = new Student("Sasho", "Popovski");
                Thread.Sleep(1000);
            }
        }
    }
}
