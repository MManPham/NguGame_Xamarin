using Xamarin.Forms;

namespace NguGame.ViewModels
{
    public class OutGameVM
    {
        public Command MakeNewGame
        {
            get; set;
        }
        public Command MainPage
        {
            get; set;
        }
        public OutGameVM()
        {
            MakeNewGame = new Command(() =>
          {
              MainPageVM abc = new MainPageVM();
              abc.NewGameCmd.Execute(null);
          });
            MainPage = new Command(async () =>
            {
                await Application.Current.MainPage.Navigation.PopToRootAsync();

            });
        }
    }
}
