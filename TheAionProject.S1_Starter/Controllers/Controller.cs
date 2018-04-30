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
    /// controller for the MVC pattern in the application
    /// </summary>
    public class Controller
    {
        #region FIELDS

        private ConsoleView _gameConsoleView;
        private Player _playerCharacter;
        private bool _playingGame;

        #endregion

        #region PROPERTIES


        #endregion

        #region CONSTRUCTORS

        public Controller()
        {
            //
            // setup all of the objects in the game
            //
            InitializeGame();

            //
            // begins running the application UI
            //
            ManageGameLoop();
        }

        #endregion

        #region METHODS

        /// <summary>
        /// initialize the major game objects
        /// </summary>
        private void InitializeGame()
        {
            _playerCharacter = new Player();
            _gameConsoleView = new ConsoleView(_playerCharacter);
            _playingGame = true;

            Console.CursorVisible = false;
        }

        /// <summary>
        /// method to manage the application setup and game loop
        /// </summary>
        private void ManageGameLoop()
        {
            PlayerAction travelerActionChoice = PlayerAction.None;

            //
            // display splash screen
            //
            _playingGame = _gameConsoleView.DisplaySplashScreen();

            //
            // player chooses to quit
            //
            if (!_playingGame)
            {
                Environment.Exit(1);
            }

            //
            // display introductory message
            //

            _gameConsoleView.DisplayGamePlayScreen("Game Introduction", Text.CharacterCreation(), ActionMenu.MissionIntro, "");
            _gameConsoleView.GetContinueKey();
            _playerCharacter.LocationValue = TheZlandProject.Models.Area.Sanctuary;
            _playerCharacter.HealthValue = 10;
            _playerCharacter.MaxHealthValue = 10;
            _playerCharacter.AttackValue = 2;

            //
            // initialize the mission traveler
            // 
            InitializeMission();
            List<GameLocation> _listOfLocation = new List<GameLocation>();
            ListOfLocations Instantiate = new ListOfLocations();
            List<Character> ListOfNPC = ListOfAllNPC.InstantiateNPCLIst();
            _listOfLocation = Instantiate.IntitializeGameLocationList();
            List<TheZlandProject.GameObject> listOfAllGameObjects = new List<TheZlandProject.GameObject>();
            listOfAllGameObjects = ListOfGameObjects.IntitializeGameObjectList();
            _playerCharacter.Inventory = listOfAllGameObjects;
            List<Area> ListOfPlacesVisited = new List<Area>();

            //
            // prepare game play screen
            //
            _gameConsoleView.DisplayGamePlayScreen("Current Location: " + _playerCharacter.LocationValue, Text.CurrrentLocationInfo(_playerCharacter), ActionMenu.MainMenu, "");

            //
            // game loop
            //

            travelerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.MainMenu);

            Random playerRandomEncounter = new Random();

            while (_playingGame)
            {
                //
                // get next game action from player
                int randomBattle = 0;
                randomBattle = playerRandomEncounter.Next(1, 101);
                int probOfEncounter = 90;
                //
                // choose an action based on the player's menu choice
                //
                switch (travelerActionChoice)
                {
                    case PlayerAction.None:
                        travelerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.MainMenu);
                        break;

                    case PlayerAction.Heal:
                        _gameConsoleView.Heal(_playerCharacter);
                        travelerActionChoice = PlayerAction.Return;
                        break;

                    case PlayerAction.Act:
                        _gameConsoleView.DisplayGamePlayScreen("Current Location: " + _playerCharacter.LocationValue, Text.CurrrentLocationInfo(_playerCharacter), ActionMenu.Act, "");
                        travelerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.Act);
                        break;

                    case PlayerAction.Options:
                        _gameConsoleView.DisplayGamePlayScreen("Current Location: " + _playerCharacter.LocationValue, Text.CurrrentLocationInfo(_playerCharacter), ActionMenu.OptionMenu, "");
                        travelerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.OptionMenu);
                        break;

                    case PlayerAction.Travel:
                        if (randomBattle >= probOfEncounter)
                        {
                            _gameConsoleView.Battle(_playerCharacter);
                            travelerActionChoice = PlayerAction.Return;
                        }
                        else
                        {
                            _playerCharacter = _gameConsoleView.DisplayTravelMenu(_playerCharacter, _listOfLocation, ListOfPlacesVisited, listOfAllGameObjects);
                            travelerActionChoice = PlayerAction.Return;
                        }
                        break;

                    case PlayerAction.TalkTo:
                        _gameConsoleView.DisplayTalkTo(_playerCharacter, ListOfNPC);
                        travelerActionChoice = PlayerAction.Return;
                        break;

                    case PlayerAction.PlayerInfo:
                        _gameConsoleView.DisplayPlayerInformation();
                        travelerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.PlayerInformation);
                        break;

                    case PlayerAction.EditPlayer:
                        _playerCharacter = _gameConsoleView.DisplayEditPlayer(_playerCharacter);
                        travelerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.MainMenu);
                        break;

                    case PlayerAction.LookAround:
                        _playerCharacter = _gameConsoleView.LookAround(_playerCharacter, listOfAllGameObjects);
                        travelerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.LookAround);
                        break;

                    case PlayerAction.LookAt:
                        _gameConsoleView.LookAt(_playerCharacter, listOfAllGameObjects);
                        travelerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.ReturnOnly);
                        break;

                    case PlayerAction.PickUpItem:
                        _playerCharacter = _gameConsoleView.PickUpItem(_playerCharacter, listOfAllGameObjects);
                        travelerActionChoice = PlayerAction.Return;
                        break;

                    case PlayerAction.PutDownItem:
                        _playerCharacter = _gameConsoleView.PutDownItem(_playerCharacter, listOfAllGameObjects);
                        travelerActionChoice = PlayerAction.Return;
                        break;

                    case PlayerAction.AdminMenu:
                        _gameConsoleView.DisplayAdminMenu();
                        travelerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.AdminMenu);
                        break;

                    case PlayerAction.DisplayAllObjects:
                        _gameConsoleView.DisplayAllGameObjects(listOfAllGameObjects);
                        travelerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.ReturnOnly);
                        break;

                    case PlayerAction.DisplayAllNPC:
                        _gameConsoleView.DisplayAllNPC(ListOfNPC);
                        travelerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.ReturnOnly);
                        break;

                    case PlayerAction.DisplayPlayerInventory:
                        _gameConsoleView.DisplayPlayerInventory(_playerCharacter);
                        travelerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.ReturnOnly);
                        break;

                    case PlayerAction.DisplayLocationsVisited:
                        _gameConsoleView.DisplayAllPlacesVisited(ListOfPlacesVisited);
                        travelerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.ReturnOnly);
                        break;

                    case PlayerAction.DisplayAllLocations:
                        _gameConsoleView.DisplayAllLocations(_listOfLocation);
                        travelerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.ReturnOnly);
                        break;

                    case PlayerAction.Return:
                        _gameConsoleView.DisplayCurrentLocation(_playerCharacter);
                        travelerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.MainMenu);
                        break;

                    case PlayerAction.Exit:
                        _playingGame = false;
                        break;

                    default:
                        break;
                }
            }

            //
            // close the application
            //
            _gameConsoleView.DisplayClosingScreen();            
            Environment.Exit(1);
        }

        /// <summary>
        /// initialize the player info
        /// </summary>
        private void InitializeMission()
        {
            Player player = _gameConsoleView.GetInitialPlayerInfo();

            _playerCharacter.Name = player.Name;
            _playerCharacter.Age = player.Age;
            _playerCharacter.Class = player.Class;
            _playerCharacter.HomeTown = player.HomeTown;
            _playerCharacter.LocationValue = TheZlandProject.Models.Area.Sanctuary;
        }

        #endregion
    }
}
