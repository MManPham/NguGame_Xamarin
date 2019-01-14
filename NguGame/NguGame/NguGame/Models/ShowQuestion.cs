using System;
using System.Collections.Generic;
using System.Text;

namespace NguGame.Models
{
    public class ShowQuestion
    {
        public string title { get; set; }
        public string answerA { get; set; }
        public string answerB { get; set; }
        public string answerC { get; set; }
        public string answerD { get; set; }

        public ShowQuestion(List<string> resutl)
        {
            answerA = resutl[0];
            answerB =  resutl[1];
            answerC = resutl[2];
            answerD = resutl[3];
            title = null;
        }
    }
    }
