using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CardGameProto
{
    class Program
    {
        static void Main(string[] args)
        {
            string json;
            using (var sr = new StreamReader(@".\card.json"))
            {
                json = sr.ReadToEnd();
            }
            var obj = JsonConvert.DeserializeObject<CardTemplate>(json);
            Console.WriteLine(obj);


            // Title: Duration
            var deck = new Deck(new[] {0}, new[] {1, 2}, new[] {10, 20, 30}, new[] {100, 200, 300, 400, 500, 600});
            var player = new Player(deck);
            for (var i = 0; i < 5; i++)
            {
                player.BeginPhase();
                player.ActionPhase();
                player.EndPhase();
            }
        }
    }
}