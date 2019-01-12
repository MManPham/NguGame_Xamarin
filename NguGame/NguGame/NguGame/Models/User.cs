using System;
using System.Collections.Generic;
using System.Text;

namespace NguGame.Models
{
    public class User
    {
        public string name { get; set; }

        public User(string _name)
        {
            this.name = _name;
        }
        public User()
        {
            this.name = null;
        }
    }
}
