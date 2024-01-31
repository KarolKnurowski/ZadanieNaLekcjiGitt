using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZadanieNaLekcjiGit.tabele;

namespace ZadanieNaLekcjiGit
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        User user;

        public Login()
        {
            InitializeComponent();
        }

        private async void Zaloguj_Clicked(object sender, EventArgs e)
        {
            string login = loginEntry.Text;
            string haslo = HasloEntry.Text;

            user = await App.Database.ZalogujUzytkownika(login, haslo);

            if (user != null)
            {
                await DisplayAlert("Sukces", "Zalogowano pomyślnie!", "OK");
                MainPage mainPage = new MainPage(user);
                await Navigation.PushAsync(mainPage);
            }
            else
            {
                await DisplayAlert("Błąd!", "Błędny login lub hasło!", "OK");
            }
        }


        private void ZarejestrujSie_Nav(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Register());
        }
    }
}
