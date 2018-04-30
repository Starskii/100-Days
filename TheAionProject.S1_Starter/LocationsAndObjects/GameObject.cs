using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheZlandProject.LocationsAndObjects;
using TheZlandProject.Models;

namespace TheZlandProject
{
    public class GameObject
    {
        private string _name;
        private Area _location;
        private int _id;
        private bool _isInInventory;
        private string _description;

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }


        public bool IsInInventory
        {
            get { return _isInInventory; }
            set { _isInInventory = value; }
        }



        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }


        public Area Location
        {
            get { return _location; }
            set { _location = value; }
        }


        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

    }
}
