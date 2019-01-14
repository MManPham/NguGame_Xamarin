﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NguGame.Views;
using NguGame.ViewModels;
using System.Reflection;
using System.IO;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace NguGame
{
    public partial class App : Application
    {

        public App()
        {
            // Initialize Live Reload.

            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());

        }

 
        protected override void OnStart()
        {
           
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
