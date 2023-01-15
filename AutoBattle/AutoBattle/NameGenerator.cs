using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using static AutoBattle.Types;
using System.Numerics;
using static AutoBattle.ClassData;

namespace AutoBattle
{
    public static class NameGenerator
    {
        private static string[] names = {
            "Arnold", "Baldrick", "Balthazar", "Balthus", "Barnabas",
            "Bartolomeo", "Barty", "Basil", "Bastien", "Benedict",
            "Bertram", "Blaise", "Bram", "Bran", "Brendan",
            "Brett", "Brock", "Brodie", "Bruno", "Cadogan",
            "Caius", "Calder", "Callum", "Calvin", "Cedric",
            "Chadwick", "Charles", "Chas", "Christian", "Christopher",
            "Cian", "Ciaran", "Clarence", "Clark", "Claudius",
            "Clement", "Colin", "Colm", "Conrad", "Corey",
            "Cornelius", "Crispin", "Crosby", "Cullen", "Curtis"
        };

        private static string[] surnames = {
            "Blackthorn", "Blacksmith", "Brightblade", "Bristlebeard", "Bronzebeard",
            "Cairnfist", "Copperheart", "Crowfoot", "Darkwater", "Dawnbringer",
            "Deepdelver", "Dragonrider", "Eagleclaw", "Earthshaker", "Emberblade",
            "Falconwing", "Fireheart", "Frostbeard", "Frostblade", "Gemheart",
            "Goldheart", "Greenshield", "Greymane", "Gryphonrider", "Hammershield",
            "Hawkfrost", "Ironfist", "Ironheart", "Ironstone", "Lionfist",
            "Longstrider", "Maplewood", "Mithrilbeard", "Moonshadow", "Nightshade",
            "Oakenheart", "Oakshield", "Pinecrest", "Redblade", "Rivershield",
            "Runebeard", "Silverheart", "Stoneshield", "Stormbringer", "Sunblade"
        };


        public static string GetRandomName()
        {
            string randomFirstName = names[Randomizer.GetRandomInt(0, names.Length)];
            string randomLastName = surnames[Randomizer.GetRandomInt(0, surnames.Length)];
            return randomFirstName + " " + randomLastName;
        }
    }
}
