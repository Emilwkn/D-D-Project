using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDag
{
    class Boss
    {
        public string Name { get; set; } = "Boss";
        public double HP { get; set; } = 0;
        public double AtkMin { get; set; } = 0;
        public double AtkMax { get; set; } = 0;
        public double Evade { get; set; } = 0;
        public double SP { get; set; } = 0;
        public double EXP { get; set; } = 0;


        Random rnd = new Random();

        public Boss(string name = "Boss",
            double hp = 0,
            double atkmin = 0,
            double atkmax =0,
            double evade = 0,
            double sp = 0,
            double exp = 0)
        {
            Name = name;
            HP = hp;
            AtkMin = atkmin;
            AtkMax = atkmax;
            Evade = evade;
            SP = sp;
            EXP = exp;
        }

        public double Attack()
        {
            return rnd.Next((int)AtkMin, (int)AtkMax);
        }
    }
}
