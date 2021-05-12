using System.Collections.Generic;
using NBitcoin.Sugarchain.Extensions.SugarchainApiClient;
using SugarchainApiClient.Entities.Results;

namespace NBitcoin.Sugarchain.Extensions.NBitcoin
{
    public static class TransactionBuilderExtension
    {
        public static TransactionBuilder AddUnspent(this TransactionBuilder builder, UnspentResult unspent) =>
            builder.AddCoin(unspent.ToCoin());
        
        public static TransactionBuilder AddUnspent(this TransactionBuilder builder, IEnumerable<UnspentResult> unspent)
        {
            foreach (UnspentResult item in unspent)
                builder.AddUnspent(item);
            return builder;
        }
    }
}