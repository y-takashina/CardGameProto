using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameProto
{
    static class Extensions
    {
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> enumerable)
        {
            var rand = new Random();
            return enumerable.OrderBy(_ => rand.Next());
        }
    }
}