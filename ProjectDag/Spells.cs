using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDag
{
    class Spell
    {

        public string Name { get; set; } = "Spell";
        public string Type { get; set; } = "Type";
        public double Cost { get; set; } = 0;
        public double Value { get; set; } = 0;
        public string Description { get; set; } = "Description";


        public Spell(string name = "Spell",
            string type = "Type",
            double cost = 0,
            double value = 0,
            string description = "description")
        {
            Name = name;
            Type = type;
            Cost = cost;
            Value = value;
            Description = description;
        }

    }
}
