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
            Effects = new List<Effect>();
        }

        public void Instanciate() => IsInstanced = true;

        public override string ToString() => $"Id: {Id}, Cost: {Cost}, Type: {CardType}";
    }

    enum CardType
    {
        Normal,
        Reactive,
        Instant,
    }
}