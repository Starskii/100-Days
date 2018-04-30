using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheZlandProject.Models
{
    interface IBattle
    {
        int AttackValue { get; set; }
        int HealthValue { get; set; }
        int MaxHealthValue { get; set; }

    }
}
