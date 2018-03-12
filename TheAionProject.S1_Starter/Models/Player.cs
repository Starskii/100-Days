using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheAionProject
{
    /// <summary>
    /// the character class the player uses in the game
    /// </summary>
    public class Player : Character
    {
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
        private PersonalityType _personality;
        #endregion


        #region PROPERTIES
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

        public static bool PlayerIsAlive() //Will be used to check if player died in combat using the health total.
        {
            bool isAlive = true;
            return isAlive;
        }

        #endregion
    }
}
