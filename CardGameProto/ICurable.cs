using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameProto
{
    interface ICurable : IDurable
    {
        int Cost { get; set; }
        void Cure();
    }
}