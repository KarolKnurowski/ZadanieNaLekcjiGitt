using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ZadanieNaLekcjiGit
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }

        private async void Zaloguj_Clicked(object sender, EventArgs e)
        {
            var users = await App.Database.WezUseraFiltr(loginEntry.Text,HasloEntry.Text);
            if (loginEntry.Text.Length != 7 || users.Count == 0)
            {
                DisplayAlert("Blad", "Podano błędne dane", "OK");
                return;
            }

            var user = users.ElementAt(0);
            Navigation.PushAsync(new MainPage(user));
        }
    }
}