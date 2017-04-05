using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameProto
{
    class CardCollection : Durable, IEnumerable<Card>
    {
        protected List<Card> Left;

        public CardCollection()
        {
            Left = new List<Card>();
        }

        public override int Duration
        {
            get { return Left.Count; }
            protected set { throw new InvalidOperationException("Duration of Deck is determined by `Left.Count()`. Cannot be set explicitly."); }
        }

        public override void Decrement(int count = 1)
        {
            if (Duration < count) count = Duration;
            Left.RemoveRange(0, count);
        }

        public void AddRange(IEnumerable<Card> cards)
        {
            Left.AddRange(cards);
        }

        public void Add(Card card)
        {
            Left.Add(card);
        }

        public void Remove(Card card)
        {
            Left.Remove(card);
        }

        public void Remove(int id)
        {
            Left.Remove(Left.Find(card => card.Id == id));
        }

        public void RemoveAt(int index)
        {
            Left.RemoveAt(index);
        }

        public void Shuffle()
        {
            Left = Left.Shuffle().ToList();
        }

        public IEnumerable<Card> Take(int count = 1)
        {
            var cards = Left.Take(count);
            Decrement(count);
            return cards;
        }

        public Card TakeAt(int index)
        {
            var card = Left[index];
            RemoveAt(index);
            return card;
        }

        public Card this[int i] => Left[i];

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<Card> GetEnumerator()
        {
            return Left.GetEnumerator();
        }
    }
}