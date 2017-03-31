using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameProto
{
    abstract class InstantCard : Card, IInstant
    {
        protected InstantCard(int duration, int cost, IEnumerable<Effect> effects, IEnumerable<Effect> instantEffects) : base(duration, cost, effects)
        {
            InstantEffects = instantEffects;
        }

        public IEnumerable<Effect> InstantEffects { get; set; }
    }
}