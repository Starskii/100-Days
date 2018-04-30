using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheZlandProject.LocationsAndObjects;
using TheZlandProject.Models;

namespace TheAionProject
{
    /// <summary>
    /// class to store static and to generate dynamic text for the message and input boxes
    /// </summary>
    public static class Text
    {
        public static List<string> HeaderText = new List<string>() { "Zland 100" };
        public static List<string> FooterText = new List<string>() { "Starskii Gamer Productions" };

        #region INTITIAL GAME SETUP

        public static string CharacterCreation()
        {
            string messageBoxText =
                "\t100 days have passed since the zombie apocolypse has started. You and a few " +
                "survivors from your hometown have\nbanded together to create what you call" +
                " The Sanctuary.\n" +

                "\t Unfortunately though, everything is not fluffy kittens and rainbows. Food " +
                " becomes more scarce by the day and \nas a leader amongst your rag-tag group of" +
                " survivors you need to venture out, and improve the living of your people." +
                "\n"+
                "\n\n \t So, who are you?";

            return messageBoxText;
        }

        public static string ClosingScreen()
        {
            string messageBoxText = "Thank you for playing my game!";
            return messageBoxText;
        }

        public static string CurrrentLocationInfo(Character player)
        {
            ListOfLocations stuff = new ListOfLocations();
            string messageBoxText = "";
            foreach (GameLocation item in stuff.IntitializeGameLocationList())
            {

                if (player.LocationValue == item.Location)
                { messageBoxText = item.Description; }
            }

            return messageBoxText;
        }

        #region Initialize Mission Text

        public static string InitializeMissionIntro()
        {
            string messageBoxText =
                "Before you can venture out, we need to know who you are.\n" +
                " \n" +
                " \n" +
                "\tPress any key to begin.";

            return messageBoxText;
        }

        public static string InitializeMissionGetPlayerName()
        {
            string messageBoxText =
                "Enter your name.\n" +
                " \n";

            return messageBoxText;
        }

        public static string InitializeMissionGetPlayerAge(string name)
        {
            string messageBoxText =
                $"Very good then, we will call you {name}.\n" +
                " \n" +
                "Enter your age below.\n" +
                " \n";

            return messageBoxText;
        }

        public static string InitializeCharacterGetPlayerHomeTown(string name)
        {
            string messageBoxText =
                "What is your hometown?";
            return messageBoxText;
        }

        public static string InitializeMissionGetPlayerClass(Player player)
        {
            string messageBoxText =
                $"{player.Name}, Are you a Leader (better at speech), a Mercenary (better at combat) or a Scavenger (better loot)?\n" +
                " \n" +
                "Enter your class below.\n";

            string raceList = null;

            foreach (Character.ClassType characterClass in Enum.GetValues(typeof(Character.ClassType)))
            {
                if (characterClass != Character.ClassType.None)
                {
                    raceList += $"\t{characterClass}\n";
                }
            }
             //
            messageBoxText += raceList;

            return messageBoxText;
        }

        public static string InitializeMissionEchoPlayerInfo(Player player)
        {
            string messageBoxText =
                $"Very good then {player.Name}.\n" +
                " \n" +
                "It appears we have all the necessary data to begin your adventure. You will find it" +
                " listed below.\n" +
                " \n" +
                $"\tPlayer Name: {player.Name}\n" +
                $"\tPlayer Age: {player.Age}\n" +
                $"\tPlayer Class: {player.Class}\n" +
                $"\tPlayer HomeTown: {player.HomeTown}" +
                " \n" +
                "Press any key to begin your adventure.";

            return messageBoxText;
        }

        #endregion

        #endregion

        #region MAIN MENU ACTION SCREENS

        public static string TravelerInfo(Player gameTraveler)
        {
            string messageBoxText =
                $"\tPlayer Name: {gameTraveler.Name}\n" +
                $"\tPlayer Age: {gameTraveler.Age}\n" +
                $"\tPlayer Race: {gameTraveler.Class}\n" +
                $"\tPlayer HomeTown: {gameTraveler.HomeTown}" +
                " \n";

            return messageBoxText;
        }

        #endregion

        public static List<string> StatusBox(Player player)
        {
            List<string> statusBoxText = new List<string>();

            statusBoxText.Add($"Player's Age: {player.Age}\n");
            statusBoxText.Add($"Player's Experience Points: {player.Experience} \n");
            statusBoxText.Add($"Player's Money: {player.Wallet} \n");
            statusBoxText.Add($"Player's Health: {player.HealthValue} / {player.MaxHealthValue}");
            return statusBoxText;
        }
    }
}
