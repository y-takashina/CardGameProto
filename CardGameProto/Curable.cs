using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameProto
{
    class Curable : Durable
    {
        public virtual void Increment(int count = 1) => Duration += count;
    }
}