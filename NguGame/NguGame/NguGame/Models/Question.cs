using System;
using System.Collections.Generic;
using System.Text;

namespace NguGame.Models
{

    public class Question
    {
        public string nameQuestion { get; set; }
        public string rightAnswer { get; set; }
        public string wrongAnswer1 { get; set; }
        public string wrongAnswer2 { get; set; }
        public string wrongAnswer3 { get; set; }
        public string author { get; set; }
        public string explain { get; set; }
    }
}
