using SugarchainApiClient.Entities.Results;

namespace NBitcoin.Sugarchain.Extensions.SugarchainApiClient
{
    public static class UnspentResultExtension
    {
        public static uint256 GetTxId(this UnspentResult result) => uint256.Parse(result.TxId);

        public static Money GetMoneyValue(this UnspentResult result) => new Money((long) result.Value);

        public static Script GetScript(this UnspentResult result) => Script.FromHex(result.Script);

        public static ICoin ToCoin(this UnspentResult result) => new Coin(
            result.GetTxId(),
            (uint)result.Index,
            result.GetMoneyValue(),
            result.GetScript()
        );
    }
}