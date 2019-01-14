using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using NguGame.Models;
using NguGame.Views;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;

namespace NguGame.ViewModels
{

    static class Extensions
    {
        public static void Sort<TSource, TKey>(this ObservableCollection<TSource> collection, Func<TSource, TKey> keySelector)
        {
            List<TSource> sorted = collection.OrderBy(keySelector).ToList();
            for (int i = 0; i < sorted.Count(); i++)
                collection.Move(collection.IndexOf(sorted[i]), i);
        }
    }
    public class MainPageVM:BasicViewModel
    {

        public Command NewGameCmd { get; set; }
        public Command TopScoreCmd { get; set; }
        public MainPageVM()
        {
            this.NewGameCmd = new Command(async () =>
            {
                await ExecuteLoadQuestsCommand();
            });

            this.TopScoreCmd = new Command(async () => {
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
            ObservableCollection<User> _luser = new ObservableCollection<User>();
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
