using BenchmarkDotNet.Attributes;
using isk.GeneralAPI.Services;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace isk.GeneralAPI.Benchmarks
{
    [MemoryDiagnoser]
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class DateParseServiceBenchmarks
    {
        private const string DateTime = "2022-12-26T17:00:00Z";
        private static readonly DateParseService parser = new DateParseService();
        
        [Benchmark(Baseline = true)]
        public void GetYearFromDatetime()
        {
            parser.GetYearFromDateTime(DateTime);
        }

        [Benchmark]
        public void GetYearFromSplit()
        {
            parser.GetYearFromSplit(DateTime);
        }
    }
}
