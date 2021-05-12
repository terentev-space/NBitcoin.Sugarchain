namespace NBitcoin.Sugarchain.Interfaces
{
    public interface ISegwitDestination
    {
        BitcoinWitPubKeyAddress GetSegwitAddress();
    }
}