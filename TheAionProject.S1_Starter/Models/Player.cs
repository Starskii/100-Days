using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheZlandProject.LocationsAndObjects;

namespace TheAionProject
{
    /// <summary>
    /// the character class the player uses in the game
    /// </summary>
    public class Player : Character , TheZlandProject.Models.IBattle
    {
        public int AttackValue { get; set; }
        public int HealthValue { get; set; }
        public int MaxHealthValue { get; set;
        }
        #region ENUMERABLES

        public enum PersonalityType
        {
            None,
            Charasmatic,
            Intimidating,
        }

        #endregion

        #region FIELDS
        private string _homeTown;
        private bool isAlive;
        private List<TheZlandProject.GameObject> _inventory;
        private PersonalityType _personality;
        private int _wallet;
        private int _experience;
        private int _level;



        #endregion


        #region PROPERTIES
        public int Level
        {
            get { return _level; }
            set { _level = value; }
        }
        public int Experience
        {
            get { return _experience; }
            set { _experience = value; }
        }
        public List<TheZlandProject.GameObject> Inventory
        {
            get { return _inventory; }
            set { _inventory = value; }
        }

        public string HomeTown
        {
            get { return _homeTown; }
            set { _homeTown = value; }
        }

        public bool IsAlive
        {
            get { return isAlive; }
            set { isAlive = value; }
        }

        public PersonalityType Personality
        {
            get { return _personality; }
            set { _personality = value; }
        }
        public int Wallet
        {
            get { return _wallet; }
            set { _wallet = value; }
        }


        #endregion


        #region CONSTRUCTORS

        public Player()
        {

        }

        public Player(string name, ClassType characterClass, int spaceTimeLocationID) : base(name, characterClass, spaceTimeLocationID)
        {

        }

        #endregion


        #region METHODS

        public override string Greeting()
        {
            return base.Greeting() + "I am from " + HomeTown;
        }

        public static bool CheckPlayer() //Will be used to check if player died in combat using the health total.
        {
            bool isAlive = true;
            return isAlive;
        }
        #endregion
    }
}
