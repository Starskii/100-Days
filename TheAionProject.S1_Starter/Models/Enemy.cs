using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheZlandProject.Models
{
    class Enemy : IBattle
    {
       public int AttackValue {get; set;}
        public int HealthValue { get; set; }
        public int MaxHealthValue { get; set; }

    }
}
