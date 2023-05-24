using BenchmarkDotNet.Running;

namespace isk.GeneralAPI.Benchmarks
{
    public class BenchmarkExecute
    {
        // Runs a list of benchmarks
        public static int ExecuteMyBenchmarks()
        {
            BenchmarkRunner.Run<DateParseServiceBenchmarks>();

            return 0;
        }
    }
}
