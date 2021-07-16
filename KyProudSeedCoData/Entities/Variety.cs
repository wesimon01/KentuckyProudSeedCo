using System.Collections.Generic;

namespace KyProudSeedCoData
{
    public partial class Variety
    {
        public int Id { get; set; }

        public Vegetable Vegetable { get; set; }

        public string Name { get; set; }

        public string Details { get; set; }

        public string Description { get; set; }

        public int DaysToMaturity { get; set; }

        public string LatinName { get; set; }

        public string LifeCycle { get; set; }

        public string HybridStatus { get; set; }

        public bool InStock { get; set; }

        ICollection<Packet> Packets { get; set; }
    }
}