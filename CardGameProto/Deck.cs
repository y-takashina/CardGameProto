using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameProto
{
    class Deck : IDurable
    {
        private IEnumerable<Card> _left;
        private readonly IEnumerable<Card> _level0;
        private readonly IEnumerable<Card> _level1;
        private readonly IEnumerable<Card> _level2;
        private readonly IEnumerable<Card> _level3;

        public Deck(IEnumerable<Card> level0, IEnumerable<Card> level1, IEnumerable<Card> level2, IEnumerable<Card> level3)
        {
            _level0 = level0;
            _level1 = level1;
            _level2 = level2;
            _level3 = level3;
        }

        public int Duration
        {
            get { return _left.Count(); }
            set { throw new InvalidOperationException("Duration of Deck is determined by _left.Count(). Cannot be set explicitly."); }
        }

        public void Initialize()
        {
            var list = new List<Card>();
            list.AddRange(_level0.SelectMany(card => Enumerable.Repeat(card, 6)));
            list.AddRange(_level1.SelectMany(card => Enumerable.Repeat(card, 3)));
            list.AddRange(_level2.SelectMany(card => Enumerable.Repeat(card, 2)));
            list.AddRange(_level3.SelectMany(card => Enumerable.Repeat(card, 1)));
            _left = list.Select(v => v).Shuffle();
        }

        public void Shuffle()
        {
            _left = _left.Shuffle();
        }

        public IEnumerable<Card> DrawCards(int n)
        {
            var cards = _left.Take(n);
            _left = _left.Skip(n);
            return cards;
        }

        public void Damage() => _left = _left.Skip(1);
    }
}