using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameProto
{
    interface IInstant
    {
        IEnumerable<Effect> InstantEffects { get; set; }
    }
}