using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameProto
{
    class Program
    {
        static void Main(string[] args)
        {
            // Title: Duration
            var deck = new Deck(new[] {0}, new[] {0}, new[] {0}, new[] {0});
            var player = new Player(deck);
            for (var i = 0; i < 5; i++)
            {
                player.BeginPhase();
                player.ActionPhase();
                player.EndPhase();
                Console.ReadLine();
            }
        }
    }
}