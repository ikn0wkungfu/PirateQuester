using System.Numerics;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace DFKContracts.QuestCore.ContractDefinition
{
    public partial class Quest : QuestBase
	{
        public string QuestName()
        {
            return PirateQuester.DFK.Contracts.ContractDefinitions.GetQuestContractFromAddress(QuestAddress)?.Name;
        }
		public DateTime StartTime()
		{
			return DateTime.UtcNow + new TimeSpan((long.Parse(StartAtTime.ToString()) - DateTimeOffset.UtcNow.ToUnixTimeSeconds()) * 1000000);
		}
		public DateTime CompleteTime()
		{
			return DateTime.UtcNow + new TimeSpan((long.Parse(CompleteAtTime.ToString()) - DateTimeOffset.UtcNow.ToUnixTimeSeconds()) * 1000000);
		}
	}

    public class QuestBase 
    {
        [Parameter("uint256", "id", 1)]
        public virtual BigInteger Id { get; set; }
        [Parameter("address", "questAddress", 2)]
        public virtual string QuestAddress { get; set; }
        [Parameter("uint8", "level", 3)]
        public virtual byte Level { get; set; }
        [Parameter("uint256[]", "heroes", 4)]
        public virtual List<BigInteger> Heroes { get; set; }
        [Parameter("address", "player", 5)]
        public virtual string Player { get; set; }
        [Parameter("uint256", "startBlock", 6)]
        public virtual BigInteger StartBlock { get; set; }
        [Parameter("uint256", "startAtTime", 7)]
        public virtual BigInteger StartAtTime { get; set; }
        [Parameter("uint256", "completeAtTime", 8)]
        public virtual BigInteger CompleteAtTime { get; set; }
        [Parameter("uint8", "attempts", 9)]
        public virtual byte Attempts { get; set; }
        [Parameter("uint8", "status", 10)]
        public virtual byte Status { get; set; }
    }
}
