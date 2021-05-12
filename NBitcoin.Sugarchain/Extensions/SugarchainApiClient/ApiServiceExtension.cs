using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Threading.Tasks;
using NBitcoin.Sugarchain.Interfaces;
using SugarchainApiClient.Entities;
using SugarchainApiClient.Entities.Results;
using SugarchainApiClient.Services;

namespace NBitcoin.Sugarchain.Extensions.SugarchainApiClient
{
    public static class ApiServiceExtension
    {
        public static Response<BalanceResult> Balance(
            this ApiService service,
            [NotNull] ISegwitDestination destination
        ) => service.Balance(destination.GetSegwitAddress().ToString());
        
        public static async Task<Response<BalanceResult>> BalanceAsync(
            this ApiService service,
            [NotNull] ISegwitDestination destination
        ) => await service.BalanceAsync(destination.GetSegwitAddress().ToString());
        
        public static Response<IReadOnlyList<UnspentResult>> Unspent(
            this ApiService service,
            [NotNull] ISegwitDestination destination,
            [AllowNull] BigInteger? amount = null
        ) => service.Unspent(destination.GetSegwitAddress().ToString(), amount);
        
        public static async Task<Response<IReadOnlyList<UnspentResult>>> UnspentAsync(
            this ApiService service,
            [NotNull] ISegwitDestination destination,
            [AllowNull] BigInteger? amount = null
        ) => await service.UnspentAsync(destination.GetSegwitAddress().ToString(), amount);
        
        public static Response<string> Broadcast(
            this ApiService service,
            [NotNull] Transaction transaction
        ) => service.Broadcast(transaction.ToHex());
        
        public static async Task<Response<string>> BroadcastAsync(
            this ApiService service,
            [NotNull] Transaction transaction
        ) => await service.BroadcastAsync(transaction.ToHex());
    }
}