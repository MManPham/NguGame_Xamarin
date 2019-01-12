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

        public Question(IList<object> _question)
        {
            this.nameQuestion = _question[0].ToString();
            this.rightAnswer = _question[1].ToString();
            this.wrongAnswer1 = _question[2].ToString();
            this.wrongAnswer2 = _question[3].ToString();
            this.wrongAnswer3 = _question[4].ToString();
            this.explain = _question[5].ToString();
            this.author = _question[6].ToString();
        }
    }
}
