using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheZlandProject.LocationsAndObjects;
using TheZlandProject.Models;

namespace TheAionProject
{
    /// <summary>
    /// view class
    /// </summary>
    public class ConsoleView
    {
        #region ENUMS

        private enum ViewStatus
        {
            TravelerInitialization,
            PlayingGame
        }

        #endregion

        #region FIELDS

        //
        // declare game objects for the ConsoleView object to use
        //
        Player _gameTraveler;

        ViewStatus _viewStatus;

        #endregion

        #region PROPERTIES

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// default constructor to create the console view objects
        /// </summary>
        public ConsoleView(Player gameTraveler)
        {
            _gameTraveler = gameTraveler;

            _viewStatus = ViewStatus.TravelerInitialization;

            InitializeDisplay();
        }

        #endregion

        #region METHODS
        /// <summary>
        /// display all of the elements on the game play screen on the console
        /// </summary>
        /// <param name="messageBoxHeaderText">message box header title</param>
        /// <param name="messageBoxText">message box text</param>
        /// <param name="menu">menu to use</param>
        /// <param name="inputBoxPrompt">input box text</param>
        public void DisplayGamePlayScreen(string messageBoxHeaderText, string messageBoxText, Menu menu, string inputBoxPrompt)
        {
            //
            // reset screen to default window colors
            //
            Console.BackgroundColor = ConsoleTheme.WindowBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.WindowForegroundColor;
            Console.Clear();

            ConsoleWindowHelper.DisplayHeader(Text.HeaderText);
            ConsoleWindowHelper.DisplayFooter(Text.FooterText);

            DisplayMessageBox(messageBoxHeaderText, messageBoxText);
            DisplayMenuBox(menu);
            DisplayInputBox();
            DisplayStatusBox();
        }

        /// <summary>
        /// wait for any keystroke to continue
        /// </summary>
        public void GetContinueKey()
        {
           Console.ReadKey();
        }

        /// <summary>
        /// get a action menu choice from the user
        /// </summary>
        /// <returns>action menu choice</returns>
        public PlayerAction GetActionMenuChoice(Menu menu)
        {
            PlayerAction chosenAction = PlayerAction.None;

            //
            // TODO validate menu choices
            //

            bool allGood = false;

            while (!allGood)
            {

                ConsoleKeyInfo keyPressedInfo = Console.ReadKey();
                char keyPressed = keyPressedInfo.KeyChar;


                    if (menu.MenuChoices.Keys.Contains(keyPressed))
                    {
                        chosenAction = menu.MenuChoices[keyPressed];
                        allGood = true;
                    }
                    else
                    {  }
                }

            return chosenAction;
        }

        /// <summary>
        /// get a string value from the user
        /// </summary>
        /// <returns>string value</returns>
        public string GetString()
        {
            return Console.ReadLine();
        }

        /// <summary>
        /// get an integer value from the user
        /// </summary>
        /// <returns>integer value</returns>
        public bool GetInteger(string prompt, int minimumValue, int maximumValue, out int integerChoice)
        {
            bool validResponse = false;
            integerChoice = 0;

            DisplayInputBoxPrompt(prompt);
            while (!validResponse)
            {
                if (int.TryParse(Console.ReadLine(), out integerChoice))
                {
                    if (integerChoice >= minimumValue && integerChoice <= maximumValue)
                    {
                        validResponse = true;
                    }
                    else
                    {
                        ClearInputBox();
                        DisplayInputErrorMessage($"You must enter an integer value between {minimumValue} and {maximumValue}. Please try again.");
                        DisplayInputBoxPrompt(prompt);
                    }
                }
                else
                {
                    ClearInputBox();
                    DisplayInputErrorMessage($"You must enter an integer value between {minimumValue} and {maximumValue}. Please try again.");
                    DisplayInputBoxPrompt(prompt);
                }
            }

            return true;
        }

        /// <summary>
        /// get a character race value from the user
        /// </summary>
        /// <returns>character race value</returns>
        public Character.ClassType GetClass()
        {
            Character.ClassType raceType;
            Enum.TryParse<Character.ClassType>(Console.ReadLine(), out raceType);

            return raceType;
        }

        public string GetHomeTown()
        {
            string homeTown = Console.ReadLine();
            return homeTown;
        }

        /// <summary>
        /// display splash screen
        /// </summary>
        /// <returns>player chooses to play</returns>
        public bool DisplaySplashScreen()
        {
            bool playing = true;
            ConsoleKeyInfo keyPressed;

            Console.BackgroundColor = ConsoleTheme.SplashScreenBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.SplashScreenForegroundColor;
            Console.Clear();
            Console.CursorVisible = false;


            Console.SetCursorPosition(0, 10);
            string tabSpace = new String(' ', 35);
            Console.WriteLine(tabSpace + @"__________.__        100 Days       .___");
            Console.WriteLine(tabSpace + @"\____    /|  |  _____     ____    __| _/");
            Console.WriteLine(tabSpace + @"  /     / |  |  \__  \   /    \  / __ | ");
            Console.WriteLine(tabSpace + @" /     /_ |  |__ / __ \_|   |  \/ /_/ | ");
            Console.WriteLine(tabSpace + @"/_______ \|____/(____  /|___|  /\____ | ");
            Console.WriteLine(tabSpace + @"        \/           \/      \/      \/ ");




            Console.SetCursorPosition(80, 25);
            Console.Write("Press any key to continue or Esc to exit.");
            keyPressed = Console.ReadKey();
            if (keyPressed.Key == ConsoleKey.Escape)
            {
                playing = false;
            }

            return playing;
        }

        /// <summary>
        /// initialize the console window settings
        /// </summary>
        private static void InitializeDisplay()
        {
            //
            // control the console window properties
            //
            ConsoleWindowControl.DisableResize();
            ConsoleWindowControl.DisableMaximize();
            ConsoleWindowControl.DisableMinimize();
            Console.Title = "100 Days";

            //
            // set the default console window values
            //
            ConsoleWindowHelper.InitializeConsoleWindow();

            Console.CursorVisible = false;
        }

        /// <summary>
        /// display the correct menu in the menu box of the game screen
        /// </summary>
        /// <param name="menu">menu for current game state</param>
        private void DisplayMenuBox(Menu menu)
        {
            Console.BackgroundColor = ConsoleTheme.MenuBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.MenuBorderColor;

            //
            // display menu box border
            //
            ConsoleWindowHelper.DisplayBoxOutline(
                ConsoleLayout.MenuBoxPositionTop,
                ConsoleLayout.MenuBoxPositionLeft,
                ConsoleLayout.MenuBoxWidth,
                ConsoleLayout.MenuBoxHeight);

            //
            // display menu box header
            //
            Console.BackgroundColor = ConsoleTheme.MenuBorderColor;
            Console.ForegroundColor = ConsoleTheme.MenuForegroundColor;
            Console.SetCursorPosition(ConsoleLayout.MenuBoxPositionLeft + 2, ConsoleLayout.MenuBoxPositionTop + 1);
            Console.Write(ConsoleWindowHelper.Center(menu.MenuTitle, ConsoleLayout.MenuBoxWidth - 4));

            //
            // display menu choices
            //
            Console.BackgroundColor = ConsoleTheme.MenuBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.MenuForegroundColor;
            int topRow = ConsoleLayout.MenuBoxPositionTop + 3;

            foreach (KeyValuePair<char, PlayerAction> menuChoice in menu.MenuChoices)
            {
                if (menuChoice.Value != PlayerAction.None)
                {
                    string formatedMenuChoice = ConsoleWindowHelper.ToLabelFormat(menuChoice.Value.ToString());
                    Console.SetCursorPosition(ConsoleLayout.MenuBoxPositionLeft + 3, topRow++);
                    Console.Write($"{menuChoice.Key}. {formatedMenuChoice}");
                }
            }
        }

        /// <summary>
        /// display the text in the message box of the game screen
        /// </summary>
        /// <param name="headerText"></param>
        /// <param name="messageText"></param>
        private void DisplayMessageBox(string headerText, string messageText)
        {
            //
            // display the outline for the message box
            //
            Console.BackgroundColor = ConsoleTheme.MessageBoxBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.MessageBoxBorderColor;
            ConsoleWindowHelper.DisplayBoxOutline(
                ConsoleLayout.MessageBoxPositionTop,
                ConsoleLayout.MessageBoxPositionLeft,
                ConsoleLayout.MessageBoxWidth,
                ConsoleLayout.MessageBoxHeight);

            //
            // display message box header
            //
            Console.BackgroundColor = ConsoleTheme.MessageBoxBorderColor;
            Console.ForegroundColor = ConsoleTheme.MessageBoxForegroundColor;
            Console.SetCursorPosition(ConsoleLayout.MessageBoxPositionLeft + 2, ConsoleLayout.MessageBoxPositionTop + 1);
            Console.Write(ConsoleWindowHelper.Center(headerText, ConsoleLayout.MessageBoxWidth - 4));

            //
            // display the text for the message box
            //
            Console.BackgroundColor = ConsoleTheme.MessageBoxBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.MessageBoxForegroundColor;
            List<string> messageTextLines = new List<string>();
            messageTextLines = ConsoleWindowHelper.MessageBoxWordWrap(messageText, ConsoleLayout.MessageBoxWidth - 4);

            int startingRow = ConsoleLayout.MessageBoxPositionTop + 3;
            int endingRow = startingRow + messageTextLines.Count();
            int row = startingRow;
            foreach (string messageTextLine in messageTextLines)
            {
                Console.SetCursorPosition(ConsoleLayout.MessageBoxPositionLeft + 2, row);
                Console.Write(messageTextLine);
                row++;
            }

        }

        /// <summary>
        /// draw the status box on the game screen
        /// </summary>
        public void DisplayStatusBox()
        {
            Console.BackgroundColor = ConsoleTheme.InputBoxBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.InputBoxBorderColor;

            //
            // display the outline for the status box
            //
            ConsoleWindowHelper.DisplayBoxOutline(
                ConsoleLayout.StatusBoxPositionTop,
                ConsoleLayout.StatusBoxPositionLeft,
                ConsoleLayout.StatusBoxWidth,
                ConsoleLayout.StatusBoxHeight);

            //
            // display the text for the status box if playing game
            //
            if (_viewStatus == ViewStatus.PlayingGame)
            {
                //
                // display status box header with title
                //
                Console.BackgroundColor = ConsoleTheme.StatusBoxBorderColor;
                Console.ForegroundColor = ConsoleTheme.StatusBoxForegroundColor;
                Console.SetCursorPosition(ConsoleLayout.StatusBoxPositionLeft + 2, ConsoleLayout.StatusBoxPositionTop + 1);
                Console.Write(ConsoleWindowHelper.Center("Game Stats", ConsoleLayout.StatusBoxWidth - 4));
                Console.BackgroundColor = ConsoleTheme.StatusBoxBackgroundColor;
                Console.ForegroundColor = ConsoleTheme.StatusBoxForegroundColor;

                //
                // display stats
                //
                int startingRow = ConsoleLayout.StatusBoxPositionTop + 3;
                int row = startingRow;
                foreach (string statusTextLine in Text.StatusBox(_gameTraveler))
                {
                    Console.SetCursorPosition(ConsoleLayout.StatusBoxPositionLeft + 3, row);
                    Console.Write(statusTextLine);
                    row++;
                }
            }
            else
            {
                //
                // display status box header without header
                //
                Console.BackgroundColor = ConsoleTheme.StatusBoxBorderColor;
                Console.ForegroundColor = ConsoleTheme.StatusBoxForegroundColor;
                Console.SetCursorPosition(ConsoleLayout.StatusBoxPositionLeft + 2, ConsoleLayout.StatusBoxPositionTop + 1);
                Console.Write(ConsoleWindowHelper.Center("", ConsoleLayout.StatusBoxWidth - 4));
                Console.BackgroundColor = ConsoleTheme.StatusBoxBackgroundColor;
                Console.ForegroundColor = ConsoleTheme.StatusBoxForegroundColor;
            }
        }

        /// <summary>
        /// draw the input box on the game screen
        /// </summary>
        public void DisplayInputBox()
        {
            Console.BackgroundColor = ConsoleTheme.InputBoxBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.InputBoxBorderColor;

            ConsoleWindowHelper.DisplayBoxOutline(
                ConsoleLayout.InputBoxPositionTop,
                ConsoleLayout.InputBoxPositionLeft,
                ConsoleLayout.InputBoxWidth,
                ConsoleLayout.InputBoxHeight);
        }

        /// <summary>
        /// display the prompt in the input box of the game screen
        /// </summary>
        /// <param name="prompt"></param>
        public void DisplayInputBoxPrompt(string prompt)
        {
            Console.SetCursorPosition(ConsoleLayout.InputBoxPositionLeft + 4, ConsoleLayout.InputBoxPositionTop + 1);
            Console.ForegroundColor = ConsoleTheme.InputBoxForegroundColor;
            Console.Write(prompt);
            Console.CursorVisible = true;
        }

        /// <summary>
        /// display the error message in the input box of the game screen
        /// </summary>
        /// <param name="errorMessage">error message text</param>
        public void DisplayInputErrorMessage(string errorMessage)
        {
            Console.SetCursorPosition(ConsoleLayout.InputBoxPositionLeft + 4, ConsoleLayout.InputBoxPositionTop + 2);
            Console.ForegroundColor = ConsoleTheme.InputBoxErrorMessageForegroundColor;
            Console.Write(errorMessage);
            Console.ForegroundColor = ConsoleTheme.InputBoxForegroundColor;
            Console.CursorVisible = true;
        }

        /// <summary>
        /// clear the input box
        /// </summary>
        private void ClearInputBox()
        {
            string backgroundColorString = new String(' ', ConsoleLayout.InputBoxWidth - 4);

            Console.ForegroundColor = ConsoleTheme.InputBoxBackgroundColor;
            for (int row = 1; row < ConsoleLayout.InputBoxHeight - 2; row++)
            {
                Console.SetCursorPosition(ConsoleLayout.InputBoxPositionLeft + 4, ConsoleLayout.InputBoxPositionTop + row);
                DisplayInputBoxPrompt(backgroundColorString);
            }
            Console.ForegroundColor = ConsoleTheme.InputBoxForegroundColor;
        }

        /// <summary>
        /// get the player's initial information at the beginning of the game
        /// </summary>
        /// <returns>traveler object with all properties updated</returns>
        public Player GetInitialTravelerInfo()
        {
            Player player = new Player();

            //
            // intro
            //
            DisplayGamePlayScreen("Character Creation", Text.InitializeMissionIntro(), ActionMenu.MissionIntro, "");
            GetContinueKey();

            //
            // get traveler's name
            //
            DisplayGamePlayScreen("Character Creation - Name", Text.InitializeMissionGetTravelerName(), ActionMenu.MissionIntro, "");
            DisplayInputBoxPrompt("Enter your name: ");
            player.Name = GetString();

            //
            // get traveler's age
            //
            DisplayGamePlayScreen("Character Creation - Age", Text.InitializeMissionGetTravelerAge(player.Name), ActionMenu.MissionIntro, "");
            int gameTravelerAge;

            GetInteger($"Enter your age {player.Name}: ", 0, 1000000, out gameTravelerAge);
            player.Age = gameTravelerAge;

            //
            // get traveler's race
            //
            DisplayGamePlayScreen("Character Creation - Class", Text.InitializeMissionGetTravelerRace(player), ActionMenu.MissionIntro, "");
            DisplayInputBoxPrompt($"Enter your Class {player.Name}: ");
            player.Class = GetClass();

            //
            //get Hometown
            //
            DisplayGamePlayScreen("Character Creation - HomeTown", Text.InitializeCharacterGetPlayerHomeTown(player.Name), ActionMenu.MissionIntro, "");
            DisplayInputBoxPrompt("Enter the name of your hometown " + player.Name + ":");
            player.HomeTown = GetHomeTown();

            //
            // echo the traveler's info
            //
            DisplayGamePlayScreen("Character Creation - Complete", Text.InitializeMissionEchoTravelerInfo(player), ActionMenu.MissionIntro, "");
            GetContinueKey();

            // 
            // change view status to playing game
            //
            _viewStatus = ViewStatus.PlayingGame;

            return player;
        }

        public void DisplayCurrentLocation(Player player)
        {
            DisplayGamePlayScreen("Current Location: " + player.LocationValue, Text.CurrrentLocationInfo(player), ActionMenu.MainMenu, "");
        }

        #region ----- display responses to menu action choices -----

        public void DisplayPlayerInformation()
        {
            DisplayGamePlayScreen("Player Information", Text.TravelerInfo(_gameTraveler), ActionMenu.PlayerInformation, "");
        }

        public void DisplayAllGameObjects(List<TheZlandProject.GameObject> listOfGameObjects)
        {
            DisplayGamePlayScreen("Display All Game Objects: ", DisplayListOfObjects(listOfGameObjects), ActionMenu.ReturnOnly, "");
        }

        public void DisplayAllLocations(List<GameLocation> ListOfLocations)
        {
            string TravelBoxText = "";
            foreach (GameLocation item in ListOfLocations)
            {
                TravelBoxText += (item.Location.ToString() + "\n");
            }
            DisplayGamePlayScreen("All Locations: ", TravelBoxText, ActionMenu.ReturnOnly, "");
        }

        public Player DisplayTravelMenu(Player player, List<GameLocation> places)
        {

            string TravelBoxText = "";
            Area PlayerLocation;

            foreach (GameLocation item in places)
            {
                TravelBoxText += (item.Location.ToString() + "\n");
            }

            bool validResponse = false;

            while (!validResponse)
            {

            DisplayGamePlayScreen("Travel", TravelBoxText, ActionMenu.MainMenu, "");
            DisplayInputBoxPrompt("Where would you like to go? ");


                string userInput = "";
                userInput = GetString();
                if (Enum.TryParse<Area>(userInput, out PlayerLocation))
                {

                    Enum.TryParse<Area>(userInput, out PlayerLocation);
                    player.LocationValue = PlayerLocation;
                    validResponse = true;
                    return player;

                }

                else
                {

                }
            }

            return player;            

        }

        public string DisplayListOfObjectsInArea(Player player, List<TheZlandProject.GameObject> listOfAllGameObjects)
        {
            string messageBox = "";

            List<TheZlandProject.GameObject> listOfGameObjectsInArea = new List<TheZlandProject.GameObject>();


            messageBox += " ~~~~~ Weapons ~~~~~";
            foreach (TheZlandProject.GameObject item in listOfAllGameObjects)
            {
                if (item is Weapon && item.Location == player.LocationValue)
                {
                    messageBox += "\n Name: " + item.Name + "\n Location: " + item.Location + "\n ID: " + item.ID + "\n Is in your inventory: " + item.IsInInventory;
                }
            }

            messageBox += "\n ~~~~~ Loot ~~~~~";
            foreach (TheZlandProject.GameObject item in listOfAllGameObjects)
            {
                if (item is Loot && item.Location == player.LocationValue)
                {
                    messageBox += "\n Name: " + item.Name + "\n Location: " + item.Location + "\n ID: " + item.ID + "\n Is in your inventory: " + item.IsInInventory;
                }

            }

            messageBox += "\n ~~~~~ Story Items ~~~~~";
            foreach (TheZlandProject.GameObject item in listOfAllGameObjects)
            {
                if (item is StoryItem && item.Location == player.LocationValue)
                {
                    messageBox += "\n Name: " + item.Name + "\n Location: " + item.Location + "\n ID: " + item.ID + "\n Is in your inventory: " + item.IsInInventory;
                }
            }

            return messageBox;
        }

        public string DisplayListOfObjects(List<TheZlandProject.GameObject> listOfAllGameObjects)
        {
            string messageBox = "";

            List<TheZlandProject.GameObject> listOfGameObjectsInArea = new List<TheZlandProject.GameObject>();


            messageBox += " ~~~~~ Weapons ~~~~~";
            foreach (TheZlandProject.GameObject item in listOfAllGameObjects)
            {
                if (item is Weapon)
                {
                    messageBox += "\n Name: " + item.Name + "\n Location: " + item.Location + "\n ID: " + item.ID + "\n Is in your inventory: " + item.IsInInventory;
                }
            }

            messageBox += "\n ~~~~~ Loot ~~~~~";
            foreach (TheZlandProject.GameObject item in listOfAllGameObjects)
            {
                if (item is Loot)
                {
                    messageBox += "\n Name: " + item.Name + "\n Location: " + item.Location + "\n ID: " + item.ID + "\n Is in your inventory: " + item.IsInInventory;
                }

            }

            messageBox += "\n ~~~~~ Story Items ~~~~~";
            foreach (TheZlandProject.GameObject item in listOfAllGameObjects)
            {
                if (item is StoryItem)
                {
                    messageBox += "\n Name: " + item.Name + "\n Location: " + item.Location + "\n ID: " + item.ID + "\n Is in your inventory: " + item.IsInInventory;
                }
            }

            return messageBox;
        }

        public Player PutDownItem(Player player, List<TheZlandProject.GameObject> ListOfInGameObjects)
        {
            string playerInput = "";
            List<int> validID = new List<int>();

            foreach (var item in ListOfInGameObjects)
            {
                validID.Add(item.ID);
            }

            bool validChoice = false;

            while (!validChoice)
            {
                DisplayInputBoxPrompt("Enter the ID of the item you would like to put down: ");

                playerInput = Console.ReadLine();

                foreach (var item in validID)
                {
                    if (item.ToString() == playerInput)
                    {
                        validChoice = true;
                    }
                }

            }



            foreach (var item in ListOfInGameObjects)
            {
                if (playerInput == item.ID.ToString())
                {
                    item.IsInInventory = false;
                }
            }

           

            return player;
        }

        public Player PickUpItem(Player player, List<TheZlandProject.GameObject> ListOfInGameObjects)
        {
            string playerInput = "";
            List<int> validID = new List<int>();

            foreach (var item in ListOfInGameObjects)
            {
                validID.Add(item.ID);
            }

            bool validChoice = false;

            while (!validChoice)
            {
                DisplayInputBoxPrompt("Enter the ID of the item you would like to pick up: ");

                playerInput = Console.ReadLine();

                foreach (var item in validID)
                {
                    if (item.ToString() == playerInput)
                    {
                        validChoice = true;
                    }
                }

            }



            foreach (var item in ListOfInGameObjects)
            {
                if (playerInput == item.ID.ToString())
                {
                    item.IsInInventory = true;
                }
            }

            return player;
        }

        public Player LookAround(Player player, List<TheZlandProject.GameObject> ListOfInGameObjects)
        {
            DisplayGamePlayScreen("You look around " + player.LocationValue + ".", DisplayListOfObjectsInArea(player, ListOfInGameObjects), ActionMenu.LookAround, "");

            return player;
        }


        public Player DisplayEditPlayer(Player player)
        {
            DisplayGamePlayScreen("Edit Player Information: ", Text.TravelerInfo(_gameTraveler), ActionMenu.EditPlayer, "");
            
            PlayerAction PropertyToEdit = 0;


                Console.CursorVisible = false;
                PropertyToEdit = GetActionMenuChoice(ActionMenu.EditPlayer);

                switch (PropertyToEdit)
                {
                    case PlayerAction.None:
                        break;
                    case PlayerAction.EditName:
                        DisplayInputBoxPrompt("Enter your Name: ");
                        player.Name = GetString();                    
                        break;
                    case PlayerAction.EditAge:
                        int age = player.Age;
                        GetInteger("Enter your Age: ", 0, 150, out age);
                        player.Age = age;
                        break;
                    case PlayerAction.EditHomeTown:
                        DisplayInputBoxPrompt("Enter your HomeTown: ");
                        player.HomeTown = GetHomeTown();
                        break;
                case PlayerAction.Return:
                    break;
                    default:
                        break;
                }

            DisplayCurrentLocation(player);
            return player;
        }

        public void DisplayClosingScreen()
        {
            Console.Clear();
            Console.Write("\n\n\n\t\t");
            string message = Text.ClosingScreen();
            Console.WriteLine(message);
            GetContinueKey();
        }

        #endregion

        #endregion
    }
}
