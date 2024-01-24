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
            OcenyUcznia.ItemsSource = await App.Database.WezOceny();

            List<List<string>> pierwszalista = new List<List<string>>();
            List<List<string>> drugalista = new List<List<string>>();

            var subjects = await App.Database.WezOcenyy();
            foreach (var subject in subjects)
            {
                List<string> row = new List<string>();

                var pierwszeoceny = await App.Database.WezOceny(this.user.Id, subject.Subject_id, "Okres 1");
                string pierwszeocenyText = "";
                foreach (var score in pierwszeoceny)
                {
                    pierwszeocenyText += score.Value + " ";
                }
                row.Add(pierwszeocenyText);
                row.Add(subject.Name);

                pierwszalista.Add(row);
            }

            foreach (var subject in subjects)
            {
                List<string> row = new List<string>();

                var drugieoceny = await App.Database.WezOceny(this.user.Id, subject.Subject_id, "Okres 2");
                string ocenydrugie = "";
                foreach (var score in drugieoceny)
                {
                    ocenydrugie += score.Value + " ";
                }
                row.Add(ocenydrugie);
                row.Add(subject.Name);

                drugalista.Add(row);
            }

            Oceny1.ItemsSource = pierwszalista;
            Oceny2.ItemsSource = drugalista;
        }
    }
}
