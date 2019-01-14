using NguGame.Models;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace NguGame.ViewModels
{
    public class OutGameVM:BasicViewModel
    {
        public Command MakeNewGame
        {
            get; set;
        }
        public Command MainPage
        {
            get; set;
        }
        public OutGameVM(int UScore)
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


            Device.BeginInvokeOnMainThread(async () =>
            {
                User upUser = await User_DataStore.CheckDeviceAsync(DeviceInfo.Model);
                upUser.score = UScore;
                await User_DataStore.UpdateUser(upUser);
            });

        }
    }
}
