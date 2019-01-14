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


            for (int i = 0; i < _luser.Count; i++)
            {
                _luser[i].rank = i +1;
            }

            listScore.ItemsSource = _luser;


        }
	}
}