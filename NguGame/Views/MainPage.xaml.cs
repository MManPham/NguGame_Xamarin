using NguGame.Models;
using NguGame.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NguGame.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public User currUser { get; set; }
        public MainPage()
        {

            InitializeComponent();
        }

        private void PlayGame_Clicked(object sender, EventArgs e)
        {
                Navigation.PushAsync(new GameView());
        }
    }
}