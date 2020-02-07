//  Copyright (c) 2018 Demerzel Solutions Limited
//  This file is part of the Nethermind library.
// 
//  The Nethermind library is free software: you can redistribute it and/or modify
//  it under the terms of the GNU Lesser General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  The Nethermind library is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
//  GNU Lesser General Public License for more details.
// 
//  You should have received a copy of the GNU Lesser General Public License
//  along with the Nethermind. If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Collections.Generic;
using System.Threading;
using Nethermind.AuRa.Validators;
using Nethermind.Blockchain;
using Nethermind.Blockchain.Producers;
using Nethermind.Blockchain.Receipts;
using Nethermind.Blockchain.Rewards;
using Nethermind.Blockchain.Synchronization;
using Nethermind.Blockchain.TxPools;
using Nethermind.Blockchain.Validators;
using Nethermind.Clique;
using Nethermind.Config;
using Nethermind.Core;
using Nethermind.Core.Specs;
using Nethermind.Crypto;
using Nethermind.DataMarketplace.Channels;
using Nethermind.DataMarketplace.Core;
using Nethermind.DataMarketplace.Initializers;
using Nethermind.Evm;
using Nethermind.Facade.Proxy;
using Nethermind.Grpc;
using Nethermind.JsonRpc.Modules;
using Nethermind.KeyStore;
using Nethermind.Logging;
using Nethermind.Mining;
using Nethermind.Monitoring;
using Nethermind.Network;
using Nethermind.Network.Config;
using Nethermind.Network.Discovery;
using Nethermind.Network.Rlpx;
using Nethermind.PubSub;
using Nethermind.Serialization.Json;
using Nethermind.Specs.ChainSpecStyle;
using Nethermind.Stats;
using Nethermind.Store;
using Nethermind.Store.BeamSync;
using Nethermind.Store.Repositories;
using Nethermind.Wallet;
using Nethermind.WebSockets;

namespace Nethermind.Runner.Ethereum.Context
{
    public class EthereumRunnerContext
    {
        public T Config<T>() where T : IConfig
        {
            return ConfigProvider.GetConfig<T>();
        }
        
        public Stack<IDisposable> DisposeStack { get; }= new Stack<IDisposable>();

        public List<IProducer> Producers { get; }= new List<IProducer>();
        public IGrpcServer GrpcServer { get; set; }
        public ILogManager LogManager{ get; set; }
        public INdmConsumerChannelManager NdmConsumerChannelManager { get; set; }
        public INdmDataPublisher NdmDataPublisher { get; set; }
        public INdmInitializer NdmInitializer { get; set; }
        public INodeDataConsumer NodeDataConsumer { get; set; } = NullDataConsumer.Instance;
        public ILogger Logger { get; set; }

        public IRpcModuleProvider RpcModuleProvider { get; set; }
        public IConfigProvider ConfigProvider { get; set; }
        public IIpResolver IpResolver { get; set; }
        public PrivateKey NodeKey { get; set; }
        public ChainSpec ChainSpec { get; set; }
        public ICryptoRandom CryptoRandom { get; } = new CryptoRandom();
        public IJsonSerializer EthereumJsonSerializer { get; set; }
        public CancellationTokenSource RunnerCancellation { get; set; }
        public IBlockchainProcessor BlockchainProcessor { get; set; }
        public IDiscoveryApp DiscoveryApp { get; set; }
        public IMessageSerializationService _messageSerializationService { get; } = new MessageSerializationService();
        public INodeStatsManager NodeStatsManager { get; set; }
        public ITxPool TxPool { get; set; }
        public IReceiptStorage ReceiptStorage { get; set; }
        public IEthereumEcdsa EthereumEcdsa { get; set; }
        public IEthSyncPeerPool SyncPeerPool { get; set; }
        public ISynchronizer Synchronizer { get; set; }
        public ISyncServer SyncServer { get; set; }
        public IKeyStore KeyStore { get; set; }
        public IPeerManager PeerManager { get; set; }
        public IProtocolsManager ProtocolsManager { get; set; }
        public IBlockTree BlockTree { get; set; }
        public IBlockValidator BlockValidator { get; set; }
        public IHeaderValidator HeaderValidator { get; set; }
        public IBlockDataRecoveryStep RecoveryStep { get; set; }
        public IBlockProcessor BlockProcessor { get; set; }
        public IRewardCalculatorSource RewardCalculatorSource { get; set; }
        public ISpecProvider SpecProvider { get; set; }
        public IStateProvider StateProvider { get; set; }
        public ISealer Sealer { get; set; }
        public ISealValidator SealValidator { get; set; }
        public IBlockProducer BlockProducer { get; set; }
        public IDbProvider DbProvider { get; set; }
        public ITimestamper Timestamper { get; } = Core.Timestamper.Default;
        public IStorageProvider StorageProvider { get; set; }
        public IWallet Wallet { get; set; }
        public IEnode Enode { get; set; }
        public ISessionMonitor SessionMonitor { get; set; }
        public IStaticNodesManager StaticNodesManager { get; set; }
        public ITransactionProcessor TransactionProcessor { get; set; }
        public ITxPoolInfoProvider TxPoolInfoProvider { get; set; }
        public INetworkConfig NetworkConfig { get; set; }
        public IChainLevelInfoRepository ChainLevelInfoRepository { get; set; }
        public IBlockProcessingQueue BlockProcessingQueue { get; set; }
        public IValidatorStore ValidatorStore { get; set; }
        
        public IRlpxPeer RlpxPeer;
        public IWebSocketsManager WebSocketsManager;
        public IJsonRpcClientProxy JsonRpcClientProxy;
        public IEthJsonRpcClientProxy EthJsonRpcClientProxy;
        public IHttpClient HttpClient;
        public IMonitoringService MonitoringService;
    }
}