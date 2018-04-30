using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheZlandProject;
using TheZlandProject.LocationsAndObjects;
using TheZlandProject.Models;
using System.Media;

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
            PlayerInitialization,
            PlayingGame
        }

        #endregion

        #region FIELDS

        //
        // declare game objects for the ConsoleView object to use
        //
        Player _player;

        ViewStatus _viewStatus;

        #endregion

        #region PROPERTIES

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// default constructor to create the console view objects
        /// </summary>
        public ConsoleView(Player player)
        {
            _player = player;

            _viewStatus = ViewStatus.PlayerInitialization;

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
                { }
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
        /// 

        static void DisplayMainScreen(int lineNumber, ConsoleColor highlighterColor)
        {
            string[] menuStrings = new string[3];

            menuStrings[0] = "  Start New";
            menuStrings[1] = "  Load Old Save";
            menuStrings[2] = "  Exit";

            int currentPrintedLineNumber = -1;

            foreach (string item in menuStrings)
            {
                Console.WriteLine();
                currentPrintedLineNumber++;
                if (currentPrintedLineNumber == lineNumber)
                {
                    Console.Write(" ");
                    Console.ForegroundColor = highlighterColor;
                    Console.Write(item);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(item);
                }
            }
        }
        static int KeyUp(int lineNumber)
        {
            return lineNumber;
        }
        static int KeyDown(int lineNumber)
        {
            return lineNumber;
        }
        public bool DisplaySplashScreen()
        {
            bool playing = true;

            Console.BackgroundColor = ConsoleTheme.SplashScreenBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.SplashScreenForegroundColor;
            Console.Clear();
            Console.CursorVisible = false;


            Console.SetCursorPosition(0, 10);
            string tabSpace = new String(' ', 45);

            ConsoleColor highLighterColor = ConsoleColor.Yellow;

            ConsoleKeyInfo KeyInformation;
            int highlightedLine = 0;
            bool splashScreen = true;
            while (splashScreen)
            {
                if (highlightedLine >= 3)
                    highlightedLine = 0;
                else if (highlightedLine < 0)
                    highlightedLine = 2;


                Console.Clear();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine(tabSpace + @"__________.__        100 Days       .___");
                Console.WriteLine(tabSpace + @"\____    /|  |  _____     ____    __| _/");
                Console.WriteLine(tabSpace + @"  /     / |  |  \__  \   /    \  / __ | ");
                Console.WriteLine(tabSpace + @" /     /_ |  |__ / __ \_|   |  \/ /_/ | ");
                Console.WriteLine(tabSpace + @"/_______ \|____/(____  /|___|  /\____ | ");
                Console.WriteLine(tabSpace + @"        \/           \/      \/      \/ ");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                DisplayMainScreen(highlightedLine, highLighterColor);

                Console.WriteLine("\n\n\t\t Press the space bar to select an option...");
                KeyInformation = Console.ReadKey(true);

                Console.Beep(200,100);

                switch (KeyInformation.KeyChar)
                {
                    case 'W':
                    case 'w':
                        highlightedLine--;
                        highlightedLine = KeyUp(highlightedLine);
                        break;
                    case 'S':
                    case 's':
                        highlightedLine++;
                        highlightedLine = KeyDown(highlightedLine);
                        break;
                    case ' ':
                        if (highlightedLine == 2)
                            Environment.Exit(0);

                        splashScreen = false;
                        break;
                    default:
                        break;
                }

                

            }
                

            Console.SetCursorPosition(80, 25);
            //Console.Write("Press any key to continue or Esc to exit.");

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
                foreach (string statusTextLine in Text.StatusBox(_player))
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
        /// <returns>player object with all properties updated</returns>
        public Player GetInitialPlayerInfo()
        {
            Player player = new Player();

            //
            // intro
            //
            DisplayGamePlayScreen("Character Creation", Text.InitializeMissionIntro(), ActionMenu.MissionIntro, "");
            GetContinueKey();

            //
            // get player's name
            //
            DisplayGamePlayScreen("Character Creation - Name", Text.InitializeMissionGetPlayerName(), ActionMenu.MissionIntro, "");
            DisplayInputBoxPrompt("Enter your name: ");
            player.Name = GetString();

            //
            // get player's age
            //
            DisplayGamePlayScreen("Character Creation - Age", Text.InitializeMissionGetPlayerAge(player.Name), ActionMenu.MissionIntro, "");
            int gamePlayerAge;

            GetInteger($"Enter your age {player.Name}: ", 0, 1000000, out gamePlayerAge);
            player.Age = gamePlayerAge;

            //
            // get player's race
            //
            DisplayGamePlayScreen("Character Creation - Class", Text.InitializeMissionGetPlayerClass(player), ActionMenu.MissionIntro, "");
            DisplayInputBoxPrompt($"Enter your Class {player.Name}: ");
            player.Class = GetClass();

            //
            //get Hometown
            //
            DisplayGamePlayScreen("Character Creation - HomeTown", Text.InitializeCharacterGetPlayerHomeTown(player.Name), ActionMenu.MissionIntro, "");
            DisplayInputBoxPrompt("Enter the name of your hometown " + player.Name + ":");
            player.HomeTown = GetHomeTown();

            //
            // echo the player's info
            //
            DisplayGamePlayScreen("Character Creation - Complete", Text.InitializeMissionEchoPlayerInfo(player), ActionMenu.MissionIntro, "");
            GetContinueKey();

            // 
            // change view status to playing game
            //
            _viewStatus = ViewStatus.PlayingGame;

            return player;
        }

        public void Heal(Player player)
        {
            string TextBox = "";
            if (player.Wallet >= 10)
            {
                player.Wallet -= 10;
                player.HealthValue = player.MaxHealthValue;
                TextBox = "You healed succesfully. \n Press any key to continue.";
            }
            else
            {
                TextBox = "You do not have sufficient funds.\n Press any key to continue.";
            }
            DisplayGamePlayScreen("Heal ", TextBox, ActionMenu.ReturnOnly, "");
            Console.ReadKey();
        }

        public void DisplayCurrentLocation(Player player)
        {
            DisplayGamePlayScreen("Current Location: " + player.LocationValue, Text.CurrrentLocationInfo(player), ActionMenu.MainMenu, "");
        }

        #region ----- display responses to menu action choices -----

        public void DisplayPlayerInformation()
        {
            DisplayGamePlayScreen("Player Information", Text.TravelerInfo(_player), ActionMenu.PlayerInformation, "");
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

        public void DisplayTalkTo(Player player, List<Character> ListOfNPC)
        {
            string TalkToMenuDisplay = "";

            foreach (var item in ListOfNPC)
            {
                if (item.LocationValue == player.LocationValue)
                    TalkToMenuDisplay += "Person: "+ item.Name + "\n";
            }

            bool validResponse = false;
            string playerResponse = "";

            List<string> potentialResponses = new List<string>();

            foreach (var item in ListOfNPC)
            {
                potentialResponses.Add(item.Name);
            }

            while (validResponse == false)
            {
                Console.Clear();
                DisplayGamePlayScreen("Talk To", TalkToMenuDisplay, ActionMenu.MainMenu, "");
                DisplayInputBoxPrompt("Who would you like to talk to? ");
                playerResponse = Console.ReadLine();

                foreach (var item in potentialResponses)
                {
                    if (playerResponse == item)
                        validResponse = true;
                }

                if (validResponse == false)
                {
                    DisplayInputErrorMessage("The NPC you specified does not exist.");
                }
            }

            Merchant talkingToMerchant = new Merchant();
            Civilian talkingToCivilian = new Civilian();
            bool isTalkingToMerchant = false;

            foreach (var item in ListOfNPC)
            {
                if (playerResponse == item.Name && item is Merchant)
                {
                    talkingToMerchant = item as Merchant;
                    isTalkingToMerchant = true;
                }
                else if (playerResponse == item.Name && item is Civilian)
                {
                    talkingToCivilian = item as Civilian;
                }
                else
                {

                }
            }

            string greeting = "";

            if (isTalkingToMerchant == true)
            {
                greeting = "Description: " + talkingToMerchant.Description + "\n\n" + talkingToMerchant.Name + ": " + talkingToMerchant.Speak();
            }
            else
            {
                greeting = "Description: " + talkingToCivilian.Description + "\n\n" + talkingToCivilian.Name + ": " + talkingToCivilian.Speak();
            }

            DisplayGamePlayScreen("Talk To", greeting + "\n\n\t Press any key to continue...", ActionMenu.MainMenu, "");
            Console.ReadKey();

            validResponse = false;
            string userInput = "";

            if (isTalkingToMerchant)
            {
                DisplayGamePlayScreen("Talk To", "Would you like to trade with " + talkingToMerchant.Name + "?", ActionMenu.Shop, "Use 1 for yes 7 for no.");
                PlayerAction choice = new PlayerAction();
                choice = GetActionMenuChoice(ActionMenu.Shop);

                if (choice == PlayerAction.Trade)
                {

                string ListOfItems = "";
                ListOfItems += "Sell to " + talkingToMerchant.Name + ": \n";
                foreach (var item in player.Inventory)
                {
                    if (item.IsInInventory == true && item is Loot)
                    {
                        Loot stuff = item as Loot;
                        ListOfItems += item.Name + ", ID: " + item.ID.ToString() + ", Price: $" + stuff.CashValue + "\n\n";
                    }

                }


                    DisplayGamePlayScreen("Sell", ListOfItems, ActionMenu.MainMenu, "");
                    DisplayInputBoxPrompt("What would you like to trade? (Enter ID): ");
                    userInput = Console.ReadLine();
                    int userChosenID = 0;
                    int.TryParse(userInput, out userChosenID);

                    foreach (var item in player.Inventory)
                    {
                        if (userChosenID == item.ID)
                        {
                            item.IsInInventory = false;
                            Loot stuff = item as Loot;
                            player.Wallet += stuff.CashValue;
                        }
                        else
                        { }
                    }
                }
                else if (choice == PlayerAction.Heal)
                {
                    Heal(player);
                }
            }

        }
              
           public void Battle(Player player)
        {
            Enemy encounteredEnemy = new Enemy();

            encounteredEnemy.AttackValue = 1;
            encounteredEnemy.HealthValue = 10;

            while(player.HealthValue >= 1 && encounteredEnemy.HealthValue >= 1)
            {
                player.HealthValue -= encounteredEnemy.AttackValue;
                encounteredEnemy.HealthValue -= player.AttackValue;
            }

            string TravelBoxText = "";

            bool playerIsAlive;

            if (player.HealthValue >= 1)
            {
                TravelBoxText = "You encountered a band of zombies before you could depart on your travles. \n" +
                                "You managed to defeat the enemy, but not unscathed. \n" +
                                "You health: " + player.HealthValue + ".";
                playerIsAlive = true;
            }
            else
            {
                TravelBoxText = "You were intercepted by a band of the dead, you died in combat.";
                playerIsAlive = false;
            }

            TravelBoxText += "\n Press any Key to Continue...";

            DisplayGamePlayScreen("Random Encounter", TravelBoxText, ActionMenu.MainMenu, "");
            Console.ReadKey();

            if(!playerIsAlive)
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine();
                Console.Beep(150, 100);
                Console.WriteLine("             ;::::;");
                Console.WriteLine("         ;:::::'   :;");
                Console.Beep(152, 100);
                Console.WriteLine("        ;:::::;     ;.");
                Console.WriteLine("       ,:::::'       ;           OOO ");
                Console.WriteLine("       ::::::;       ;          OOOOO ");
                Console.Beep(154, 100);
                Console.WriteLine("       ;:::::;       ;         OOOOOOOO");
                Console.WriteLine("      ,;::::::;     ;'         / OOOOOOO");
                Console.Beep(156, 100);
                Console.WriteLine("    ;:::::::::`. ,,,;.        /  / DOOOOOO");
                Console.WriteLine("  .';:::::::::::::::::;,     /  /     DOOOO");
                Console.Beep(158, 100);
                Console.WriteLine(" ,::::::;::::::;;;;::::;,   /  /        DOOO");
                Console.WriteLine(" `::::::`'::::::;;;::::: ,#/  /          DOOO");
                Console.Beep(159, 100);
                Console.WriteLine(":`:::::::`;::::::;;::: ;::#  /            DOOO");
                Console.WriteLine("::`:::::::`;:::::::: ;::::# /              DOO");
                Console.WriteLine("`:`:::::::`;:::::: ;::::::#/               DOO");
                Console.Beep(160, 100);
                Console.WriteLine(" :::`:::::::`;; ;:::::::::##                OO");
                Console.WriteLine(" ::::`:::::::`;::::::::;:::#                OO");
                Console.WriteLine(" `:::::`::::::::::::;'`:;::#                O");
                Console.Beep(160, 100);
                Console.WriteLine("  `:::::`::::::::;' /  / `:#");
                Console.WriteLine("   ::::::`:::::;'  /  /   `#");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.Beep(160, 2000);
                Console.WriteLine("You perished in combat.");
                Console.Beep(180, 2000);
                Console.WriteLine("\n\n\t We all have to go sometime.");
                Console.Beep(200, 2000);
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("\t\t Press any key to end the game...");
                Console.ReadKey();

                Environment.Exit(0);
            }
        }

        public Player DisplayTravelMenu(Player player, List<GameLocation> places, List<Area> PlacesVisited, List<GameObject> ListOfGameObjects)
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

                bool userHasStoryItem = false;
                int validStoryItemID = 0;

                string userInput = "";
                userInput = GetString();
                if (Enum.TryParse<Area>(userInput, out PlayerLocation))
                {

                    Enum.TryParse<Area>(userInput, out PlayerLocation);

                    switch (PlayerLocation)
                    {
                        case Area.None:
                            validStoryItemID = 0;
                            break;
                        case Area.Sanctuary:
                            userHasStoryItem = true;
                            break;
                        case Area.Hope:
                            validStoryItemID = 301;
                            break;
                        case Area.Desert:
                            validStoryItemID = 300;
                            break;
                        case Area.TC:
                            validStoryItemID = 302;
                            break;
                        default:
                            break;
                    }

                    foreach (var item in player.Inventory)
                    {
                        if (item.ID == validStoryItemID && item.IsInInventory)
                            userHasStoryItem = true;
                    }

                    if (userHasStoryItem)
                    {
                        player.LocationValue = PlayerLocation;
                        validResponse = true;
                        player.Experience += 10;
                        PlacesVisited.Add(PlayerLocation);

                        GameObject placeHolder = new GameObject();

                        foreach (var item in player.Inventory)
                        {
                            if (item.IsInInventory)
                            {
                                item.Location = PlayerLocation;
                                placeHolder = item;
                            

                            foreach (var gameobject in ListOfGameObjects)
                            {
                                if(placeHolder.ID == gameobject.ID)
                                {
                                    gameobject.Location = player.LocationValue;
                                }
                            }
                            }
                        }

                        return player;
                    }
                    else
                    {
                        DisplayInputErrorMessage("The place you are trying to go requires a story item you do not yet posess.");
                        Console.ReadKey();
                        break;
                    }

                }

                else
                {
                    DisplayInputErrorMessage("The location specified does not exist.");
                    Console.ReadKey();
                    break;
                        }
            }

            return player;            

        }

        public bool ValidTravelLocation(Player player, Area playerLocation)
        {

            switch (playerLocation)
            {
                case Area.None:
                    break;
                case Area.Sanctuary:
                    break;
                case Area.Hope:
                    try
                    {
                        foreach (var item in player.Inventory)
                        {
                            if (item.ID == 301)
                                return true;
                        }
                    }
                    catch
                    { return false; }
                    break;
                case Area.Desert:
                    try
                    { 
                    foreach (var item in player.Inventory)
                    {
                        if (item.ID == 300)
                            return true;
                    }
                    }
                    catch
                    { return false; }
                    break;
                case Area.TC:
                    try
                    { 
                    foreach (var item in player.Inventory)
                    {
                        if (item.ID == 302)
                            return true;
                    }
                    }
                    catch
                    { return false; }
                    break;
                default:
                    return false;
            }

            return false;
        }

        public string DisplayListOfObjectsInArea(Player player, List<TheZlandProject.GameObject> listOfAllGameObjects)
        {
            string messageBox = "";

            List<TheZlandProject.GameObject> listOfGameObjectsInArea = listOfAllGameObjects;


            messageBox += " ~~~~~ Weapons ~~~~~";
            foreach (TheZlandProject.GameObject item in listOfAllGameObjects)
            {
                if (item is Weapon && item.Location == player.LocationValue)
                {
                    messageBox += "\n Name: " + item.Name + ", Location: " + item.Location + ", ID: " + item.ID + ", Is in your inventory: " + item.IsInInventory;
                }
            }

            messageBox += "\n ~~~~~ Loot ~~~~~";
            foreach (TheZlandProject.GameObject item in listOfAllGameObjects)
            {
                if (item is Loot && item.Location == player.LocationValue)
                {
                    messageBox += "\n Name: " + item.Name + ", Location: " + item.Location + ", ID: " + item.ID + ", Is in your inventory: " + item.IsInInventory;
                }

            }

            messageBox += "\n ~~~~~ Story Items ~~~~~";
            foreach (TheZlandProject.GameObject item in listOfAllGameObjects)
            {
                if (item is StoryItem && item.Location == player.LocationValue)
                {
                    messageBox += "\n Name: " + item.Name + ", Location: " + item.Location + ", ID: " + item.ID + ", Is in your inventory: " + item.IsInInventory;
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

        public void DisplayPlayerInventory(Player player)
        {
            string messageBox = "";

            foreach (var item in player.Inventory)
            {
                if (item.IsInInventory)
                {
                    messageBox += "Name: " + item.Name + "\n";
                    messageBox += "ID: " + item.ID + "\n";
                }
            }
            DisplayGamePlayScreen("Player Inventory", messageBox, ActionMenu.ReturnOnly, "");
        }
        public void DisplayAllPlacesVisited(List<Area> PlacesVisited)
        {
            string messageBox = "";
            int i = 0;
            foreach (var item in PlacesVisited)
            {
                i++;
                messageBox += i + ": " + item.ToString() + "\n";
            }

            DisplayGamePlayScreen("List of all visited locations in order", messageBox, ActionMenu.ReturnOnly, "");

        }
        public void DisplayAllNPC(List<Character> TheList)
        {
            string textBox = "";

            foreach (var item in TheList)
            {
                textBox += "Name: " + item.Name + "\nLocation: " + item.LocationValue;
            }
            DisplayGamePlayScreen("List of All NPC", textBox, ActionMenu.ReturnOnly, "");
        }

        public void DisplayAdminMenu()
        {
            DisplayGamePlayScreen("Welcome Admin, what can we do for you?", "", ActionMenu.AdminMenu, "");
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

            player.Inventory = ListOfInGameObjects;
            return player;
        }

        public Player LookAround(Player player, List<TheZlandProject.GameObject> ListOfInGameObjects)
        {
            DisplayGamePlayScreen("You look around " + player.LocationValue + ".", DisplayListOfObjectsInArea(player, ListOfInGameObjects), ActionMenu.LookAround, "");

            return player;
        }

        public void LookAt(Player player, List<TheZlandProject.GameObject> ListOfInGameObjects)
        {
            DisplayGamePlayScreen("Look At", DisplayListOfObjectsInArea(player, ListOfInGameObjects), ActionMenu.LookAround, "");
            int ID = 0;
            GetInteger("What (ID) item would you like to look at?", 0, 10000, out ID);

            string messageBox = "";

            foreach (var item in ListOfInGameObjects)
            {
                if(ID == item.ID)
                {
                    messageBox += "Name: " + item.Name + "\nDescription: " + item.Description;
                }
            }
            DisplayGamePlayScreen("Look At", messageBox, ActionMenu.ReturnOnly, "");


        }


        public Player DisplayEditPlayer(Player player)
        {
            DisplayGamePlayScreen("Edit Player Information: ", Text.TravelerInfo(_player), ActionMenu.EditPlayer, "");
            
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
            Console.WriteLine();
            Console.WriteLine();
            Console.Beep(150, 100);
            Console.WriteLine("             ;::::;");
            Console.WriteLine("         ;:::::'   :;");
            Console.Beep(152, 100);
            Console.WriteLine("        ;:::::;     ;.");
            Console.WriteLine("       ,:::::'       ;           OOO ");
            Console.WriteLine("       ::::::;       ;          OOOOO ");
            Console.Beep(154, 100);
            Console.WriteLine("       ;:::::;       ;         OOOOOOOO");
            Console.WriteLine("      ,;::::::;     ;'         / OOOOOOO");
            Console.Beep(156, 100);
            Console.WriteLine("    ;:::::::::`. ,,,;.        /  / DOOOOOO");
            Console.WriteLine("  .';:::::::::::::::::;,     /  /     DOOOO");
            Console.Beep(158, 100);
            Console.WriteLine(" ,::::::;::::::;;;;::::;,   /  /        DOOO");
            Console.WriteLine(" `::::::`'::::::;;;::::: ,#/  /          DOOO");
            Console.Beep(159, 100);
            Console.WriteLine(":`:::::::`;::::::;;::: ;::#  /            DOOO");
            Console.WriteLine("::`:::::::`;:::::::: ;::::# /              DOO");
            Console.WriteLine("`:`:::::::`;:::::: ;::::::#/               DOO");
            Console.Beep(160, 100);
            Console.WriteLine(" :::`:::::::`;; ;:::::::::##                OO");
            Console.WriteLine(" ::::`:::::::`;::::::::;:::#                OO");
            Console.WriteLine(" `:::::`::::::::::::;'`:;::#                O");
            Console.Beep(160, 100);
            Console.WriteLine("  `:::::`::::::::;' /  / `:#");
            Console.WriteLine("   ::::::`:::::;'  /  /   `#");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.Beep(160, 800);
            Console.WriteLine("You decided to disband.");
            Console.Beep(180, 800);
            Console.WriteLine("\n\n\t We all have to go sometime.");
            Console.Beep(200, 800);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("\t\t Press any key to end the game...");
            Console.ReadKey();

            Environment.Exit(0);
        }

        #endregion

        #endregion
    }
}
