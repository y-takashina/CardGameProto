using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CardGameProto
{
    interface IDurable
    {
        int Duration { get; set; }
        void Damage();
    }
}