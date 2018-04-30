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
                    AttackValue = 5,
                    Location = Area.Sanctuary,
                    IsInInventory = false,
                    ID = 100,
                },
                new Weapon
                {
                    Name = "AR15",
                    AttackValue = 25,
                    Location = Area.Desert,
                    IsInInventory = false,
                    ID = 101,
                },
                new Weapon
                {
                    Name = "Flamethrower",
                    AttackValue = 50,
                    Location = Area.Hope,
                    IsInInventory = false,
                    ID = 102,
                },
                new Weapon
                {
                    Name = "Sword of the Chosen",
                    AttackValue = 100,
                    ID = 103,
                    Location = Area.TC,
                    IsInInventory = false,
                },

                new Loot
                {
                    Name = "Zombie Guts",
                    Description = "Trust me man, you don't want to know.",
                    CashValue =  10,
                    Location = Area.Sanctuary,
                    IsInInventory = false,
                    ID = 200
                },
                new Loot
                {
                    Name = "Gold Coin",
                    CashValue = 100,
                    Location = Area.Desert,
                    IsInInventory = false,
                    ID = 201,
                },
                new Loot
                {
                    Name = "Long Board",
                    CashValue = 60,
                    Location = Area.TC,
                    IsInInventory = false,
                    ID = 202,
                },
                new Loot
                {
                    Name = "A wooden crucifix",
                    CashValue = 5,
                    Location = Area.Hope,
                    IsInInventory = false,
                    ID = 203,
                },

                new StoryItem
                {
                    Name = "Map to the Desert",
                    Location = Area.Sanctuary,
                    ID = 300,
                    IsInInventory = false,
                },
                new StoryItem
                {
                    Name = "Map to Hope City",
                    Location = Area.Desert,
                    ID = 301,
                    IsInInventory = false,
                },
                new StoryItem
                {
                    Name = "Map to Traverse City",
                    Location = Area.Hope,
                    ID = 302,
                    IsInInventory = false,
                },

            };

            return ListOfGameObject;
        }
    }
}
