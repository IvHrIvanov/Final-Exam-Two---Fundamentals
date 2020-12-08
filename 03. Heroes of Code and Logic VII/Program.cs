using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace _03._Heroes_of_Code_and_Logic_VII
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Hero> hero = new List<Hero>();
            int n = int.Parse(Console.ReadLine());
            int maxHp = 100;
            int maxMp = 200;

            for (int i = 0; i < n; i++)
            {
                string[] addHero = Console.ReadLine().Split(" ");
                string heroName = addHero[0];
                int Hp = int.Parse(addHero[1]);
                int Mp = int.Parse(addHero[2]);
                Hero newHero = new Hero(heroName, Mp, Hp);
                hero.Add(newHero);
            }
            string[] commands = Console.ReadLine().Split(" - ");

            while (commands[0] != "End")
            {
                StringBuilder sb = new StringBuilder();
                int index = hero.FindIndex(x => x.HeroName == commands[1]);

                switch (commands[0])
                {
                    case "CastSpell":

                        int castMana = int.Parse(commands[2]);
                        string spellName = commands[3];

                        if (hero[index].Mana >= castMana)
                        {
                            hero[index].Mana -= castMana;
                            sb.Append($"{hero[index].HeroName} has successfully cast {spellName} and now has {hero[index].Mana} MP!");
                        }
                        else
                        {
                            sb.Append($"{hero[index].HeroName} does not have enough MP to cast {spellName}!");

                        }
                        break;

                    case "TakeDamage":

                        int damage = int.Parse(commands[2]);
                        string attacker = commands[3];
                        hero[index].Hp -= damage;

                        if (hero[index].Hp > 0)
                        {
                            sb.Append($"{hero[index].HeroName} was hit for {damage} HP by {attacker} and now has {hero[index].Hp} HP left!");
                        }

                        else if (hero[index].Hp <= 0)
                        {
                            sb.Append($"{hero[index].HeroName} has been killed by {attacker}!");
                            hero.Remove(hero[index]);
                        }
                        break;

                    case "Recharge":
                        int rechargeMp = int.Parse(commands[2]) + hero[index].Mana;
                        int addMp = maxMp - hero[index].Mana;
                        if (rechargeMp > maxMp)
                        {
                            sb.Append($"{hero[index].HeroName} recharged for {addMp} MP!");
                            hero[index].Mana = maxMp;
                        }
                        else
                        {
                            sb.Append($"{hero[index].HeroName} recharged for {commands[2]} MP!");
                            hero[index].Mana += int.Parse(commands[2]);
                        }
                        break;

                    case "Heal":
                        int rechargeHeal = int.Parse(commands[2]) + hero[index].Hp;
                        int addHp = maxHp - hero[index].Hp;

                        if (rechargeHeal > maxHp)
                        {
                            sb.Append($"{hero[index].HeroName} healed for {addHp} HP!");
                            hero[index].Hp = maxHp;
                        }
                        else
                        {
                            sb.Append($"{hero[index].HeroName} healed for {commands[2]} HP!");
                            hero[index].Hp += int.Parse(commands[2]);
                        }
                        break;
                }


                Console.WriteLine(sb);
                commands = Console.ReadLine().Split(" - ");
            }

            hero = hero.OrderByDescending(hp => hp.Hp).ThenBy(h => h.HeroName).ToList();

            Console.WriteLine(string.Join(Environment.NewLine, hero));
        }
    }
    class Hero
    {
        public Hero(string heroName, int mana, int hp)
        {
            HeroName = heroName;
            Mana = mana;
            Hp = hp;
        }

        public string HeroName { get; set; }
        public int Mana { get; set; }
        public int Hp { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(HeroName);
            sb.AppendLine($"  HP: {Hp}");
            sb.AppendLine($"  MP: {Mana}");

            return sb.ToString().TrimEnd();
        }
    }
}
