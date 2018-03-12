using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheZlandProject.Models;

namespace TheZlandProject.LocationsAndObjects
{
    class ListOfLocations
    {
        public List<GameLocation> IntitializeGameLocationList()
        {

            List<GameLocation> ListOfLocations = new List<GameLocation>()
            {
                new GameLocation
                {
                    Location = Area.Desert,
                    IsAccessible = true,
                    Description = "A hellish desert"                    
                },

                new GameLocation
                {
                    Location = Area.Hope,
                    IsAccessible = true,
                    Description = "The city of Hope"
                },

                new GameLocation
                {
                    Location = Area.Sanctuary,
                    IsAccessible = true,
                    Description = "You are in the Sanctuary. The hungry beg for food as you stroll past them." +
                                  "\nWhat are you going to do?",
        },

                new GameLocation
                {
                    Location = Area.TC,
                    IsAccessible = true,
                    Description = "Traverse City",
                }
            };

            return ListOfLocations;
        }
    }
}
