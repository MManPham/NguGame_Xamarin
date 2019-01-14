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
            answerA = "A. " + resutl[0];
            answerB = "B. " + resutl[1];
            answerC = "C. " + resutl[2];
            answerD = "D. " + resutl[3];
            title = null;
        }
    }
    }
