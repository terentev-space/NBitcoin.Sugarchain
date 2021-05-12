namespace NBitcoin.Sugarchain.Interfaces
{
    public interface ISimplePublicDirection
    {
        public string GetPublicSugarAddress();
        public string GetPublicLegacyAddress();
    }
}