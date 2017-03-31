using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameProto
{
    class Effect : IDurable
    {
        public int Duration { get; set; }
        public IDurable Target { get; set; }
        public Func<IDurable, bool> Func { get; set; }

        public Effect(IDurable target, Func<IDurable, bool> func)
        {
            Target = target;
            Func = func;
        }

        public void Damage() => Duration--;
        public bool Execute() => Duration >= 0 && Func(Target);
    }
}