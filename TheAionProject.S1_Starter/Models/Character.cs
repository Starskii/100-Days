using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheZlandProject.Models;

namespace TheAionProject
{
    /// <summary>
    /// base class for the player and all game characters
    /// </summary>
    public class Character
    {
        #region ENUMERABLES

        public enum ClassType
        {
            None,
            Leader,
            Mercenary,
            Scavenger
        }

        #endregion

        #region FIELDS

        private string _name;
        private Area _locationValue;
        private int _age;
        private ClassType _class;

        #endregion

        #region PROPERTIES

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public Area LocationValue
        {
            get { return _locationValue; }
            set { _locationValue = value; }
        }

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        public ClassType Class
        {
            get { return _class; }
            set { _class = value; }
        }

        #endregion

        #region CONSTRUCTORS

        public Character()
        {

        }

        public Character(string name, ClassType characterClass, int spaceTimeLocationID)
        {
            _name = name;
            _class = characterClass;
            _locationValue = Area.Sanctuary;
        }

        #endregion

        #region METHODS
    public virtual string Greeting()
        {
            string greeting = "Hello!";
            return greeting;
        }


        #endregion
    }
}
