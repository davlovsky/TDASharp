using System.Collections.Generic;

namespace TDASharp
{
    public class Orders
    {
        public Session session { get; set; }
        public Duration duration { get; set; }
        public OrderType orderType { get; set; }
        public CancelTime cancelTime { get; set; }
        public ComplexOrderStrategyType complexOrderStrategyType { get; set; }
        public Quantity quantity { get; set; }
        public FilledQuantity filledQuantity { get; set; }
        public RemainingQuantity remainingQuantity { get; set; }
        public RequestedDestination requestedDestination { get; set; }
        public DestinationLinkName destinationLinkName { get; set; }
        public ReleaseTime releaseTime { get; set; }
        public StopPrice stopPrice { get; set; }
        public StopPriceLinkBasis stopPriceLinkBasis { get; set; }
        public StopPriceLinkType stopPriceLinkType { get; set; }
        public StopPriceOffset stopPriceOffset { get; set; }
        public StopType stopType { get; set; }
        public PriceLinkBasis priceLinkBasis { get; set; }
        public PriceLinkType priceLinkType { get; set; }
        public Price price { get; set; }
        public TaxLotMethod taxLotMethod { get; set; }
        public OrderLegCollection orderLegCollection { get; set; }
        public ActivationPrice activationPrice { get; set; }
        public SpecialInstruction specialInstruction { get; set; }
        public OrderStrategyType orderStrategyType { get; set; }
        public OrderId orderId { get; set; }
        public Cancelable cancelable { get; set; }
        public Editable editable { get; set; }
        public Status status { get; set; }
        public EnteredTime enteredTime { get; set; }
        public CloseTime closeTime { get; set; }
        public Tag tag { get; set; }
        public AccountId accountId { get; set; }
        public OrderActivityCollection orderActivityCollection { get; set; }
        public ReplacingOrderCollection2 replacingOrderCollection { get; set; }
        public ChildOrderStrategies childOrderStrategies { get; set; }
        public StatusDescription statusDescription { get; set; }
        public SavedOrderId savedOrderId { get; set; }
        public SavedTime savedTime { get; set; }
        public class Session
        {
            public string type { get; set; }
            public List<string> @enum { get; set; }
        }

        public class Duration
        {
            public string type { get; set; }
            public List<string> @enum { get; set; }
        }

        public class OrderType
        {
            public string type { get; set; }
            public List<string> @enum { get; set; }
        }

        public class Date
        {
            public string type { get; set; }
        }

        public class ShortFormat
        {
            public string type { get; set; }
            public bool @default { get; set; }
        }

        public class Properties
        {
            public Date date { get; set; }
            public ShortFormat shortFormat { get; set; }
            public AssetType assetType { get; set; }
            public Cusip cusip { get; set; }
            public Symbol symbol { get; set; }
            public Description description { get; set; }
            public OrderLegType orderLegType { get; set; }
            public LegId legId { get; set; }
            public Instrument instrument { get; set; }
            public Instruction instruction { get; set; }
            public PositionEffect positionEffect { get; set; }
            public Quantity quantity { get; set; }
            public QuantityType quantityType { get; set; }
            public ActivityType activityType { get; set; }
            public Session session { get; set; }
            public Duration duration { get; set; }
            public OrderType orderType { get; set; }
            public CancelTime cancelTime { get; set; }
            public ComplexOrderStrategyType complexOrderStrategyType { get; set; }
            public FilledQuantity filledQuantity { get; set; }
            public RemainingQuantity remainingQuantity { get; set; }
            public RequestedDestination requestedDestination { get; set; }
            public DestinationLinkName destinationLinkName { get; set; }
            public ReleaseTime releaseTime { get; set; }
            public StopPrice stopPrice { get; set; }
            public StopPriceLinkBasis stopPriceLinkBasis { get; set; }
            public StopPriceLinkType stopPriceLinkType { get; set; }
            public StopPriceOffset stopPriceOffset { get; set; }
            public StopType stopType { get; set; }
            public PriceLinkBasis priceLinkBasis { get; set; }
            public PriceLinkType priceLinkType { get; set; }
            public Price price { get; set; }
            public TaxLotMethod taxLotMethod { get; set; }
            public OrderLegCollection orderLegCollection { get; set; }
            public ActivationPrice activationPrice { get; set; }
            public SpecialInstruction specialInstruction { get; set; }
            public OrderStrategyType orderStrategyType { get; set; }
            public OrderId orderId { get; set; }
            public Cancelable cancelable { get; set; }
            public Editable editable { get; set; }
            public Status status { get; set; }
            public EnteredTime enteredTime { get; set; }
            public CloseTime closeTime { get; set; }
            public Tag tag { get; set; }
            public AccountId accountId { get; set; }
            public OrderActivityCollection orderActivityCollection { get; set; }
            public ReplacingOrderCollection2 replacingOrderCollection { get; set; }
            public ChildOrderStrategies childOrderStrategies { get; set; }
            public StatusDescription statusDescription { get; set; }
        }

        public class CancelTime
        {
            public string type { get; set; }
            public Properties properties { get; set; }
        }

        public class ComplexOrderStrategyType
        {
            public string type { get; set; }
            public List<string> @enum { get; set; }
        }

        public class Quantity
        {
            public string type { get; set; }
            public string format { get; set; }
        }

        public class FilledQuantity
        {
            public string type { get; set; }
            public string format { get; set; }
        }

        public class RemainingQuantity
        {
            public string type { get; set; }
            public string format { get; set; }
        }

        public class RequestedDestination
        {
            public string type { get; set; }
            public List<string> @enum { get; set; }
        }

        public class DestinationLinkName
        {
            public string type { get; set; }
        }

        public class ReleaseTime
        {
            public string type { get; set; }
            public string format { get; set; }
        }

        public class StopPrice
        {
            public string type { get; set; }
            public string format { get; set; }
        }

        public class StopPriceLinkBasis
        {
            public string type { get; set; }
            public List<string> @enum { get; set; }
        }

        public class StopPriceLinkType
        {
            public string type { get; set; }
            public List<string> @enum { get; set; }
        }

        public class StopPriceOffset
        {
            public string type { get; set; }
            public string format { get; set; }
        }

        public class StopType
        {
            public string type { get; set; }
            public List<string> @enum { get; set; }
        }

        public class PriceLinkBasis
        {
            public string type { get; set; }
            public List<string> @enum { get; set; }
        }

        public class PriceLinkType
        {
            public string type { get; set; }
            public List<string> @enum { get; set; }
        }

        public class Price
        {
            public string type { get; set; }
            public string format { get; set; }
        }

        public class TaxLotMethod
        {
            public string type { get; set; }
            public List<string> @enum { get; set; }
        }

        public class Xml
        {
            public string name { get; set; }
            public bool wrapped { get; set; }
        }

        public class OrderLegType
        {
            public string type { get; set; }
            public List<string> @enum { get; set; }
        }

        public class LegId
        {
            public string type { get; set; }
            public string format { get; set; }
        }

        public class AssetType
        {
            public string type { get; set; }
            public List<string> @enum { get; set; }
        }

        public class Cusip
        {
            public string type { get; set; }
        }

        public class Symbol
        {
            public string type { get; set; }
        }

        public class Description
        {
            public string type { get; set; }
        }

        public class Instrument
        {
            public string type { get; set; }
            public string discriminator { get; set; }
            public Properties properties { get; set; }
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

        public class QuantityType
        {
            public string type { get; set; }
            public List<string> @enum { get; set; }
        }

        public class Items
        {
            public string type { get; set; }
            public Properties properties { get; set; }
            public string discriminator { get; set; }
        }

        public class OrderLegCollection
        {
            public string type { get; set; }
            public Xml xml { get; set; }
            public Items items { get; set; }
        }

        public class ActivationPrice
        {
            public string type { get; set; }
            public string format { get; set; }
        }

        public class SpecialInstruction
        {
            public string type { get; set; }
            public List<string> @enum { get; set; }
        }

        public class OrderStrategyType
        {
            public string type { get; set; }
            public List<string> @enum { get; set; }
        }

        public class OrderId
        {
            public string type { get; set; }
            public string format { get; set; }
        }

        public class Cancelable
        {
            public string type { get; set; }
            public bool @default { get; set; }
        }

        public class Editable
        {
            public string type { get; set; }
            public bool @default { get; set; }
        }

        public class Status
        {
            public string type { get; set; }
            public List<string> @enum { get; set; }
        }

        public class EnteredTime
        {
            public string type { get; set; }
            public string format { get; set; }
        }

        public class CloseTime
        {
            public string type { get; set; }
            public string format { get; set; }
        }

        public class Tag
        {
            public string type { get; set; }
        }

        public class AccountId
        {
            public string type { get; set; }
            public string format { get; set; }
        }

        public class ActivityType
        {
            public string type { get; set; }
            public List<string> @enum { get; set; }
        }

        public class OrderActivityCollection
        {
            public string type { get; set; }
            public Xml xml { get; set; }
            public Items items { get; set; }
        }

        public class ReplacingOrderCollection2
        {
            public string type { get; set; }
            public Xml xml { get; set; }
            public Items items { get; set; }
        }

        public class ChildOrderStrategies
        {
            public string type { get; set; }
            public Xml xml { get; set; }
            public Items items { get; set; }
        }

        public class StatusDescription
        {
            public string type { get; set; }
        }

        public class SavedOrderId
        {
            public string type { get; set; }
            public string format { get; set; }
        }

        public class SavedTime
        {
            public string type { get; set; }
            public string format { get; set; }
        }
    }
}
