using NBitcoin.Sugarchain.Interfaces;

namespace NBitcoin.Sugarchain
{
    public class SugarKey : BitcoinWitPubKeyAddress, IDestination, ISegwitDestination, ISimplePublicDirection
    {
        public SugarKey(string bech32, Network expectedNetwork) : base(bech32, expectedNetwork)
        {
        }

        public BitcoinWitPubKeyAddress GetSegwitAddress() => this;
        
        public string GetPublicSugarAddress() => this.GetSegwitAddress().ToString();

        public string GetPublicLegacyAddress() => this.ScriptPubKey.ToString();
    }
}