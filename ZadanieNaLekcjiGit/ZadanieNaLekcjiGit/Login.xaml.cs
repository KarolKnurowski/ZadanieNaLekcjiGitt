using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZadanieNaLekcjiGit.tabele;

namespace ZadanieNaLekcjiGit
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
            //dodaj();
        }
        //public async void dodaj()
        //{
        //    User x = new User()
        //    {
        //        Name = "Karol",
        //        Surname = "Knurowski",
        //        Login = "000001n",
        //        Password = "karol123",
        //        IsTeacher = true
        //    };
        //    await App.Database.DodajUsera(x);
        //    Subject sbj = new Subject()
        //    {
        //        Name = "Programowanie"
        //    };
        //    await App.Database.InsertSubject(sbj);
        //    Score s = new Score()
        //    {
        //        User_id = 1,
        //        Subject_id = 1,
        //        Subject_name = "Programowanie",
        //        Value = "5+",
        //        Date = DateTime.Now,
        //        Description = "Sprawdzian",
        //        Period = "Okres 1"
        //    };
        //    await App.Database.InsertScore(s);
        //}

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