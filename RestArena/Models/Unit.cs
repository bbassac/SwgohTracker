using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestArena.Models
{
    public class Unit
    {
        public String Name { get; set; }
        public String BaseId { get; set; }
        public String Url { get; set; }
        public String SwgohId { get; set; }
        public String Stars { get; set; }
        public String Gear { get; set; }
        public String Level { get; set; }
        public String Gp { get; set; }
        public int Zetas { get; set; }
        public String Health { get; set; }
        public String Speed { get; set; }
        public String PhysicalDamage { get; set; }
        public String CriticalChance { get; set; }
        public String CriticalDamage { get; set; }
        public String Potency { get; set; }
        public String Tenacity { get; set; }
        public String HealSteal { get; set; }
        public String Protection { get; set; }
        public int Relic { get; set; }
        public List<String> Categories { get; set; }
        public String Alignment { get; set; }
        public String Type { get; set; }
        public String ShipBaseId { get; set; }
        public String ShipName { get; set; }

        public enum UnitType
        {
          CHAR,SHIP
        }
    }
}
