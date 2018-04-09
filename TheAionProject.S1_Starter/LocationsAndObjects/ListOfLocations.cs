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
                    Description = "A gust of wind carries dirt ominously across the landscape \n" +
                                  "You hear a groan in the distance, even in the most desolate\n" +
                                  "of landscapes there is no escape from the menace that is   \n" +
                                  "the Undead. ",
                },

                new GameLocation
                {
                    Location = Area.Hope,
                    IsAccessible = true,
                    Description = "A sign hangs on the outer wall of what used to be 'The City of Hope' \n" +
                                  "The City was founded when the dead started turning, at first it was a\n" + 
                                  "source of refuge during a dark and troubling time. \n" +
                                  "\n\t However, the only souls it offers refuge now are the damned.",

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
