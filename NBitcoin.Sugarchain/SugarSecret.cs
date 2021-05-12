using NBitcoin.Sugarchain.Interfaces;

namespace NBitcoin.Sugarchain
{
    public class SugarSecret : BitcoinSecret, ISugarSecret, ISimpleDirection
    {
        public SugarSecret(Key key) : base(key, Sugarchain.Instance.Mainnet)
        {
        }
        
        public SugarSecret(Key key, Network network) : base(key, network)
        {
        }

        public SugarSecret(string base58) : base(base58, Sugarchain.Instance.Mainnet)
        {
        }

        public SugarSecret(string base58, Network expectedNetwork) : base(base58, expectedNetwork)
        {
        }

        public string GetPublicSugarAddress() => this.GetAddress(ScriptPubKeyType.Segwit).ToString();
        public string GetPublicLegacyAddress() => this.GetAddress(ScriptPubKeyType.Legacy).ScriptPubKey.ToString();
        public string GetPrivateKey() => this.ToWif();
    }
}