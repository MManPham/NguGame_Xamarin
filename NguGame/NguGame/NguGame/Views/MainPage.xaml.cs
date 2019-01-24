using Newtonsoft.Json;
using NguGame.Models;
using NguGame.Services;
using NguGame.ViewModels;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using Rg.Plugins.Popup.Services;

namespace NguGame.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        MainPageVM MainPageVM;
        public MainPage()
        {
            InitializeComponent();

            MainPageVM = new MainPageVM();
            BindingContext = MainPageVM;

            //var device = DeviceInfo.Model;
        }

        protected override void OnAppearing()
        {

            base.OnAppearing();

            Device.BeginInvokeOnMainThread(async () =>
            {

                User_MKStore userStore = new User_MKStore();
                try
                {
                    User result = await userStore.CheckDeviceAsync(DeviceInfo.Model.ToString());
                }
                catch (Exception)
                {
                    await PopupNavigation.Instance.PushAsync(new AddUserPopup());

                }


            });
        }


        //About Click      
        private async  void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new About());
        }

        private async void AddQuestion_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddQuestion());
        }
    }
}