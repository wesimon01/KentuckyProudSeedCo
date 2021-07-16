using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KyProudSeedCoData
{
    public partial class Vegetable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Variety> Varieties { get; set; }

    }
}
