using System.Collections.Generic;

namespace TDASharp.TDA.MarketHours
{
    public class MarketHours
    {
        public Category category { get; set; }
        public Date date { get; set; }
        public Exchange exchange { get; set; }
        public IsOpen isOpen { get; set; }
        public MarketType marketType { get; set; }
        public Product product { get; set; }
        public ProductName productName { get; set; }
        public SessionHours sessionHours { get; set; }
        public class Category
        {
            public string type { get; set; }
        }

        public class Date
        {
            public string type { get; set; }
        }

        public class Exchange
        {
            public string type { get; set; }
        }

        public class IsOpen
        {
            public string type { get; set; }
        }

        public class MarketType
        {
            public string type { get; set; }
            public List<string> @enum { get; set; }
        }

        public class Product
        {
            public string type { get; set; }
        }

        public class ProductName
        {
            public string type { get; set; }
        }

        public class Items
        {
            public string type { get; set; }
        }

        public class AdditionalProperties
        {
            public string type { get; set; }
            public Items items { get; set; }
        }

        public class SessionHours
        {
            public string type { get; set; }
            public AdditionalProperties additionalProperties { get; set; }
        }

    }
}
