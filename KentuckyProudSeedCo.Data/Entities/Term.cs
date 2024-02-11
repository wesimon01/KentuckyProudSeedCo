using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KentuckyProudSeedCo.Data.Entities
{
    public class Term
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Explaination { get; set; }
    }
}
