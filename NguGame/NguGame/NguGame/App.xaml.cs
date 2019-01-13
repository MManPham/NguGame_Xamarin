using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NguGame.Views;
using NguGame.ViewModels;
using NguGame.DataAccess;
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

        private void LoadData()
        {
            var assembly = typeof(App).GetTypeInfo().Assembly;
            foreach (var res in assembly.GetManifestResourceNames())
            {
                if (res.Contains("data.txt"))
                {
                    Stream stream = assembly.GetManifestResourceStream(res);

                    using (var reader = new StreamReader(stream))
                    {
                        var data = reader.ReadLine();
                    }
                }
            }
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
