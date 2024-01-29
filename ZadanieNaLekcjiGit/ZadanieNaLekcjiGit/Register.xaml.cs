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
    public partial class Register : ContentPage
    {
        public Register()
        {
            InitializeComponent();
        }

        private void Zarejestruj(object sender, EventArgs e)
        {

        }

        private void Zaloguj_Click(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Login());
        }
    }
}