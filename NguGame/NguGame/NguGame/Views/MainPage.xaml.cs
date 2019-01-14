using Newtonsoft.Json;
using NguGame.Models;
using NguGame.Services;
using NguGame.ViewModels;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

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
                User test = new User("Minh Man", "0", DeviceInfo.Model.ToString());
                User result;

                User_MKStore userStore = new User_MKStore();
                result = await userStore.GetUserAsync(test.nameUser);

            });
        }


        //About Click      
        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new About());
        }


        private async void AddQuestion_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddQuestion());
        }
    }
}