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
	public partial class GameOver : ContentPage
	{
		public GameOver (int Score)
		{
			InitializeComponent ();
            BindingContext = new OutGameVM( Score);
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
          
        }
    }
}