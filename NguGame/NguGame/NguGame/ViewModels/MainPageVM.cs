using NguGame.Models;
using NguGame.Views;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace NguGame.ViewModels
{

    static class Extensions
    {
        public static void Sort<TSource, TKey>(this ObservableCollection<TSource> collection, Func<TSource, TKey> keySelector)
        {
            List<TSource> sorted = collection.OrderBy(keySelector).ToList();
            int j = 0;
            for (int i = sorted.Count() - 1; i >= 0; i--)
            {
                collection.Move(collection.IndexOf(sorted[i]), j);
                j++;
            }
        }
    }
    public class MainPageVM : BasicViewModel
    {
        ObservableCollection<User> _luser = new ObservableCollection<User>();

        private Question _user;
        public Question User
        {
            get { return _user; }
            set
            {
                _user = value;
                OnPropertyChanged();
            }
        }

        public Command NewGameCmd { get; set; }
        public Command TopScoreCmd { get; set; }
        public MainPageVM()
        {
            this.NewGameCmd = new Command(async () =>
            {
                await ExecuteLoadQuestsCommand();
            });

            this.TopScoreCmd = new Command(async () =>
            {
                await ExecuteLoadUsersCommand();
            });
        }

        private async Task ExecuteLoadQuestsCommand()
        {
            ObservableCollection<Question> _lquestion = new ObservableCollection<Question>();
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {

                var ListItems = await DataStore.GetAllQuestionsAsync();
                foreach (var item in ListItems)
                {
                    _lquestion.Add(item);
                }

                GameViewVM gameVm = new GameViewVM(_lquestion);
                await Application.Current.MainPage.Navigation.PushAsync(new GameView(gameVm));


            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task ExecuteLoadUsersCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {

                var ListItems = await User_DataStore.GetAllUserAsync();
                foreach (var item in ListItems)
                {
                    _luser.Add(item);
                }
                _luser.Sort(x => x.score);
                await Application.Current.MainPage.Navigation.PushAsync(new TopScore(_luser));


            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }


    }
}
