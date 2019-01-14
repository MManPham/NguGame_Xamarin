using NguGame.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NguGame.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TopScore : ContentPage
	{
		public TopScore (ObservableCollection<User> _luser)
		{
			InitializeComponent ();

            int counter = 0;

            listScore.ItemsSource = _luser;


        }
	}
}