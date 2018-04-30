using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheAionProject;

namespace TheZlandProject.Models
{
    class Civilian : Character, ISpeak
    {
        public List<string> Messages { get; set; }

        public string Speak()
        {
            if (this.Messages != null)
            {
                return GetMessage();
            }

            else
            {
                return $"My name is {base.Name} and I am a {base.Class}";
            }
        }

        private string GetMessage()
        {
            Random r = new Random();
            int messageIndex = r.Next(0, Messages.Count());
            return Messages[messageIndex];
        }
    }
}
