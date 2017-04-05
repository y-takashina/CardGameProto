using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CardGameProto
{
    abstract class Durable
    {
        public virtual int Duration { get; protected set; }
        public virtual void Decrement(int count = 1) => Duration -= count;
    }
}