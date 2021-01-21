using System.Collections.Generic;

namespace TDASharp.TDA.TransactionHistory
{
    public class TransactionHistory
    {
        public Type type { get; set; }
        public ClearingReferenceNumber clearingReferenceNumber { get; set; }
        public SubAccount subAccount { get; set; }
        public SettlementDate settlementDate { get; set; }
        public OrderId orderId { get; set; }
        public Sma sma { get; set; }
        public RequirementReallocationAmount requirementReallocationAmount { get; set; }
        public DayTradeBuyingPowerEffect dayTradeBuyingPowerEffect { get; set; }
        public NetAmount netAmount { get; set; }
        public TransactionDate transactionDate { get; set; }
        public OrderDate orderDate { get; set; }
        public TransactionSubType transactionSubType { get; set; }
        public TransactionId transactionId { get; set; }
        public CashBalanceEffectFlag cashBalanceEffectFlag { get; set; }
        public Description description { get; set; }
        public AchStatus achStatus { get; set; }
        public AccruedInterest accruedInterest { get; set; }
        public Fees fees { get; set; }
        public TransactionItem transactionItem { get; set; }

        public class Type
        {
            public string type { get; set; }
            public List<string> @enum { get; set; }
        }

        public class ClearingReferenceNumber
        {
            public string type { get; set; }
        }

        public class SubAccount
        {
            public string type { get; set; }
        }

        public class SettlementDate
        {
            public string type { get; set; }
            public string format { get; set; }
        }

        public class OrderId
        {
            public string type { get; set; }
        }

        public class Sma
        {
            public string type { get; set; }
            public string format { get; set; }
        }

        public class RequirementReallocationAmount
        {
            public string type { get; set; }
            public string format { get; set; }
        }

        public class DayTradeBuyingPowerEffect
        {
            public string type { get; set; }
            public string format { get; set; }
        }

        public class NetAmount
        {
            public string type { get; set; }
            public string format { get; set; }
        }

        public class TransactionDate
        {
            public string type { get; set; }
            public string format { get; set; }
        }

        public class OrderDate
        {
            public string type { get; set; }
            public string format { get; set; }
        }

        public class TransactionSubType
        {
            public string type { get; set; }
        }

        public class TransactionId
        {
            public string type { get; set; }
            public string format { get; set; }
        }

        public class CashBalanceEffectFlag
        {
            public string type { get; set; }
            public bool @default { get; set; }
        }

        public class Description
        {
            public string type { get; set; }
        }

        public class AchStatus
        {
            public string type { get; set; }
            public List<string> @enum { get; set; }
        }

        public class AccruedInterest
        {
            public string type { get; set; }
            public string format { get; set; }
        }

        public class AdditionalProperties
        {
            public string type { get; set; }
            public string format { get; set; }
        }

        public class Fees
        {
            public string type { get; set; }
            public AdditionalProperties additionalProperties { get; set; }
        }

        public class AccountId
        {
            public string type { get; set; }
            public string format { get; set; }
        }

        public class Amount
        {
            public string type { get; set; }
            public string format { get; set; }
        }

        public class Price
        {
            public string type { get; set; }
            public string format { get; set; }
        }

        public class Cost
        {
            public string type { get; set; }
            public string format { get; set; }
        }

        public class ParentOrderKey
        {
            public string type { get; set; }
            public string format { get; set; }
        }

        public class ParentChildIndicator
        {
            public string type { get; set; }
        }

        public class Instruction
        {
            public string type { get; set; }
            public List<string> @enum { get; set; }
        }

        public class PositionEffect
        {
            public string type { get; set; }
            public List<string> @enum { get; set; }
        }

        public class Symbol
        {
            public string type { get; set; }
        }

        public class UnderlyingSymbol
        {
            public string type { get; set; }
        }

        public class OptionExpirationDate
        {
            public string type { get; set; }
            public string format { get; set; }
        }

        public class OptionStrikePrice
        {
            public string type { get; set; }
            public string format { get; set; }
        }

        public class PutCall
        {
            public string type { get; set; }
            public List<string> @enum { get; set; }
        }

        public class Cusip
        {
            public string type { get; set; }
        }

        public class AssetType
        {
            public string type { get; set; }
            public List<string> @enum { get; set; }
        }

        public class BondMaturityDate
        {
            public string type { get; set; }
            public string format { get; set; }
        }

        public class BondInterestRate
        {
            public string type { get; set; }
            public string format { get; set; }
        }

        public class Properties2
        {
            public Symbol symbol { get; set; }
            public UnderlyingSymbol underlyingSymbol { get; set; }
            public OptionExpirationDate optionExpirationDate { get; set; }
            public OptionStrikePrice optionStrikePrice { get; set; }
            public PutCall putCall { get; set; }
            public Cusip cusip { get; set; }
            public Description description { get; set; }
            public AssetType assetType { get; set; }
            public BondMaturityDate bondMaturityDate { get; set; }
            public BondInterestRate bondInterestRate { get; set; }
            public AccountId accountId { get; set; }
            public Amount amount { get; set; }
            public Price price { get; set; }
            public Cost cost { get; set; }
            public ParentOrderKey parentOrderKey { get; set; }
            public ParentChildIndicator parentChildIndicator { get; set; }
            public Instruction instruction { get; set; }
            public PositionEffect positionEffect { get; set; }
            public Instrument instrument { get; set; }
        }

        public class Instrument
        {
            public string type { get; set; }
            public Properties2 properties { get; set; }
        }

        public class TransactionItem
        {
            public string type { get; set; }
            public Properties2 properties { get; set; }
        }
    }
}
