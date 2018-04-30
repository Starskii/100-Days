using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheAionProject
{
    /// <summary>
    /// static class to hold key/value pairs for menu options
    /// </summary>
    public static class ActionMenu
    {
        public static Menu MissionIntro = new Menu()
        {
            MenuName = "MissionIntro",
            MenuTitle = "",
            MenuChoices = new Dictionary<char, PlayerAction>()
                    {
                        { ' ', PlayerAction.None }
                    },
        };

        public static Menu InitializeMission = new Menu()
        {
            MenuName = "InitializeMission",
            MenuTitle = "Initialize Mission",
            MenuChoices = new Dictionary<char, PlayerAction>()
                {
                    { '1', PlayerAction.Exit }
                },
        };

        public static Menu ReturnOnly = new Menu()
        {
            MenuName = "ReturnMenu",
            MenuTitle = "Display Data",
            MenuChoices = new Dictionary<char, PlayerAction>()
            {
                {'1', PlayerAction.Return }
            }
        };

        public static Menu LookAround = new Menu()
        {
            MenuName = "LookAround",
            MenuTitle = "Look Around",
            MenuChoices = new Dictionary<char, PlayerAction>()
            {
                { '1', PlayerAction.PickUpItem},
                { '2', PlayerAction.PutDownItem},
                {'3', PlayerAction.LookAt },
                { '7', PlayerAction.Return}
            }
        };

        public static Menu MainMenu = new Menu()
        {
            MenuName = "MainMenu",
            MenuTitle = "Main Menu",
            MenuChoices = new Dictionary<char, PlayerAction>()
                {

                    {'1', PlayerAction.Act },
                    {'2', PlayerAction.Options },
                    {'7', PlayerAction.AdminMenu },
                    { '9', PlayerAction.Exit }
                },
        };

        public static Menu OptionMenu = new Menu()
        {
            MenuName = "OptionMenu",
            MenuTitle = "Option Menu",
            MenuChoices = new Dictionary<char, PlayerAction>()
                {

                    {'1', PlayerAction.EditPlayer },
                    {'2', PlayerAction.PlayerInfo },
                    {'7', PlayerAction.Return }
                },
        };

        public static Menu Act = new Menu()
        {
            MenuName = "Act",
            MenuTitle = "Act",
            MenuChoices = new Dictionary<char, PlayerAction>()
            {
                {'1', PlayerAction.LookAround },
                {'2', PlayerAction.TalkTo },
                {'3', PlayerAction.Travel },
                {'4', PlayerAction.DisplayPlayerInventory },
                {'7', PlayerAction.Return }
            }
        };

        public static Menu EditPlayer = new Menu()
        {
            MenuName = "EditPlayer",
            MenuTitle = "Edit Player",
            MenuChoices = new Dictionary<char, PlayerAction>()
            {
                {'4', PlayerAction.EditName},
                {'5', PlayerAction.EditAge},
                {'6', PlayerAction.EditHomeTown},
                {'7', PlayerAction.Return}
            },
        };

        public static Menu PlayerInformation = new Menu()
        {
            MenuName = "PlayerInformation",
            MenuTitle = "Player Information",
            MenuChoices = new Dictionary<char, PlayerAction>()
            {
                {'2', PlayerAction.EditPlayer },
                {'7', PlayerAction.Return }
            },
        };

        public static Menu Shop = new Menu()
        {
            MenuName = "Shop",
            MenuTitle = "Shop",
            MenuChoices = new Dictionary<char, PlayerAction>()
            {
                {'1', PlayerAction.Trade },
                {'2', PlayerAction.Heal },
                {'7', PlayerAction.Return }
            },
        };

        public static Menu AdminMenu = new Menu()
        {
            MenuName = "Admin",
            MenuTitle = "Admin",
            MenuChoices = new Dictionary<char, PlayerAction>()
            {
                {'1', PlayerAction.DisplayAllObjects },
                {'2', PlayerAction.DisplayAllLocations },
                {'3', PlayerAction.DisplayLocationsVisited },
                {'4', PlayerAction.DisplayAllNPC },
                {'7', PlayerAction.Return }
            },
        };
    }
}
        
    
