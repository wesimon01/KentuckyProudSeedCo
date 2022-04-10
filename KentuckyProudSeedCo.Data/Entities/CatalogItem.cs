using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KentuckyProudSeedCo.Data.Entities
{
    public class CatalogItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Details { get; set; }
        public string? Description { get; set; }

        public string? ShippingInformation { get; set; } 

        public string? SatisfactionGuarentee { get; set; }

        public ICollection<Fact>? QuickFacts { get; set; } 
    }
}
