using System;
using System.Collections.Generic;
using System.ComponentModel;
using Elephonkey.Models;
using System.Windows.Input;

namespace Elephonkey.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private LoginRequestModel myloginRequestModel = new LoginRequestModel();

        public LoginRequestModel MyloginRequestModel
        {
            get 
            { 
                return myloginRequestModel;
            }

            set
            {
                myloginRequestModel = value;

                OnPropertyChanged(nameof(MyloginRequestModel));
            }
        }

        public ICommand LoginCommand { get; }

        
        public LoginViewModel() 
        {
            LoginCommand = new Command(PerformLoginOperation);
        }

        private async void PerformLoginOperation(object obj)
        {
            var data = MyloginRequestModel;

            Preferences.Set("UserAlreadyloggedIn", true);



            await Shell.Current.GoToAsync(state: "//Dashboard");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged? .Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
