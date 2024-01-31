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
    
        User user;
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
        string login=loginEntry.Text;
            string haslo=HasloEntry.Text;
            user = App.Database.ZalogujUzytkownika(login, haslo);
        }

        private void ZarejestrujSie_Nav(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Register());
        }
    }
}