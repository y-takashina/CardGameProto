using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameProto
{
    sealed class Card : Curable
    {
        public int Id { get; set; }
        public int Cost { get; set; }
        public CardType CardType { get; set; }
        public IEnumerable<Effect> Effects { get; set; }
        public bool IsInstanced { get; set; }

        public Card(int id)
        {
            Id = id;
            IsInstanced = false;
        }

        public void Instanciate() => IsInstanced = true;
    }

    enum CardType
    {
        Normal,
        Reactive,
        Instant,
    }
}