using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        private void Zarejestruj(object sender, EventArgs e)
        {
            string login = loginEntry.Text;
            string haslo = HasloEntry.Text;
            string powtorzhaslo = HasloPEntry.Text;
            if (haslo != powtorzhaslo)
            {
                DisplayAlert("Błąd!", "Hasła nie są takie same!", "ok");
            }
            user = new User();
            user.Login = login;
            user.Password = haslo;
            _dataAccess.StworzUzytkownika(user);
        }

        private void Zaloguj_Click(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Login());
        }
    }
}