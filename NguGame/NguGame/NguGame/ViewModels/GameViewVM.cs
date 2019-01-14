using NguGame.Models;
using NguGame.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace NguGame.ViewModels
{
    public class GameViewVM: BasicViewModel
    {
        private ObservableCollection<Question> _lquestion;
        public ObservableCollection<Question> LQuestion
        {
            get { return _lquestion; }
            set
            {
                _lquestion = value;
                OnPropertyChanged();
            }
        }
        private Question _currQuestion;
        public Question currQuestion
        {
            get { return _currQuestion; }
            set
            {
                _currQuestion = value;
                OnPropertyChanged();
            }
        }

        private int _luotNgu;
        public int LuotNgu
        {
            get { return _luotNgu; }
            set
            {
                _luotNgu = value;
                OnPropertyChanged();
            }
        }

        private int _score;
        public int Score
        {
            get { return _score; }
            set
            {
                _score = value;
                OnPropertyChanged();
            }
        }

        private ShowQuestion _showQ;
        public ShowQuestion ShowQ
        {
            get { return _showQ; }
            set
            {
                _showQ = value;
                OnPropertyChanged();
            }
        }

        public GameViewVM(ObservableCollection<Question> lqs)
        {
            LQuestion = lqs;
            GetRandomQuestion();
            setShowAnswer();
            LuotNgu = 3;
            Score = 0;

            MessagingCenter.Subscribe<GameView, string>(this, "RightAnswer",  (obj, nameAnswer) =>
            {
                rightAnswer(lqs);
            });

            MessagingCenter.Subscribe<GameView, string>(this, "WrongAnswer", (obj, nameAnswer) =>
            {
                WrongAnswer(lqs);
            });

        }

        public void GetRandomQuestion()
        {
            int Numrd;
            Random rd = new Random();
            Numrd = rd.Next(0, this.LQuestion.Count);
            try
            {
              this.currQuestion = LQuestion[Numrd];
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ShowQuestion setShowAnswer()
        {
            List<string> result = new List<string>(4);
            List<string> listAnswer = new List<string>(4);
            listAnswer.Add(currQuestion.rightAnswer);
            listAnswer.Add(currQuestion.wrongAnswer1);
            listAnswer.Add(currQuestion.wrongAnswer2);
            listAnswer.Add(currQuestion.wrongAnswer3);

            Random random = new Random();
            while (listAnswer.Count > 0)
            {
                string next = listAnswer[random.Next(listAnswer.Count)];
                listAnswer.Remove(next);
                result.Add(next);
            }
            ShowQ = new ShowQuestion(result);
            ShowQ.title = currQuestion.nameQuestion;
            return ShowQ;
        }

        public  void rightAnswer( ObservableCollection<Question> lqs)
        {
            Score += 5  ;
            lqs.Remove(currQuestion);
            this.LQuestion = lqs;
            GetRandomQuestion();
            ShowQ = setShowAnswer();
        }
        public async  void WrongAnswer(ObservableCollection<Question> lqs)
        {
            if (LuotNgu == 2)
            {
                await Application.Current.MainPage.Navigation.PushAsync(new GameOver());

            }
            LuotNgu--;
            lqs.Remove(currQuestion);
            this.LQuestion = lqs;
            GetRandomQuestion();
            ShowQ = setShowAnswer();
        }

        private Task LoadPage(ObservableCollection<Question> lqs)
        {
           return null;
        }


    }}
