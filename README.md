# NBitcoin.Sugarchain

[![Latest Version](https://img.shields.io/github/v/tag/terentev-space/NBitcoin.Sugarchain)](https://github.com/terentev-space/NBitcoin.Sugarchain/releases)
[![Software License](https://img.shields.io/badge/license-Apache_2.0-brightgreen.svg)](LICENSE)
[![NuGet](https://img.shields.io/nuget/v/NBitcoin.Sugarchain.svg)](https://www.nuget.org/packages/NBitcoin.Sugarchain) 
[![downloads](https://img.shields.io/nuget/dt/NBitcoin.Sugarchain)](https://www.nuget.org/packages/NBitcoin.Sugarchain) 
[![Size](https://img.shields.io/github/repo-size/terentev-space/NBitcoin.Sugarchain.svg)]()
#### 🚧 Attention: the project is currently under development! 🚧

⚠️**Disclaimer:** _I am not an expert in cryptocurrencies, there may be errors in logic and use, but I did not find any ready-made solutions for Sugarchain and decided to write my own. What i wanted to say: use carefully, do not trust me!_

<br/>Sugarchain project website: https://sugarchain.org/
<br/>Sugarchain API: https://api.sugarchain.org/

<br/>NBitcoin repository (Github): https://github.com/MetacoSA/NBitcoin
<br/>SugarchainApiClient repository (Github): https://github.com/terentev-space/SugarchainApiClient

## Install

#### PM
```
Install-Package NBitcoin.Sugarchain
```

#### .NET CLI
```
dotnet add package NBitcoin.Sugarchain
```

#### NuGet
```
NBitcoin.Sugarchain
```

## Examples

#### 🔶 Public & Private Keys / Addresses & Wallets
Init
```c#
Network network = Sugarchain.Instance.Mainnet;
SugarFactory factory = SugarFactory.Instance(network);
```
Create new "wallet"
```c#
SugarSecret newSugar = factory.CreateSecret();

// Output (Keys are real but empty):
Console.WriteLine(newSugar.GetPublicSugarAddress());  // sugar1qkhcx7tf5jc7xdnas70tvasxxvh3aec2586llq2
Console.WriteLine(newSugar.GetPublicLegacyAddress()); // OP_DUP OP_HASH160 b5f06f2d34963c66cfb0f3d6cec0c665e3dce154 OP_EQUALVERIFY OP_CHECKSIG
Console.WriteLine(newSugar.GetPrivateKey());          // KzTdaJrKvT9DKHxvHVhBPX7rM6BJvBMVne2w1rEigorySynB2wFs
```
Import "wallet"
```c#
string privateKey;// WIF
privateKey = "KzTdaJrKvT9DKHxvHVhBPX7rM6BJvBMVne2w1rEigorySynB2wFs";
/* OR */
privateKey = newSugar.GetPrivateKey();

// newSugar ≈ parsedSugar
SugarSecret parsedSugar = factory.ParseSecret(privateKey);

// Output (Keys are real but empty):
Console.WriteLine(parsedSugar.GetPublicSugarAddress());  // sugar1qkhcx7tf5jc7xdnas70tvasxxvh3aec2586llq2
Console.WriteLine(parsedSugar.GetPublicLegacyAddress()); // OP_DUP OP_HASH160 b5f06f2d34963c66cfb0f3d6cec0c665e3dce154 OP_EQUALVERIFY OP_CHECKSIG
Console.WriteLine(parsedSugar.GetPrivateKey());          // KzTdaJrKvT9DKHxvHVhBPX7rM6BJvBMVne2w1rEigorySynB2wFs
```
Import "wallet" public address
```c#
string address;
address = "sugar1qkhcx7tf5jc7xdnas70tvasxxvh3aec2586llq2";
/* OR */
address = newSugar.GetPublicSugarAddress();
/* OR */
address = parsedSugar.GetPublicSugarAddress();

SugarKey parsedAddress = factory.ParsePublic(address);

// Output (Keys are real but empty):
Console.WriteLine(parsedAddress.GetPublicSugarAddress());  // sugar1qkhcx7tf5jc7xdnas70tvasxxvh3aec2586llq2
Console.WriteLine(parsedAddress.GetPublicLegacyAddress()); // 0 b5f06f2d34963c66cfb0f3d6cec0c665e3dce154
```
#### 🔶 Transaction
```c#
Network network = Sugarchain.Instance.Mainnet;
SugarFactory factory = SugarFactory.Instance(network);

SugarSecret from = factory.ParseSecret("KzTdaJrKvT9DKHxvHVhBPX7rM6BJvBMVne2w1rEigorySynB2wFs");
SugarKey to = factory.ParsePublic("sugar1qmqvkrn5zw2v60tl0syfmxwrkre4kagpak0t9s5");

Response<IReadOnlyList<UnspentResult>> unspentResponse = client.Api.Unspent(from);

decemal amount = 0.1m;
decemal fee = 0.00001001m;

Transaction transaction = TransactionFactory.Instance(network).Create(
                                from: from,
                                to: to,
                                amount: amount,
                                fee: fee,
                                unspent: unspentResponse.Result,
                                sign: true
                            );
                            
string raw = transaction.ToHex();

Response<string> response;
response = client.Api.Broadcast(transaction);// OR await client.Api.BroadcastAsync(transaction)
/* OR */
response = client.Api.Broadcast(raw);// OR await client.Api.BroadcastAsync(raw)
```

## Credits

- [Ivan Terentev](https://github.com/terentev-space)
- [All Contributors](https://github.com/terentev-space/SugarchainApiClient/contributors)

## License

The Apache 2.0 License (Apache-2.0). Please see [License File](LICENSE) for more information.
