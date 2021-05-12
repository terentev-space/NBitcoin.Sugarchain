using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using SugarchainApiClient.Entities;
using SugarchainApiClient.Operations;

namespace NBitcoin.Sugarchain.Extensions.SugarchainApiClient
{
    public static class BroadcastOperationExtension
    {
        public static Response<string> Broadcast(
            this BroadcastOperation operation,
            [NotNull] Transaction transaction
        ) => operation.Send(transaction.ToHex());
        
        public static async Task<Response<string>> BroadcastAsync(
            this BroadcastOperation operation,
            [NotNull] Transaction transaction
        ) => await operation.SendAsync(transaction.ToHex());
    }
}