using System;
using System.Collections.Generic;
using System.Linq;
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
                List<string> rowOkres1 = new List<string>();
                List<string> rowOkres2 = new List<string>();

                var pierwszeoceny = await App.Database.WezOceny(this.user.Id, subject.Subject_id, "Okres 1");
                foreach (var score in pierwszeoceny)
                {
                    rowOkres1.Add($"{score.Value} ({score.AddedDate:dd.MM.yyyy})");
                }
                rowOkres1.Add(subject.Name);

                var drugieoceny = await App.Database.WezOceny(this.user.Id, subject.Subject_id, "Okres 2");
                foreach (var score in drugieoceny)
                {
                    rowOkres2.Add($"{score.Value} ({score.AddedDate:dd.MM.yyyy})");
                }
                rowOkres2.Add(subject.Name);

                pierwszalista.Add(rowOkres1);
                drugalista.Add(rowOkres2);
            }

            Oceny1.ItemsSource = pierwszalista;
            Oceny2.ItemsSource = drugalista;
        }

        private async void DodajOcene_Clicked(object sender, EventArgs e)
        {
            string kategoria = nazwa.Text?.ToString();
            string ocena = czas1.Text?.ToString();
            string opis = czas2.Text;
            string okres = okresPicker.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(kategoria) || string.IsNullOrEmpty(ocena) || string.IsNullOrEmpty(okres))
            {
                await DisplayAlert("Błąd", "Wypełnij wszystkie pola, w tym wybierz okres", "OK");
                return;
            }

            // Sprawdź, czy przedmiot istnieje
            Subject subject = await App.Database.WezOcenyyBySubjectName(kategoria);

            if (subject == null)
            {
                // Jeśli przedmiot nie istnieje, dodaj go do obu okresów
                subject = new Subject { Name = kategoria };
                await App.Database.InsertSubject(subject);
            }

            Score nowaOcena = new Score
            {
                User_id = user.Id,
                Subject_id = subject.Subject_id,
                Value = ocena,
                Description = opis,
                Period = okres,
                Date = DateTime.Now,
                AddedDate = DateTime.Now
            };

            // Dodaj ocenę do obu okresów
            await App.Database.InsertScore(nowaOcena);
            await DisplayAlert("Sukces", "Dodano nową ocenę", "OK");

            UploadData();
        }
    }
}
