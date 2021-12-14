using IceSkateMobile.ViewModels;
using IceSkateMobile.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace IceSkateMobile
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(RegisterPage), typeof(RegisterPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
