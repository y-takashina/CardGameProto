using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameProto
{
    class Player : ICurable
    {
        public int Duration { get; set; } = 20;
        public int Cost { get; set; } = 1;
        public Deck Deck { get; set; }
        public Resource Resource { get; set; }
        public IEnumerable<Card> Hand { get; set; }

        public Player(Deck deck)
        {
            Deck = deck;
            Deck.Initialize();
            Resource = new Resource();
        }

        public void BeginPhase()
        {
            Hand = Deck.DrawCards(4);
            foreach (var card in Hand) Console.Write($"{card}, ");
        }

        public void PlayerMove()
        {
            var input = Console.ReadLine()?.Split(',');
        }

        public void Damage() => Duration--;
        public void Cure() => Duration++;
    }
}