using NguGame.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace NguGame.ViewModels
{
    public class MainPageVM: BasicViewModel
    {
        private User _user;
        public User User
        {
            get { return _user; }
            set
            {
                _user = value;
                OnPropertyChanged();
            }
        }
        public MainPageVM()
        {
            User = new User();
        }
    }
}
