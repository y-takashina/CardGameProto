using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameProto
{
    sealed class Player : Curable
    {
        public Deck Deck { get; set; }
        public CardCollection Hand { get; set; }
        public CardCollection Field { get; set; }
        public CardCollection Graveyard { get; set; }
        public Curable Resource { get; set; }

        public Player(Deck deck)
        {
            Duration = 24;
            Deck = deck;
            Deck.Initialize();
            Resource = new Curable();
            Hand = new CardCollection();
            Field = new CardCollection();
            Graveyard = new CardCollection();
        }

        public void BeginPhase()
        {
            Hand.Add(Deck.Take(4));
            foreach (var card in Hand) Console.Write($"{card}, ");
        }

        public void ActionPhase()
        {
            var line = Console.ReadLine();
            while (!string.IsNullOrEmpty(line))
            {
                var command = int.Parse(line);
                Field.Add(Hand.TakeAt(command));
                line = Console.ReadLine();
            }
        }

        public void EndPhase()
        {
            Decrement();
            Resource.Decrement();
            foreach (var card in Field)
            {
                foreach (var effect in card.Effects)
                {
                    effect.Execute();
                }
            }
            foreach (var card in Field)
            {
                card.Decrement();
                if (card.Duration < 0) Field.Remove(card);
                Graveyard.Add(card);
            }
            foreach (var card in Field) Console.Write($"{card}, ");
            Console.WriteLine("---------------------------------");
        }
    }
}