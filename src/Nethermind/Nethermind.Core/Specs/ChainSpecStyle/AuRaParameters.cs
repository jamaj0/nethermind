using System.Collections.Generic;
using Nethermind.Dirichlet.Numerics;

namespace Nethermind.Core.Specs.ChainSpecStyle
{
    /// <summary>
    ///     "stepDuration": 5,
    ///     "blockReward": "0xDE0B6B3A7640000",
    ///     "maximumUncleCountTransition": 0,
    ///     "maximumUncleCount": 0,
    ///     "validators": {
    /// "multi": {
    ///     "0": {
    ///         "safeContract": "0x8bf38d4764929064f2d4d3a56520a76ab3df415b"
    ///     },
    ///     "362296": {
    ///         "safeContract": "0xf5cE3f5D0366D6ec551C74CCb1F67e91c56F2e34"
    ///     },
    ///     "509355": {
    ///         "safeContract": "0x03048F666359CFD3C74a1A5b9a97848BF71d5038"
    ///     },
    ///     "4622420": {
    ///         "safeContract": "0x4c6a159659CCcb033F4b2e2Be0C16ACC62b89DDB"
    ///     }
    /// }
    /// },
    /// "blockRewardContractAddress": "0x3145197AD50D7083D0222DE4fCCf67d9BD05C30D",
    /// "blockRewardContractTransition": 4639000
    /// </summary>
    public class AuRaParameters
    {
        public int StepDuration { get; set; }

        public UInt256 BlockReward { get; set; }

        public long MaximumUncleCountTransition { get; set; }
        
        public int MaximumUncleCount { get; set; }
        
        public Address BlockRewardContractAddress { get; set; }
        
        public long BlockRewardContractTransition { get; set; }
        
        public Validator Validators { get; set; }
        
        public enum ValidatorType
        {
            List,
            Contract,
            ReportingContract,
            Multi
        }

        public class Validator
        {
            public ValidatorType ValidatorType { get; set; }
        
            public IDictionary<long, Validator> Validators { get; set; }

            public Address[] Addresses { get; set; }
        }
    }
}