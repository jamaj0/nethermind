﻿using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Nethermind.Evm.Precompiles;

namespace Nethermind.Precompiles.Benchmark
{
    [HtmlExporter]
    [MemoryDiagnoser]
    [ShortRunJob(RuntimeMoniker.NetCoreApp31)]
    // [DryJob(RuntimeMoniker.NetCoreApp31)]
    public class Bn256AddBenchmark : PrecompileBenchmarkBase
    {
        protected override IPrecompile Precompile => Bn256AddPrecompile.Instance;
        protected override string InputsDirectory => "bnadd";
    }
}