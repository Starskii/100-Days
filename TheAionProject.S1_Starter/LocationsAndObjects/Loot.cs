﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheZlandProject.LocationsAndObjects
{
    class Loot : GameObject
    {
        private int _cashValue;

        public int CashValue
        {
            get { return _cashValue; }
            set { _cashValue = value; }
        }

    }
}
