using NguGame.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace NguGame.ViewModels
{
    public class AddQuestionVM:BasicViewModel
    {

        private Question _addQ;
        public Question AddQuestion
        {
            get { return _addQ; }
            set
            {
                _addQ = value;
                OnPropertyChanged();
            }
        }
        public Command AddQuestionCommand { get; set; }
        public AddQuestionVM()
        {
            AddQuestion = new Question();

            AddQuestionCommand = new Command(async () =>
            {
                try
                {
                    await DataStore.AddQuestionAsync(AddQuestion);
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    await Application.Current.MainPage.Navigation.PopToRootAsync();
                }

            });

        }
    }
}
