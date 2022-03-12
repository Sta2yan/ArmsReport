using System;
using System.Collections.Generic;
using System.Linq;

namespace ArmsReport
{
    class Progam
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            List<Soldier> soldiers = new List<Soldier>();
            int countSoldiers = 5;
            int maximumArmament = Enum.GetNames(typeof(Armament)).Length;
            int maximumRank = Enum.GetNames(typeof(Rank)).Length;
            int maximumServiceLife = 13;
            int minimumServiceLife = 1;

            for (int i = 0; i < countSoldiers; i++)
            {
                soldiers.Add(new Soldier($"Солдат_{i + 1}", (Armament)random.Next(0, maximumArmament), (Rank)random.Next(0, maximumRank), random.Next(minimumServiceLife, maximumServiceLife)));
            }

            var filteredSoliders = soldiers.Select(solider => new
            {
                Name = solider.Name,
                Rank = solider.Rank,
            });

            foreach (var solider in filteredSoliders)
            {
                Console.WriteLine($"Солдат - {solider.Name} | Звание - {solider.Rank}");
            }
        }
    }

    enum Armament
    {
        Automaton,
        Pistol,
        GrenadeLauncher
    }

    enum Rank
    {
        Ordinary,
        Sergeant,
        Ensign
    }

    class Soldier
    {
        public string Name { get; private set; }
        public Armament Armament { get; private set; }
        public Rank Rank { get; private set; }
        public int ServiceLife { get; private set; }

        public Soldier(string name, Armament armament, Rank rank, int serviceLife)
        {
            Name = name;
            Armament = armament;
            Rank = rank;
            ServiceLife = serviceLife;
        }
    }
}