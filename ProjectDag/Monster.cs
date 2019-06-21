using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDag
{
    class Monster
    {
        public string Name { get; set; } = "Monster";
        public double HP { get; set; } = 0;
        public double Atk { get; set; } = 0;
        public double Evade { get; set; } = 0;
        public double EXP { get; set; } = 0;


        public Monster(string name = "Monster",
            double hp = 0,
            double atk = 0,
            double evade = 0,
            double exp = 0)
        {
            Name = name;
            HP = hp;
            Atk = atk;
            Evade = evade;
            EXP = exp;
        }
    }
}
