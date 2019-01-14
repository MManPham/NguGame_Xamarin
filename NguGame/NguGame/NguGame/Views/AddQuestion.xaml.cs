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
	public partial class AddQuestion : ContentPage
	{
		public AddQuestion ()
		{
			InitializeComponent ();
            BindingContext = new AddQuestionVM();
		}
        private async void Cmdbackhome_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }

        private void Cmdsubmit_Clicked(object sender, EventArgs e)
        {

        }
    }
}