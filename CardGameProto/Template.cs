using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameProto
{
    class Template
    {
        public readonly int Id;
        public readonly int Cost;
        public readonly CardType CardType;
        public readonly IEnumerable<Effect> Effects;

        public Template(int id, int cost, CardType cardType, IEnumerable<Effect> effects)
        {
            Id = id;
            Cost = cost;
            CardType = cardType;
            Effects = effects;
        }
    }
}