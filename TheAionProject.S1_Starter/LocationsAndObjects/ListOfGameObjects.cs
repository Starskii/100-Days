using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheZlandProject.Models;

namespace TheZlandProject.LocationsAndObjects
{
    class ListOfGameObjects
    {
        public static List<GameObject> IntitializeGameObjectList()
        {

            List<GameObject> ListOfGameObject = new List<GameObject>()
            {
                new Weapon
                {
                    Name = "The Decapulator",
                    AttackValue = 100,
                    Location = Area.Sanctuary,
                    IsInInventory = false,
                    ID = 1,

                },
                new Loot
                {
                    Name = "Zombie Guys",
                    CashValue =  100,
                    Location = Area.Sanctuary,
                    IsInInventory = false,
                    ID = 2
                },
            };

            return ListOfGameObject;
        }
    }
}
