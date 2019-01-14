using NguGame.Models;
using NguGame.Views;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace NguGame.ViewModels
{
    public class AddUserVM:BasicViewModel
    {
        private string   _nameUser;
        public string NameUser
        {
            get { return _nameUser; }
            set
            {
                _nameUser = value;
                OnPropertyChanged();
            }
        }
        public Command AddUserCommand { get; set; }
        public AddUserVM()
        {
            MessagingCenter.Subscribe<AddUserPopup, string>(this, "AddUser", async (obj, nameUser) =>
            {
                User newUser = new User(nameUser, 0, DeviceInfo.Model);
                await User_DataStore.AddUser(newUser);
                await PopupNavigation.Instance.PopAsync();
                MainPageVM abc = new MainPageVM();
                abc.NewGameCmd.Execute(null);
            });

        }


        
    }
}
