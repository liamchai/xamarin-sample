using IceSkateMobile.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace IceSkateMobile.ViewModels
{
    public class SettingViewModel
    {
        public ICommand LogoutCommand { get; }

        public SettingViewModel()
        {
            LogoutCommand = new Command(OnLogoutClicked);
        }

        private async void OnLogoutClicked(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }

    }
}
