using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheZlandProject.Models
{
    public enum Area
    {
        None,
        Sanctuary,
        Hope,
        Desert,
        TC
    }

    public class GameLocation
    {
        private Area _location;
        private bool _isAccessible;
        private string _description;

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }


        public bool IsAccessible
        {
            get { return _isAccessible; }
            set { _isAccessible = value; }
        }


        public Area Location
        {
            get { return _location; }
            set { _location = value; }
        }

    }
}
