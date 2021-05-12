namespace NBitcoin.Sugarchain.Factories
{
    public class SugarFactory
    {
        private readonly Network network;

        public SugarFactory(Network network)
        {
            this.network = network;
        }
        
        public static SugarFactory Instance(Network network) => new SugarFactory(network);
        
        public SugarSecret CreateSecret() => new SugarSecret(new Key(), this.network);
        
        public SugarSecret ParseSecret(string privateKeyBase58) => new SugarSecret(privateKeyBase58, this.network);
        
        public SugarKey ParsePublic(string publicAddressBech32) => new SugarKey(publicAddressBech32, this.network);
    }
}