using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameProto
{
    interface IReactive
    {
        IEnumerable<Effect> ReactiveEffects { get; set; }
    }
}