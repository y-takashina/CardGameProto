using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameProto
{
    class EffectTemplate
    {
        public readonly int Power;
        public readonly List<TargetType> TargetTypes;

        public EffectTemplate(int power, List<TargetType> targetTypes)
        {
            Power = power;
            TargetTypes = targetTypes;
        }
    }

    enum TargetType
    {
        Card,
        Effect,
        Field,
        Graveyard,
        Player,
        Resource,
    }
}