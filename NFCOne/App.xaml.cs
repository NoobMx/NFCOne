using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NFCOne
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Configura la página raíz como una NavigationPage y establece MainPage
            MainPage = new NavigationPage(new MainPage());

            //MainPage = new MainPage();
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
