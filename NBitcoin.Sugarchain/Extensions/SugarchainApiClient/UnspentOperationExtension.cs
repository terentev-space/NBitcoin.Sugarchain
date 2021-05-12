using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Threading.Tasks;
using NBitcoin.Sugarchain.Interfaces;
using SugarchainApiClient.Entities;
using SugarchainApiClient.Entities.Results;
using SugarchainApiClient.Operations;

namespace NBitcoin.Sugarchain.Extensions.SugarchainApiClient
{
    public static class UnspentOperationExtension
    {
        public static Response<IReadOnlyList<UnspentResult>> Unspent(
            this UnspentOperation operation,
            [NotNull] ISegwitDestination destination,
            [AllowNull] BigInteger? amount = null
        ) => operation.Get(destination.GetSegwitAddress().ToString(), amount);
        
        public static async Task<Response<IReadOnlyList<UnspentResult>>> UnspentAsync(
            this UnspentOperation operation,
            [NotNull] ISegwitDestination destination,
            [AllowNull] BigInteger? amount = null
        ) => await operation.GetAsync(destination.GetSegwitAddress().ToString(), amount);
    }
}