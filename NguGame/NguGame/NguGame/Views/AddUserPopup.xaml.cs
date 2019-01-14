using NguGame.ViewModels;
using Rg.Plugins.Popup.Pages;
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
	public partial class AddUserPopup : PopupPage
    {
		public AddUserPopup ()
		{
			InitializeComponent ();
            BindingContext = new AddUserVM();

        }

        private void AddUser_Clicked(object sender, EventArgs e)
        {
            if(nameUser.Text=="")
            {
                DisplayAlert("Thông báo", "Bạn chưa nhập tên mình. NG", "Oke");
            }
            else
            {
                MessagingCenter.Send(this, "AddUser", nameUser.Text);
            }

        }
    }
}