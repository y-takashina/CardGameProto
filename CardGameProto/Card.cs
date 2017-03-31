using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameProto
{
    abstract class Card : ICurable
    {
        public int Duration { get; set; }
        public int Cost { get; set; }
        public IEnumerable<Effect> Effects { get; set; }
        public bool IsInstanced { get; set; }

        protected Card(int duration, int cost, IEnumerable<Effect> effects)
        {
            Duration = duration;
            Cost = cost;
            Effects = effects;
            IsInstanced = false;
        }

        public void Damage() => Duration--;
        public void Cure() => Duration++;
        public void Instanciate() => IsInstanced = true;
    }
}