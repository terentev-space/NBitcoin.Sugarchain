using System.Collections.Generic;
using NBitcoin.Sugarchain.Extensions.NBitcoin;
using NBitcoin.Sugarchain.Interfaces;
using SugarchainApiClient.Entities.Results;

namespace NBitcoin.Sugarchain.Factories
{
    public class TransactionFactory
    {
        private readonly Network network;

        public TransactionFactory(Network network)
        {
            this.network = network;
        }

        public static TransactionFactory Instance(Network network) => new TransactionFactory(network);

        public Transaction Create(
            ISecretDestination from,
            IDestination to,
            Money amount,
            Money fees,
            IEnumerable<UnspentResult> unspent,
            bool sign = true
        ) => this.network.CreateTransactionBuilder()
            .AddUnspent(unspent)
            .AddKeys(from.PrivateKey)
            .SetChange(from.ScriptPubKey)
            .Send(to.ScriptPubKey, amount)
            .SendFees(fees)
            .BuildTransaction(sign);
        
        public Transaction Create(
            ISecretDestination from,
            IDestination to,
            decimal amount,
            decimal fees,
            IEnumerable<UnspentResult> unspent,
            bool sign = true
        ) => this.network.CreateTransactionBuilder()
            .AddUnspent(unspent)
            .AddKeys(from.PrivateKey)
            .SetChange(from.ScriptPubKey)
            .Send(to.ScriptPubKey, SugarMoney.Coins(amount))
            .SendFees(SugarMoney.Coins(fees))
            .BuildTransaction(sign);
        
        public Transaction Create(
            ISecretDestination from,
            IDestination to,
            Money amount,
            Money fees,
            IEnumerable<ICoin> coins,
            bool sign = true
        ) => this.network.CreateTransactionBuilder()
            .AddCoins(coins)
            .AddKeys(from.PrivateKey)
            .SetChange(from.ScriptPubKey)
            .Send(to.ScriptPubKey, amount)
            .SendFees(fees)
            .BuildTransaction(sign);
        
        public Transaction Create(
            ISecretDestination from,
            IDestination to,
            decimal amount,
            decimal fees,
            IEnumerable<ICoin> coins,
            bool sign = true
        ) => this.network.CreateTransactionBuilder()
            .AddCoins(coins)
            .AddKeys(from.PrivateKey)
            .SetChange(from.ScriptPubKey)
            .Send(to.ScriptPubKey, SugarMoney.Coins(amount))
            .SendFees(SugarMoney.Coins(fees))
            .BuildTransaction(sign);
        
        public Transaction Create(
            ISecretDestination from,
            IDestination to,
            Money amount,
            Money fees,
            ICoin coin,
            bool sign = true
        ) => this.network.CreateTransactionBuilder()
            .AddCoin(coin)
            .AddKeys(from.PrivateKey)
            .SetChange(from.ScriptPubKey)
            .Send(to.ScriptPubKey, amount)
            .SendFees(fees)
            .BuildTransaction(sign);
        
        public Transaction Create(
            ISecretDestination from,
            IDestination to,
            decimal amount,
            decimal fees,
            ICoin coin,
            bool sign = true
        ) => this.network.CreateTransactionBuilder()
            .AddCoin(coin)
            .AddKeys(from.PrivateKey)
            .SetChange(from.ScriptPubKey)
            .Send(to.ScriptPubKey, SugarMoney.Coins(amount))
            .SendFees(SugarMoney.Coins(fees))
            .BuildTransaction(sign);
        
    }
}