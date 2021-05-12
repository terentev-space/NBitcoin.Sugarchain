using System;
using NBitcoin.DataEncoders;
using NBitcoin.Protocol;

namespace NBitcoin.Sugarchain
{
    public class Sugarchain : NetworkSetBase
    {
        private Sugarchain() => this.EnsureRegistered();

        public static Sugarchain Instance { get; } = new Sugarchain();

        public override string CryptoCode => "SUGAR";

        #region Main

        protected override NetworkBuilder CreateMainnet() => new NetworkBuilder()
            .SetConsensus(new Consensus()
                {
                    SubsidyHalvingInterval = 12500000,
                    MajorityEnforceBlockUpgrade = Bitcoin.Instance.Mainnet.Consensus.MajorityEnforceBlockUpgrade,
                    MajorityRejectBlockOutdated = Bitcoin.Instance.Mainnet.Consensus.MajorityRejectBlockOutdated,
                    MajorityWindow = Bitcoin.Instance.Mainnet.Consensus.MajorityWindow,
                    BIP34Hash = new uint256("72e36f3fcdf98d3625dfe03f28a914c513b913231e479d53fc22e5e46cf5b585"),
                    PowLimit = new Target(new uint256("003fffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff")),
                    PowTargetTimespan = TimeSpan.FromSeconds(61200),
                    PowTargetSpacing = TimeSpan.FromSeconds(510),
                    PowAllowMinDifficultyBlocks = false,
                    PowNoRetargeting = false,
                    RuleChangeActivationThreshold = 9180,
                    MinerConfirmationWindow = 12240,
                    CoinbaseMaturity = Bitcoin.Instance.Mainnet.Consensus.CoinbaseMaturity,
                    LitecoinWorkCalculation = false,
                    SupportSegwit = true,
                }
            )
            .SetBase58Bytes(Base58Type.PUBKEY_ADDRESS, new byte[] {0x3F})
            .SetBase58Bytes(Base58Type.SCRIPT_ADDRESS, new byte[] {0x7D})
            .SetBase58Bytes(Base58Type.SECRET_KEY, new byte[] {0x80})
            .SetBase58Bytes(Base58Type.EXT_PUBLIC_KEY, new byte[] {0x04, 0x88, 0xB2, 0x1E})
            .SetBase58Bytes(Base58Type.EXT_SECRET_KEY, new byte[] {0x04, 0x88, 0xAD, 0xE4})
            .SetBech32(Bech32Type.WITNESS_PUBKEY_ADDRESS, Encoders.Bech32("sugar"))
            .SetBech32(Bech32Type.WITNESS_SCRIPT_ADDRESS, Encoders.Bech32("sugar"))
            .SetPort(34230)
            .SetRPCPort(34229)
            .SetName("sugarchain-main")
            .AddAlias("sugarchain-mainnet")
            .AddDNSSeeds(new[]
            {
                new DNSSeedData("1seed.sugarchain.info", "1seed.sugarchain.info"),
                new DNSSeedData("2seed.sugarchain.info", "2seed.sugarchain.info"),
                new DNSSeedData("seed.sugarchain.site", "seed.sugarchain.site"),
                new DNSSeedData("seed.sugar.hel.lu", "seed.sugar.hel.lu"),
            })
            .SetGenesis("7d5eaec2dbb75f99feadfa524c78b7cabc1d8c8204f79d4f3a83381b811b0adc")
            .AddSeeds(new NetworkAddress[0]);

        #endregion

        #region Test
        
        [ObsoleteAttribute("This method has not been tested", false)]
        protected override NetworkBuilder CreateTestnet() => new NetworkBuilder()
            .SetConsensus(new Consensus()
                {
                    SubsidyHalvingInterval = 12500000,
                    MajorityEnforceBlockUpgrade = Bitcoin.Instance.Mainnet.Consensus.MajorityEnforceBlockUpgrade,
                    MajorityRejectBlockOutdated = Bitcoin.Instance.Mainnet.Consensus.MajorityRejectBlockOutdated,
                    MajorityWindow = Bitcoin.Instance.Mainnet.Consensus.MajorityWindow,
                    BIP34Hash = new uint256("72e36f3fcdf98d3625dfe03f28a914c513b913231e479d53fc22e5e46cf5b585"),
                    PowLimit = new Target(new uint256("003fffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff")),
                    PowTargetTimespan = TimeSpan.FromSeconds(61200),
                    PowTargetSpacing = TimeSpan.FromSeconds(510),
                    PowAllowMinDifficultyBlocks = false,
                    PowNoRetargeting = false,
                    RuleChangeActivationThreshold = 9180,
                    MinerConfirmationWindow = 12240,
                    CoinbaseMaturity = Bitcoin.Instance.Mainnet.Consensus.CoinbaseMaturity,
                    LitecoinWorkCalculation = false,
                    SupportSegwit = true,
                }
            )
            .SetBase58Bytes(Base58Type.PUBKEY_ADDRESS, new byte[] {0x42})
            .SetBase58Bytes(Base58Type.SCRIPT_ADDRESS, new byte[] {0x80})
            .SetBase58Bytes(Base58Type.SECRET_KEY, new byte[] {0xEF})
            .SetBase58Bytes(Base58Type.EXT_PUBLIC_KEY, new byte[] {0x04, 0x88, 0xB2, 0x1E})
            .SetBase58Bytes(Base58Type.EXT_SECRET_KEY, new byte[] {0x04, 0x88, 0xAD, 0xE4})
            .SetBech32(Bech32Type.WITNESS_PUBKEY_ADDRESS, Encoders.Bech32("tugar"))
            .SetBech32(Bech32Type.WITNESS_SCRIPT_ADDRESS, Encoders.Bech32("tugar"))
            .SetPort(44230)
            //.SetRPCPort(34229)
            .SetName("sugarchain-test")
            .AddAlias("sugarchain-testnet")
            .AddDNSSeeds(new[]
            {
                new DNSSeedData("1seed-testnet.cryptozeny.com", "1seed-testnet.cryptozeny.com"),
            })
            .SetGenesis("0032f49a73e00fc182e08d5ede75c1418c7833092d663e43a5463c1dbd096f28")
            .AddSeeds(new NetworkAddress[0]);
        
        #endregion

        #region Regtest
        
        [ObsoleteAttribute("This method has not been tested", false)]
        protected override NetworkBuilder CreateRegtest() => new NetworkBuilder()
            .SetConsensus(new Consensus()
                {
                    SubsidyHalvingInterval = 12500000,
                    MajorityEnforceBlockUpgrade = Bitcoin.Instance.Mainnet.Consensus.MajorityEnforceBlockUpgrade,
                    MajorityRejectBlockOutdated = Bitcoin.Instance.Mainnet.Consensus.MajorityRejectBlockOutdated,
                    MajorityWindow = Bitcoin.Instance.Mainnet.Consensus.MajorityWindow,
                    BIP34Hash = new uint256("72e36f3fcdf98d3625dfe03f28a914c513b913231e479d53fc22e5e46cf5b585"),
                    PowLimit = new Target(new uint256("003fffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff")),
                    PowTargetTimespan = TimeSpan.FromSeconds(61200),
                    PowTargetSpacing = TimeSpan.FromSeconds(510),
                    PowAllowMinDifficultyBlocks = false,
                    PowNoRetargeting = false,
                    RuleChangeActivationThreshold = 9180,
                    MinerConfirmationWindow = 12240,
                    CoinbaseMaturity = Bitcoin.Instance.Mainnet.Consensus.CoinbaseMaturity,
                    LitecoinWorkCalculation = false,
                    SupportSegwit = true,
                }
            )
            .SetBase58Bytes(Base58Type.PUBKEY_ADDRESS, new byte[] {61})
            .SetBase58Bytes(Base58Type.SCRIPT_ADDRESS, new byte[] {123})
            .SetBase58Bytes(Base58Type.SECRET_KEY, new byte[] {239})
            .SetBase58Bytes(Base58Type.EXT_PUBLIC_KEY, new byte[] {0x04, 0x35, 0x87, 0xCF})
            .SetBase58Bytes(Base58Type.EXT_SECRET_KEY, new byte[] {0x04, 0x35, 0x83, 0x94})
            .SetBech32(Bech32Type.WITNESS_PUBKEY_ADDRESS, Encoders.Bech32("rugar"))
            .SetBech32(Bech32Type.WITNESS_SCRIPT_ADDRESS, Encoders.Bech32("rugar"))
            .SetPort(45340)
            //.SetRPCPort(34229)
            .SetName("sugarchain-regtest")
            .AddAlias("sugarchain-regtestnet")
            // .AddDNSSeeds(new[]
            // {
            //     new DNSSeedData("", ""),
            // })
            .SetGenesis("d567a9c891c7a47e6dd03f8006cb65b0d6406b5dc7b2c86d7a904815c394e1f1")
            .AddSeeds(new NetworkAddress[0]);
        
        #endregion
    }
}