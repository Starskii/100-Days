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

            //
            // initialize the mission traveler
            // 
            InitializeMission();
            List<GameLocation> _listOfLocation = new List<GameLocation>();
            ListOfLocations Instantiate = new ListOfLocations();
            _listOfLocation = Instantiate.IntitializeGameLocationList();
            List<TheZlandProject.GameObject> listOfAllGameObjects = new List<TheZlandProject.GameObject>();
            listOfAllGameObjects = ListOfGameObjects.IntitializeGameObjectList();

            //
            // prepare game play screen
            //
            _gameConsoleView.DisplayGamePlayScreen("Current Location: " + _playerCharacter.LocationValue, Text.CurrrentLocationInfo(_playerCharacter), ActionMenu.MainMenu, "");

            //
            // game loop
            //

            travelerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.MainMenu);

            while (_playingGame)
            {
                //
                // get next game action from player
               

                //
                // choose an action based on the player's menu choice
                //
                switch (travelerActionChoice)
                {
                    case PlayerAction.None:
                        travelerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.MainMenu);
                        break;

                    case PlayerAction.Travel:
                        _playerCharacter = _gameConsoleView.DisplayTravelMenu(_playerCharacter, _listOfLocation);
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

                    case PlayerAction.PickUpItem:
                        _playerCharacter = _gameConsoleView.PickUpItem(_playerCharacter, listOfAllGameObjects);
                        travelerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.LookAround);

                        break;

                    case PlayerAction.PutDownItem:
                        _playerCharacter = _gameConsoleView.PutDownItem(_playerCharacter, listOfAllGameObjects);
                        travelerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.LookAround);
                        break;

                    case PlayerAction.DisplayAllObjects:
                        _gameConsoleView.DisplayAllGameObjects(listOfAllGameObjects);
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
            Player player = _gameConsoleView.GetInitialTravelerInfo();

            _playerCharacter.Name = player.Name;
            _playerCharacter.Age = player.Age;
            _playerCharacter.Class = player.Class;
            _playerCharacter.HomeTown = player.HomeTown;
            _playerCharacter.LocationValue = TheZlandProject.Models.Area.Sanctuary;
        }

        #endregion
    }
}
