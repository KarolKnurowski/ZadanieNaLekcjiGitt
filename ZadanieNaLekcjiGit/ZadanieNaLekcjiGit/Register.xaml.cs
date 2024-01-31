using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using ZadanieNaLekcjiGit.tabele;

namespace ZadanieNaLekcjiGit
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Register : ContentPage
    {
        private readonly DataBase _dataAccess;
        User user;

        public Register()
        {
            _dataAccess = new DataBase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "bazadanych.db3"));
            InitializeComponent();
        }

        private async void Zarejestruj(object sender, EventArgs e)
        {
            string login = loginEntry.Text;
            string haslo = HasloEntry.Text;
            string powtorzhaslo = HasloPEntry.Text;

            if (haslo != powtorzhaslo)
            {
                await DisplayAlert("Błąd!", "Hasła nie są takie same!", "OK");
                return;
            }

            user = new User();
            user.Login = login;
            user.Password = haslo;

            int result = await _dataAccess.StworzUzytkownika(user);

            if (result == -1)
            {
                await DisplayAlert("Błąd!", "Login już istnieje!", "OK");

            }
            else
            {
                await DisplayAlert("Sukces", "Użytkownik został utworzony!", "OK");

            }
        }

        private void Zaloguj_Click(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Login());
        }
    }
}
