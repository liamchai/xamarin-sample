using IceSkateMobile.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IceSkateMobile
{
    public partial class App : Application
    {

        public App()
        {
            DevExpress.XamarinForms.Editors.Initializer.Init();
            InitializeComponent();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
