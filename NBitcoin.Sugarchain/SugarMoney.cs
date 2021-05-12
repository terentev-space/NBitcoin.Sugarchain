namespace NBitcoin.Sugarchain
{
    public static class SugarMoney
    {
        public static Money Coins(decimal amount) => Money.Coins(amount);
        
        public static Money FromUnit(decimal amount, SugarMoneyUnit unit) => Money.FromUnit(amount, (MoneyUnit)unit);
    }
}