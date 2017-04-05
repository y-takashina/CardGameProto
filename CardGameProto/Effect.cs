using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameProto
{
    abstract class Effect : Durable
    {
        public int Count { get; set; }
        public abstract bool Execute();
    }

    class DamageEffect : Effect
    {
        public Durable Target { get; set; }

        public DamageEffect(Durable target, int count)
        {
            Count = count;
            Target = target;
        }

        public override bool Execute()
        {
            if (Duration < 0) return false;
            Target.Decrement(Count);
            return true;
        }
    }

    class CureEffect : Effect
    {
        public Curable Target { get; set; }

        public CureEffect(Curable target)
        {
            Target = target;
        }

        public override bool Execute()
        {
            if (Duration < 0) return false;
            Target.Increment(Count);
            return true;
        }
    }
}