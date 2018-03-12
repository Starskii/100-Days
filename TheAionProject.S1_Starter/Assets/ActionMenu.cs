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

        public static Menu MainMenu = new Menu()
        {
            MenuName = "MainMenu",
            MenuTitle = "Main Menu",
            MenuChoices = new Dictionary<char, PlayerAction>()
                {
                    { '1', PlayerAction.PlayerInfo },
                    {'2', PlayerAction.EditPlayer },
                    {'3', PlayerAction.Travel },
                    { '9', PlayerAction.Exit }
                },
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
    }
}
        
    
