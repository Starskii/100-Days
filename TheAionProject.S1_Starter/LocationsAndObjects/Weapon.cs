using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheZlandProject.LocationsAndObjects
{
    class Weapon : GameObject
    {
        private int _attackValue;

        public int AttackValue
        {
            get { return _attackValue; }
            set { _attackValue = value; }
        }

    }
}
