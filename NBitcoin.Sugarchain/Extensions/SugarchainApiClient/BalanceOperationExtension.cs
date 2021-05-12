using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using NBitcoin.Sugarchain.Interfaces;
using SugarchainApiClient.Entities;
using SugarchainApiClient.Entities.Results;
using SugarchainApiClient.Operations;

namespace NBitcoin.Sugarchain.Extensions.SugarchainApiClient
{
    public static class BalanceOperationExtension
    {
        public static Response<BalanceResult> Balance(
            this BalanceOperation operation,
            [NotNull] ISegwitDestination destination
        ) => operation.Get(destination.GetSegwitAddress().ToString());
        
        public static async Task<Response<BalanceResult>> BalanceAsync(
            this BalanceOperation operation,
            [NotNull] ISegwitDestination destination
        ) => await operation.GetAsync(destination.GetSegwitAddress().ToString());
    }
}