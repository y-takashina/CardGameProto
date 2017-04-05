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
            Console.WriteLine("===== Begin phase =====");

            Hand.AddRange(Deck.Take(4));

            Console.WriteLine("Hand:");
            foreach (var card in Hand) Console.WriteLine(card);
            PrintStatus();

            Console.WriteLine();
        }

        public void ActionPhase()
        {
            Console.WriteLine("===== Action phase =====");

            var line = Console.ReadLine();
            while (!string.IsNullOrEmpty(line) && int.TryParse(line, out int command) && Hand.Duration > command)
            {
                Console.WriteLine($"{Hand[command].Id} was instansiated.");
                var card = Hand.TakeAt(command);
                Field.Add(card);
                if (card.CardType == CardType.Instant)
                {
                    foreach (var effect in card.Effects) effect.Execute();
                }
                line = Console.ReadLine();
            }

            Console.WriteLine("Field:");
            foreach (var card in Field) Console.WriteLine(card);

            Console.WriteLine();
        }

        public void EndPhase()
        {
            Console.WriteLine("===== End phase =====");

            Decrement();
            Hand.Decrement();
            Resource.Decrement();
            var removed = new List<Card>();
            foreach (var card in Field)
            {
                foreach (var effect in card.Effects) effect.Execute();
                card.Decrement();
                if (card.Duration == 0) removed.Add(card);
            }
            foreach (var card in removed)
            {
                Console.WriteLine($"{card.Id} was deleted.");
                Field.Remove(card);
                Graveyard.Add(card);
            }

            Console.WriteLine("Field:");
            foreach (var card in Field) Console.WriteLine(card);
            PrintStatus();

            Console.WriteLine();
        }

        public void PrintStatus()
        {
            Console.WriteLine($"Deck: {Deck.Duration}, Resource: {Resource.Duration}, Hand: {Hand.Duration}, Graveyard: {Graveyard.Duration}");
        }
    }
}