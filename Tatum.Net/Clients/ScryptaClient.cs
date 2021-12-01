﻿using CryptoExchange.Net;
using CryptoExchange.Net.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Tatum.Net.Enums;
using Tatum.Net.RestObjects;

namespace Tatum.Net.Clients
{
    public class ScryptaClient
    {
        public TatumClient Tatum { get; protected set; }

        protected const string Endpoints_BlockchainInformation = "scrypta/info";
        protected const string Endpoints_GetBlockHash = "scrypta/block/hash/{0}";
        protected const string Endpoints_GetBlockByHash = "scrypta/block/{0}";
        protected const string Endpoints_GetTransactionByHash = "scrypta/transaction/{0}";
        protected const string Endpoints_GetTransactionsByAddress = "scrypta/transaction/address/{0}";
        protected const string Endpoints_GetSpendableUTXO = "scrypta/utxo/{0}";
        protected const string Endpoints_GetTransactionUTXO = "scrypta/utxo/{0}/{1}";
        protected const string Endpoints_Transaction = "scrypta/transaction";
        protected const string Endpoints_Broadcast = "scrypta/broadcast";

        public ScryptaClient(TatumClient tatumClient)
        {
            Tatum = tatumClient;
        }

        /// <summary>
        /// <b>Title:</b> Generate Scrypta wallet<br />
        /// <b>Credits:</b> 1 credit per API call.<br />
        /// <b>Description:</b>
        /// Tatum supports BIP44 HD wallets. It is very convenient and secure, since it can generate 2^31 addresses from 1 mnemonic phrase. Mnemonic phrase consists of 24 special words in defined order and can restore access to all generated addresses and private keys.
        /// Each address is identified by 3 main values:
        /// - Private Key - your secret value, which should never be revealed
        /// - Public Key - public address to be published
        /// - Derivation index - index of generated address
        /// Tatum follows BIP44 specification and generates for Scrypta wallet with derivation path m'/44'/0'/0'/0. More about BIP44 HD wallets can be found here - https://github.com/bitcoin/bips/blob/master/bip-0044.mediawiki. Generate BIP44 compatible Scrypta wallet.
        /// </summary>
        /// <param name="mnemonics">Mnemonic to generate private key from.</param>
        /// <param name="ct">Cancellation Token</param>
        /// <returns></returns>
        public virtual WebCallResult<BlockchainWallet> GenerateWallet(string mnemonics, CancellationToken ct = default) => Tatum.Blockchain_GenerateWalletAsync(BlockchainType.Scrypta, new List<string> { mnemonics }, ct).Result;
        /// <summary>
        /// <b>Title:</b> Generate Scrypta wallet<br />
        /// <b>Credits:</b> 1 credit per API call.<br />
        /// <b>Description:</b>
        /// Tatum supports BIP44 HD wallets. It is very convenient and secure, since it can generate 2^31 addresses from 1 mnemonic phrase. Mnemonic phrase consists of 24 special words in defined order and can restore access to all generated addresses and private keys.
        /// Each address is identified by 3 main values:
        /// - Private Key - your secret value, which should never be revealed
        /// - Public Key - public address to be published
        /// - Derivation index - index of generated address
        /// Tatum follows BIP44 specification and generates for Scrypta wallet with derivation path m'/44'/0'/0'/0. More about BIP44 HD wallets can be found here - https://github.com/bitcoin/bips/blob/master/bip-0044.mediawiki. Generate BIP44 compatible Scrypta wallet.
        /// </summary>
        /// <param name="mnemonics">Mnemonic to generate private key from.</param>
        /// <param name="ct">Cancellation Token</param>
        /// <returns></returns>
        public virtual WebCallResult<BlockchainWallet> GenerateWallet(IEnumerable<string> mnemonics = null, CancellationToken ct = default) => Tatum.Blockchain_GenerateWalletAsync(BlockchainType.Scrypta, mnemonics, ct).Result;
        /// <summary>
        /// <b>Title:</b> Generate Scrypta wallet<br />
        /// <b>Credits:</b> 1 credit per API call.<br />
        /// <b>Description:</b>
        /// Tatum supports BIP44 HD wallets. It is very convenient and secure, since it can generate 2^31 addresses from 1 mnemonic phrase. Mnemonic phrase consists of 24 special words in defined order and can restore access to all generated addresses and private keys.
        /// Each address is identified by 3 main values:
        /// - Private Key - your secret value, which should never be revealed
        /// - Public Key - public address to be published
        /// - Derivation index - index of generated address
        /// Tatum follows BIP44 specification and generates for Scrypta wallet with derivation path m'/44'/0'/0'/0. More about BIP44 HD wallets can be found here - https://github.com/bitcoin/bips/blob/master/bip-0044.mediawiki. Generate BIP44 compatible Scrypta wallet.
        /// </summary>
        /// <param name="mnemonics">Mnemonic to generate private key from.</param>
        /// <param name="ct">Cancellation Token</param>
        /// <returns></returns>
        public virtual async Task<WebCallResult<BlockchainWallet>> GenerateWalletAsync(string mnemonics, CancellationToken ct = default) => await Tatum.Blockchain_GenerateWalletAsync(BlockchainType.Scrypta, new List<string> { mnemonics }, ct);
        /// <summary>
        /// <b>Title:</b> Generate Scrypta wallet<br />
        /// <b>Credits:</b> 1 credit per API call.<br />
        /// <b>Description:</b>
        /// Tatum supports BIP44 HD wallets. It is very convenient and secure, since it can generate 2^31 addresses from 1 mnemonic phrase. Mnemonic phrase consists of 24 special words in defined order and can restore access to all generated addresses and private keys.
        /// Each address is identified by 3 main values:
        /// - Private Key - your secret value, which should never be revealed
        /// - Public Key - public address to be published
        /// - Derivation index - index of generated address
        /// Tatum follows BIP44 specification and generates for Scrypta wallet with derivation path m'/44'/0'/0'/0. More about BIP44 HD wallets can be found here - https://github.com/bitcoin/bips/blob/master/bip-0044.mediawiki. Generate BIP44 compatible Scrypta wallet.
        /// </summary>
        /// <param name="mnemonics">Mnemonic to generate private key from.</param>
        /// <param name="ct">Cancellation Token</param>
        /// <returns></returns>
        public virtual async Task<WebCallResult<BlockchainWallet>> GenerateWalletAsync(IEnumerable<string> mnemonics = null, CancellationToken ct = default) => await Tatum.Blockchain_GenerateWalletAsync(BlockchainType.Scrypta, mnemonics, ct);

        /// <summary>
        /// <b>Title:</b> Generate Scrypta private key<br />
        /// <b>Credits:</b> 1 credit per API call.<br />
        /// <b>Description:</b>
        /// Generate private key for address from mnemonic for given derivation path index. Private key is generated for the concrete index - each mnemonic can generate up to 2^32 private keys starting from index 0 until 2^31.
        /// </summary>
        /// <param name="mnemonics">Mnemonic to generate private key from.</param>
        /// <param name="index">Derivation index of private key to generate.</param>
        /// <param name="ct">Cancellation Token</param>
        /// <returns></returns>
        public virtual WebCallResult<TatumKey> GeneratePrivateKey(string mnemonics, int index, CancellationToken ct = default) => Tatum.Blockchain_GeneratePrivateKeyAsync(BlockchainType.Scrypta, new List<string> { mnemonics }, index, ct).Result;
        /// <summary>
        /// <b>Title:</b> Generate Scrypta private key<br />
        /// <b>Credits:</b> 1 credit per API call.<br />
        /// <b>Description:</b>
        /// Generate private key for address from mnemonic for given derivation path index. Private key is generated for the concrete index - each mnemonic can generate up to 2^32 private keys starting from index 0 until 2^31.
        /// </summary>
        /// <param name="mnemonics">Mnemonic to generate private key from.</param>
        /// <param name="index">Derivation index of private key to generate.</param>
        /// <param name="ct">Cancellation Token</param>
        /// <returns></returns>
        public virtual WebCallResult<TatumKey> GeneratePrivateKey(IEnumerable<string> mnemonics, int index, CancellationToken ct = default) => Tatum.Blockchain_GeneratePrivateKeyAsync(BlockchainType.Scrypta, mnemonics, index, ct).Result;
        /// <summary>
        /// <b>Title:</b> Generate Scrypta private key<br />
        /// <b>Credits:</b> 1 credit per API call.<br />
        /// <b>Description:</b>
        /// Generate private key for address from mnemonic for given derivation path index. Private key is generated for the concrete index - each mnemonic can generate up to 2^32 private keys starting from index 0 until 2^31.
        /// </summary>
        /// <param name="mnemonics">Mnemonic to generate private key from.</param>
        /// <param name="index">Derivation index of private key to generate.</param>
        /// <param name="ct">Cancellation Token</param>
        /// <returns></returns>
        public virtual async Task<WebCallResult<TatumKey>> GeneratePrivateKeyAsync(string mnemonics, int index, CancellationToken ct = default) => await Tatum.Blockchain_GeneratePrivateKeyAsync(BlockchainType.Scrypta, new List<string> { mnemonics }, index, default);
        /// <summary>
        /// <b>Title:</b> Generate Scrypta private key<br />
        /// <b>Credits:</b> 1 credit per API call.<br />
        /// <b>Description:</b>
        /// Generate private key for address from mnemonic for given derivation path index. Private key is generated for the concrete index - each mnemonic can generate up to 2^32 private keys starting from index 0 until 2^31.
        /// </summary>
        /// <param name="mnemonics">Mnemonic to generate private key from.</param>
        /// <param name="index">Derivation index of private key to generate.</param>
        /// <param name="ct">Cancellation Token</param>
        /// <returns></returns>
        public virtual async Task<WebCallResult<TatumKey>> GeneratePrivateKeyAsync(IEnumerable<string> mnemonics, int index, CancellationToken ct = default) => await Tatum.Blockchain_GeneratePrivateKeyAsync(BlockchainType.Scrypta, mnemonics, index, default);

        /// <summary>
        /// <b>Title:</b> Get Block hash<br />
        /// <b>Credits:</b> 1 credit per API call.<br />
        /// <b>Description:</b>
        /// Get Scrypta Block hash. Returns hash of the block to get the block detail.
        /// </summary>
        /// <param name="block_id">The number of blocks preceding a particular block on a block chain.</param>
        /// <param name="ct">Cancellation Token</param>
        /// <returns></returns>
        public virtual WebCallResult<string> GetBlockHash(long block_id, CancellationToken ct = default) => GetBlockHashAsync(block_id, ct).Result;
        public virtual async Task<WebCallResult<string>> GetBlockHashAsync(long block_id, CancellationToken ct = default)
        {
            var credits = 1;
            var url = Tatum.GetUrl(string.Format(Endpoints_GetBlockHash, block_id));
            return await Tatum.SendTatumRequest<string>(url, HttpMethod.Get, ct, checkResult: false, signed: true, credits: credits).ConfigureAwait(false);
        }

        /// <summary>
        /// <b>Title:</b> Get Block by hash or height<br />
        /// <b>Credits:</b> 1 credit per API call.<br />
        /// <b>Description:</b>
        /// Get Scrypta Block detail by block hash or height.
        /// </summary>
        /// <param name="hash_height">Block hash or height.</param>
        /// <param name="ct">Cancellation Token</param>
        /// <returns></returns>
        public virtual WebCallResult<ScryptaBlock> GetBlock(string hash_height, CancellationToken ct = default) => GetBlockAsync(hash_height, ct).Result;
        /// <summary>
        /// <b>Title:</b> Get Block by hash or height<br />
        /// <b>Credits:</b> 1 credit per API call.<br />
        /// <b>Description:</b>
        /// Get Scrypta Block detail by block hash or height.
        /// </summary>
        /// <param name="hash_height">Block hash or height.</param>
        /// <param name="ct">Cancellation Token</param>
        /// <returns></returns>
        public virtual async Task<WebCallResult<ScryptaBlock>> GetBlockAsync(string hash_height, CancellationToken ct = default)
        {
            var credits = 1;
            var url = Tatum.GetUrl(string.Format(Endpoints_GetBlockByHash, hash_height));
            return await Tatum.SendTatumRequest<ScryptaBlock>(url, HttpMethod.Get, ct, checkResult: false, signed: true, credits: credits).ConfigureAwait(false);
        }

        /// <summary>
        /// <b>Title:</b> Send LYRA to blockchain addresses<br />
        /// <b>Credits:</b> 2 credits per API call.<br />
        /// <b>Description:</b>
        /// Send Scrypta to blockchain addresses. It is possible to build a blockchain transaction in 2 ways:
        /// - fromAddress - assets will be sent from the list of addresses.For each of the addresses last 100 transactions will be scanned for any unspent UTXO and will be included in the transaction.
        /// - fromUTXO - assets will be sent from the list of unspent UTXOs. Each of the UTXO will be included in the transaction.
        /// In scrypta-like blockchains, the transaction is created from the list of previously not spent UTXO.Every UTXO contains the number of funds, which can be spent. When the UTXO enters into the transaction, the whole amount is included and must be spent.For example, address A receives 2 transactions, T1 with 1 LYRA and T2 with 2 LYRA.The transaction, which will consume UTXOs for T1 and T2, will have available amount to spent 3 LYRA = 1 LYRA (T1) + 2 LYRA(T2).
        /// There can be multiple recipients of the transactions, not only one.In the to section, every recipient address has it's corresponding amount. When the amount of funds, that should receive the recipient is lower than the number of funds from the UTXOs, the difference is used as a transaction fee.
        /// This operation needs the private key of the blockchain address.Every time the funds are transferred, the transaction must be signed with the corresponding private key.No one should ever send it's own private keys to the internet because there is a strong possibility of stealing keys and losing funds. In this method, it is possible to enter privateKey or signatureId. PrivateKey should be used only for quick development on testnet versions of blockchain when there is no risk of losing funds. In production, Tatum KMS should be used for the highest security standards, and signatureId should be present in the request. Alternatively, using the Tatum client library for supported languages or Tatum Middleware with a custom key management system is possible.
        /// </summary>
        /// <param name="fromAddress">Array of addresses and corresponding private keys. Tatum will automatically scan last 100 transactions for each address and will use all of the unspent values. We advise to use this option if you have 1 address per 1 transaction only.</param>
        /// <param name="fromUTXO">Array of transaction hashes, index of UTXO in it and corresponding private keys. Use this option if you want to calculate amount to send manually. Either fromUTXO or fromAddress must be present.</param>
        /// <param name="to">Array of addresses and values to send bitcoins to. Values must be set in BTC. Difference between from and to is transaction fee.</param>
        /// <param name="ct">Cancellation Token</param>
        /// <returns></returns>
        public virtual WebCallResult<BlockchainResponse> Send(IEnumerable<ScryptaSendOrderFromAddress> fromAddress, IEnumerable<ScryptaSendOrderFromUTXO> fromUTXO, IEnumerable<ScryptaSendOrderTo> to, CancellationToken ct = default) => SendAsync(fromAddress, fromUTXO, to, ct).Result;
        /// <summary>
        /// <b>Title:</b> Send LYRA to blockchain addresses<br />
        /// <b>Credits:</b> 2 credits per API call.<br />
        /// <b>Description:</b>
        /// Send Scrypta to blockchain addresses. It is possible to build a blockchain transaction in 2 ways:
        /// - fromAddress - assets will be sent from the list of addresses.For each of the addresses last 100 transactions will be scanned for any unspent UTXO and will be included in the transaction.
        /// - fromUTXO - assets will be sent from the list of unspent UTXOs. Each of the UTXO will be included in the transaction.
        /// In scrypta-like blockchains, the transaction is created from the list of previously not spent UTXO.Every UTXO contains the number of funds, which can be spent. When the UTXO enters into the transaction, the whole amount is included and must be spent.For example, address A receives 2 transactions, T1 with 1 LYRA and T2 with 2 LYRA.The transaction, which will consume UTXOs for T1 and T2, will have available amount to spent 3 LYRA = 1 LYRA (T1) + 2 LYRA(T2).
        /// There can be multiple recipients of the transactions, not only one.In the to section, every recipient address has it's corresponding amount. When the amount of funds, that should receive the recipient is lower than the number of funds from the UTXOs, the difference is used as a transaction fee.
        /// This operation needs the private key of the blockchain address.Every time the funds are transferred, the transaction must be signed with the corresponding private key.No one should ever send it's own private keys to the internet because there is a strong possibility of stealing keys and losing funds. In this method, it is possible to enter privateKey or signatureId. PrivateKey should be used only for quick development on testnet versions of blockchain when there is no risk of losing funds. In production, Tatum KMS should be used for the highest security standards, and signatureId should be present in the request. Alternatively, using the Tatum client library for supported languages or Tatum Middleware with a custom key management system is possible.
        /// </summary>
        /// <param name="fromAddress">Array of addresses and corresponding private keys. Tatum will automatically scan last 100 transactions for each address and will use all of the unspent values. We advise to use this option if you have 1 address per 1 transaction only.</param>
        /// <param name="fromUTXO">Array of transaction hashes, index of UTXO in it and corresponding private keys. Use this option if you want to calculate amount to send manually. Either fromUTXO or fromAddress must be present.</param>
        /// <param name="to">Array of addresses and values to send bitcoins to. Values must be set in BTC. Difference between from and to is transaction fee.</param>
        /// <param name="ct">Cancellation Token</param>
        /// <returns></returns>
        public virtual async Task<WebCallResult<BlockchainResponse>> SendAsync(IEnumerable<ScryptaSendOrderFromAddress> fromAddress, IEnumerable<ScryptaSendOrderFromUTXO> fromUTXO, IEnumerable<ScryptaSendOrderTo> to, CancellationToken ct = default)
        {
            if ((fromAddress == null || fromAddress.Count() == 0) && (fromUTXO == null || fromUTXO.Count() == 0))
                throw new ArgumentException("Either fromUTXO or fromAddress must be present.");

            var parameters = new Dictionary<string, object> {
                { "to", to },
            };
            parameters.AddOptionalParameter("fromAddress", fromAddress);
            parameters.AddOptionalParameter("fromUTXO", fromUTXO);

            var credits = 2;
            var url = Tatum.GetUrl(string.Format(Endpoints_Transaction));
            var result = await Tatum.SendTatumRequest<BlockchainResponse>(url, HttpMethod.Post, ct, checkResult: false, signed: true, parameters: parameters, credits: credits).ConfigureAwait(false);
            if (!result.Success || result.Data.Failed) return WebCallResult<BlockchainResponse>.CreateErrorResult(result.ResponseStatusCode, result.ResponseHeaders, result.Error);

            return new WebCallResult<BlockchainResponse>(result.ResponseStatusCode, result.ResponseHeaders, result.Data, null);
        }

        /// <summary>
        /// <b>Title:</b> Get Scrypta Transaction by hash<br />
        /// <b>Credits:</b> 1 credit per API call.<br />
        /// <b>Description:</b>
        /// Get Scrypta Transaction detail by transaction hash.
        /// </summary>
        /// <param name="hash">Transaction hash</param>
        /// <param name="ct">Cancellation Token</param>
        /// <returns></returns>
        public virtual WebCallResult<ScryptaTransaction> GetTransactionByHash(string hash, CancellationToken ct = default) => GetTransactionByHashAsync(hash, ct).Result;
        /// <summary>
        /// <b>Title:</b> Get Scrypta Transaction by hash<br />
        /// <b>Credits:</b> 1 credit per API call.<br />
        /// <b>Description:</b>
        /// Get Scrypta Transaction detail by transaction hash.
        /// </summary>
        /// <param name="hash">Transaction hash</param>
        /// <param name="ct">Cancellation Token</param>
        /// <returns></returns>
        public virtual async Task<WebCallResult<ScryptaTransaction>> GetTransactionByHashAsync(string hash, CancellationToken ct = default)
        {
            var credits = 1;
            var url = Tatum.GetUrl(string.Format(Endpoints_GetTransactionByHash, hash));
            return await Tatum.SendTatumRequest<ScryptaTransaction>(url, HttpMethod.Get, ct, checkResult: false, signed: true, credits: credits).ConfigureAwait(false);
        }

        /// <summary>
        /// <b>Title:</b> Get Transactions by address<br />
        /// <b>Credits:</b> 1 credit per API call.<br />
        /// <b>Description:</b>
        /// Get Scrypta Transactions by address.
        /// </summary>
        /// <param name="address">Address</param>
        /// <param name="pageSize">Max number of items per page is 50.</param>
        /// <param name="offset">Offset to obtain next page of the data.</param>
        /// <param name="ct">Cancellation Token</param>
        /// <returns></returns>
        public virtual WebCallResult<IEnumerable<ScryptaTransaction>> GetTransactionsByAddress(string address, int pageSize = 50, int offset = 0, CancellationToken ct = default) => GetTransactionsByAddressAsync(address, pageSize, offset, ct).Result;
        /// <summary>
        /// <b>Title:</b> Get Transactions by address<br />
        /// <b>Credits:</b> 1 credit per API call.<br />
        /// <b>Description:</b>
        /// Get Scrypta Transactions by address.
        /// </summary>
        /// <param name="address">Address</param>
        /// <param name="pageSize">Max number of items per page is 50.</param>
        /// <param name="offset">Offset to obtain next page of the data.</param>
        /// <param name="ct">Cancellation Token</param>
        /// <returns></returns>
        public virtual async Task<WebCallResult<IEnumerable<ScryptaTransaction>>> GetTransactionsByAddressAsync(string address, int pageSize = 50, int offset = 0, CancellationToken ct = default)
        {
            pageSize.ValidateIntBetween(nameof(pageSize), 1, 50);

            var parameters = new Dictionary<string, object> {
                { "pageSize", pageSize },
                { "offset", offset },
            };

            var credits = 1;
            var url = Tatum.GetUrl(string.Format(Endpoints_GetTransactionsByAddress, address));
            return await Tatum.SendTatumRequest<IEnumerable<ScryptaTransaction>>(url, HttpMethod.Get, ct, checkResult: false, signed: true, parameters: parameters, credits: credits).ConfigureAwait(false);
        }

        /// <summary>
        /// <b>Title:</b> Get Scrypta spendable UTXO<br />
        /// <b>Credits:</b> 1 credit per API call.<br />
        /// <b>Description:</b>
        /// Get Scrypta spendable UTXO.
        /// </summary>
        /// <param name="address">Address</param>
        /// <param name="pageSize">Max number of items per page is 50.</param>
        /// <param name="offset">Offset to obtain next page of the data.</param>
        /// <param name="ct">Cancellation Token</param>
        /// <returns></returns>
        public virtual WebCallResult<IEnumerable<ScryptaUTXO>> GetSpendableUTXO(string address, int pageSize = 50, int offset = 0, CancellationToken ct = default) => GetSpendableUTXOAsync(address, pageSize, offset, ct).Result;
        /// <summary>
        /// <b>Title:</b> Get Scrypta spendable UTXO<br />
        /// <b>Credits:</b> 1 credit per API call.<br />
        /// <b>Description:</b>
        /// Get Scrypta spendable UTXO.
        /// </summary>
        /// <param name="address">Address</param>
        /// <param name="pageSize">Max number of items per page is 50.</param>
        /// <param name="offset">Offset to obtain next page of the data.</param>
        /// <param name="ct">Cancellation Token</param>
        /// <returns></returns>
        public virtual async Task<WebCallResult<IEnumerable<ScryptaUTXO>>> GetSpendableUTXOAsync(string address, int pageSize = 50, int offset = 0, CancellationToken ct = default)
        {
            pageSize.ValidateIntBetween(nameof(pageSize), 1, 50);

            var parameters = new Dictionary<string, object> {
                { "pageSize", pageSize },
                { "offset", offset },
            };

            var credits = 1;
            var url = Tatum.GetUrl(string.Format(Endpoints_GetSpendableUTXO, address));
            return await Tatum.SendTatumRequest<IEnumerable<ScryptaUTXO>>(url, HttpMethod.Get, ct, checkResult: false, signed: true, parameters: parameters, credits: credits).ConfigureAwait(false);
        }

        /// <summary>
        /// <b>Title:</b> Get UTXO of Transaction<br />
        /// <b>Credits:</b> 1 credit per API call.<br />
        /// <b>Description:</b>
        /// Get UTXO of given transaction and output index. UTXO means Unspent Transaction Output, which is in blockchain terminology assets, that user received on the concrete address and does not spend it yet.
        /// In scrypta-like blockchains(LYRA, LTC, BCH), every transaction is built from the list of previously not spent transactions connected to the address.If user owns address A, receives in transaciont T1 10 LYRA, he can spend in the next transaction UTXO T1 of total value 10 LYRA.User can spend multiple UTXOs from different addresses in 1 transaction.
        /// If UTXO is not spent, data are returned, otherwise 404 error code.
        /// </summary>
        /// <param name="txhash">TX Hash</param>
        /// <param name="index">Index of tx output to check if spent or not</param>
        /// <param name="ct">Cancellation Token</param>
        /// <returns></returns>
        public virtual WebCallResult<ScryptaUTXO> GetTransactionUTXO(string txhash, long index, CancellationToken ct = default) => GetTransactionUTXOAsync(txhash, index, ct).Result;
        /// <summary>
        /// <b>Title:</b> Get UTXO of Transaction<br />
        /// <b>Credits:</b> 1 credit per API call.<br />
        /// <b>Description:</b>
        /// Get UTXO of given transaction and output index. UTXO means Unspent Transaction Output, which is in blockchain terminology assets, that user received on the concrete address and does not spend it yet.
        /// In scrypta-like blockchains(LYRA, LTC, BCH), every transaction is built from the list of previously not spent transactions connected to the address.If user owns address A, receives in transaciont T1 10 LYRA, he can spend in the next transaction UTXO T1 of total value 10 LYRA.User can spend multiple UTXOs from different addresses in 1 transaction.
        /// If UTXO is not spent, data are returned, otherwise 404 error code.
        /// </summary>
        /// <param name="txhash">TX Hash</param>
        /// <param name="index">Index of tx output to check if spent or not</param>
        /// <param name="ct">Cancellation Token</param>
        /// <returns></returns>
        public virtual async Task<WebCallResult<ScryptaUTXO>> GetTransactionUTXOAsync(string txhash, long index, CancellationToken ct = default)
        {
            var credits = 1;
            var url = Tatum.GetUrl(string.Format(Endpoints_GetTransactionUTXO, txhash, index));
            return await Tatum.SendTatumRequest<ScryptaUTXO>(url, HttpMethod.Get, ct, checkResult: false, signed: true, credits: credits).ConfigureAwait(false);
        }

        /// <summary>
        /// <b>Title:</b> Generate Scrypta deposit address from Extended public key<br />
        /// <b>Credits:</b> 1 credit per API call.<br />
        /// <b>Description:</b>
        /// Generate Scrypta deposit address from Extended public key. Deposit address is generated for the concrete index - each extended public key can generate up to 2^32 addresses starting from index 0 until 2^31.
        /// </summary>
        /// <param name="xpub">Extended public key of wallet.</param>
        /// <param name="index">Derivation index of desired address to be generated.</param>
        /// <param name="ct">Cancellation Token</param>
        /// <returns></returns>
        public virtual WebCallResult<TatumAddress> GenerateDepositAddress(string xpub, int index, CancellationToken ct = default) => Tatum.Blockchain_GenerateDepositAddressAsync(BlockchainType.Scrypta, xpub, index, ct).Result;
        /// <summary>
        /// <b>Title:</b> Generate Scrypta deposit address from Extended public key<br />
        /// <b>Credits:</b> 1 credit per API call.<br />
        /// <b>Description:</b>
        /// Generate Scrypta deposit address from Extended public key. Deposit address is generated for the concrete index - each extended public key can generate up to 2^32 addresses starting from index 0 until 2^31.
        /// </summary>
        /// <param name="xpub">Extended public key of wallet.</param>
        /// <param name="index">Derivation index of desired address to be generated.</param>
        /// <param name="ct">Cancellation Token</param>
        /// <returns></returns>
        public virtual async Task<WebCallResult<TatumAddress>> GenerateDepositAddressAsync(string xpub, int index, CancellationToken ct = default) => await Tatum.Blockchain_GenerateDepositAddressAsync(BlockchainType.Scrypta, xpub, index, ct);

        /// <summary>
        /// <b>Title:</b> Get Blockchain Information<br />
        /// <b>Credits:</b> 1 credit per API call.<br />
        /// <b>Description:</b>
        /// Get Scrypta Blockchain Information. Obtain basic info like testnet / mainent version of the chain, current block number and it's hash.
        /// </summary>
        /// <param name="ct">Cancellation Token</param>
        /// <returns></returns>
        public virtual WebCallResult<ScryptaChainInfo> GetBlockchainInformation(CancellationToken ct = default) => GetBlockchainInformationAsync(ct).Result;
        /// <summary>
        /// <b>Title:</b> Get Blockchain Information<br />
        /// <b>Credits:</b> 1 credit per API call.<br />
        /// <b>Description:</b>
        /// Get Scrypta Blockchain Information. Obtain basic info like testnet / mainent version of the chain, current block number and it's hash.
        /// </summary>
        /// <param name="ct">Cancellation Token</param>
        /// <returns></returns>
        public virtual async Task<WebCallResult<ScryptaChainInfo>> GetBlockchainInformationAsync(CancellationToken ct = default)
        {
            var credits = 1;
            var url = Tatum.GetUrl(string.Format(Endpoints_BlockchainInformation));
            return await Tatum.SendTatumRequest<ScryptaChainInfo>(url, HttpMethod.Get, ct, checkResult: false, signed: true, credits: credits).ConfigureAwait(false);
        }

        /// <summary>
        /// <b>Title:</b> Broadcast signed Scrypta transaction<br />
        /// <b>Credits:</b> 2 credits per API call.<br />
        /// <b>Description:</b>
        /// Broadcast signed transaction to Scrypta blockchain. This method is used internally from Tatum KMS, Tatum Middleware or Tatum client libraries. It is possible to create custom signing mechanism and use this method only for broadcasting data to the blockchian.
        /// </summary>
        /// <param name="txData">Raw signed transaction to be published to network.</param>
        /// <param name="signatureId">ID of prepared payment template to sign. Required only, when broadcasting transaction signed by Tatum KMS.</param>
        /// <param name="ct">Cancellation Token</param>
        /// <returns></returns>
        public virtual WebCallResult<BlockchainResponse> Broadcast(string txData, string signatureId = null, CancellationToken ct = default) => BroadcastAsync(txData, signatureId, ct).Result;
        /// <summary>
        /// <b>Title:</b> Broadcast signed Scrypta transaction<br />
        /// <b>Credits:</b> 2 credits per API call.<br />
        /// <b>Description:</b>
        /// Broadcast signed transaction to Scrypta blockchain. This method is used internally from Tatum KMS, Tatum Middleware or Tatum client libraries. It is possible to create custom signing mechanism and use this method only for broadcasting data to the blockchian.
        /// </summary>
        /// <param name="txData">Raw signed transaction to be published to network.</param>
        /// <param name="signatureId">ID of prepared payment template to sign. Required only, when broadcasting transaction signed by Tatum KMS.</param>
        /// <param name="ct">Cancellation Token</param>
        /// <returns></returns>
        public virtual async Task<WebCallResult<BlockchainResponse>> BroadcastAsync(string txData, string signatureId = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object> {
                { "txData", txData },
            };
            parameters.AddOptionalParameter("signatureId", signatureId);

            var credits = 2;
            var url = Tatum.GetUrl(string.Format(Endpoints_Broadcast));
            var result = await Tatum.SendTatumRequest<BlockchainResponse>(url, HttpMethod.Post, ct, checkResult: false, signed: true, parameters: parameters, credits: credits).ConfigureAwait(false);
            if (!result.Success || result.Data.Failed) return WebCallResult<BlockchainResponse>.CreateErrorResult(result.ResponseStatusCode, result.ResponseHeaders, result.Error);

            return new WebCallResult<BlockchainResponse>(result.ResponseStatusCode, result.ResponseHeaders, result.Data, null);
        }

    }
}
