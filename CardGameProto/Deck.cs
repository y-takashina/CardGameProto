using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameProto
{
    sealed class Deck : CardCollection
    {
        private readonly IEnumerable<int> _level0;
        private readonly IEnumerable<int> _level1;
        private readonly IEnumerable<int> _level2;
        private readonly IEnumerable<int> _level3;

        public Deck(IEnumerable<int> level0, IEnumerable<int> level1, IEnumerable<int> level2, IEnumerable<int> level3)
        {
            _level0 = level0;
            _level1 = level1;
            _level2 = level2;
            _level3 = level3;
            Left = new List<Card>();
        }

        public void Initialize()
        {
            Left.Clear();
            Left.AddRange(_level0.SelectMany(id => Enumerable.Repeat(new Card(id), 6)));
            Left.AddRange(_level1.SelectMany(id => Enumerable.Repeat(new Card(id), 3)));
            Left.AddRange(_level2.SelectMany(id => Enumerable.Repeat(new Card(id), 2)));
            Left.AddRange(_level3.SelectMany(id => Enumerable.Repeat(new Card(id), 1)));
            Shuffle();
        }
    }
}