using System;
using System.Collections.Generic;
using System.Text;

namespace NguGame.Models
{
    public class User
    {
        public string nameUser { get; set; }
        public string score { get; set; }
        public string nameDivice { get; set; }
        public User( string _name, string _score, string _device)
        {
            this.score = _score;
            this.nameDivice = _device;
            this.nameUser = _name;
        }
    }
}
