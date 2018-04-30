using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheZlandProject.Models;
using TheAionProject;

namespace TheZlandProject.LocationsAndObjects
{
    class ListOfAllNPC
    {
        public static List<Character> InstantiateNPCLIst()
        {
            List<GameObject> InstantiatedList = new List<GameObject>();
            InstantiatedList = ListOfGameObjects.IntitializeGameObjectList();

            List<Character> ListOfAllMerchants = new List<Character>()
            {
                new Merchant
                {
                    Name = "Merchant John",
                    LocationValue = Area.Sanctuary,
                    Age = 50,
                    Class = Character.ClassType.None,
                    Wallet = 1000,
                    Inventory = InstantiatedList,
                    Description = "This man carries great wisdom and confidence. He seems to be doing fine considering.",
                    Messages = new List<string>
                    {
                        "I'm not sure how safe the Sanctuary is anymore. I'm clearing out my inventory.",
                        "Howdy stranger, how goes it?",
                        "What can I do ya for?"
                    }
                },
                new Merchant
                {
                    Name = "Merchant Jake",
                    LocationValue = Area.Desert,
                    Age = 21,
                    Class = Character.ClassType.None,
                    Wallet = 1000,
                    Inventory = InstantiatedList,
                    Description = "A young man, seemingly drunk. He stumbles and slurs as he offers his bargains.",
                    Messages = new List<string>
                    {
                        "Do I know you?",
                        "Nowhere is safe anymore.",
                        "Do you need food? I've got some to sell."
                    }
                },
                new Merchant
                {
                    Name = "Merchant Rick",
                    LocationValue = Area.Hope,
                    Age = 21,
                    Class = Character.ClassType.None,
                    Wallet = 1000,
                    Inventory = InstantiatedList,
                    Description = "A man with dark hair, a survivor and you can tell by the look on his face.",
                    Messages = new List<string>
                    {
                        "Do I know you?",
                        "Nowhere is safe anymore.",
                        "Do you need food? I've got some to sell."
                    }
                },
                                new Merchant
                {
                    Name = "Merchant Carl",
                    LocationValue = Area.TC,
                    Age = 21,
                    Class = Character.ClassType.None,
                    Wallet = 1000,
                    Inventory = InstantiatedList,
                    Description = "Barely old enough to be in High School, but it seems he's found his true calling as a merchant.",
                    Messages = new List<string>
                    {
                        "Do I know you?",
                        "Nowhere is safe anymore.",
                        "Do you need food? I've got some to sell."
                    }
                },
                new Civilian
                {
                    Name = "Stan",
                    LocationValue = Area.Sanctuary,
                    Age = 15,
                    Class = Character.ClassType.None,
                    Description = "A teenager, obviously disturbed.",
                    Messages = new List<string>
                    {
                        "Screw off.",
                        "It's all over, they're all dead.",
                        "Is there any hope anymore?"
                    }
                },

            };

            return ListOfAllMerchants;

        }
    }
}
