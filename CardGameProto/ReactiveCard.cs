using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameProto
{
    abstract class ReactiveCard : Card, IReactive
    {
        protected ReactiveCard(int duration, int cost, IEnumerable<Effect> effects, IEnumerable<Effect> reactiveEffects) : base(duration, cost, effects)
        {
            ReactiveEffects = reactiveEffects;
        }

        public IEnumerable<Effect> ReactiveEffects { get; set; }
    }
}