using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ZadanieNaLekcjiGit.tabele;

namespace ZadanieNaLekcjiGit
{
    public partial class MainPage : TabbedPage
    {
        User user;
        public MainPage(User user)
        {

            InitializeComponent();
            this.user = user;
            UploadData();
        }
        public async void UploadData()
        {
       
        }
    }
}
