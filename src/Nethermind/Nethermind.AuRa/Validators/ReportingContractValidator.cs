using Nethermind.Abi;
using Nethermind.Core.Specs.ChainSpecStyle;
using Nethermind.Logging;
using Nethermind.Store;

namespace Nethermind.AuRa.Validators
{
    public class ReportingContractValidator : ContractValidator
    {
        public ReportingContractValidator(
            AuRaParameters.Validator validator,
            IStateProvider stateProvider,
            IAbiEncoder abiEncoder,
            ILogManager logManager,
            long startBlockNumber) : base(validator, stateProvider, abiEncoder, logManager, startBlockNumber)
        {
        }
    }
}