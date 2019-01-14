using NguGame.DataAccess;
using NguGame.Models;
using NguGame.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
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

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            RestClient client = new RestClient();
            List<Question> questionList = await client.Get<List<Question>>("http://localhost:3000/question");



        }
        private void PlayGame_Clicked(object sender, EventArgs e)
        {
                Navigation.PushAsync(new GameView());
        }
    }
}