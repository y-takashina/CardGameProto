using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameProto
{
    class Resource : ICurable
    {
        public int Duration { get; set; }
        public int Cost { get; set; } = 1;
        public void Damage() => Duration--;
        public void Cure() => Duration++;
    }
}