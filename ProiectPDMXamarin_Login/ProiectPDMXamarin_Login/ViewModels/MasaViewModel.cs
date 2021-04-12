using ProiectPDMXamarin.Pages;
using ProiectPDMXamarin.Services;
using ProiectPDMXamarin_Login.Enums;
using ProiectPDMXamarin_Login.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProiectPDMXamarin.ViewModels
{
    public class MasaViewModel
    { 
        public string NumeMancare { get; set; }
        public int NumarCalorii { get; set; }
        public string TipMasa { get; set; }
        public DateTime DataSelectata { get; set; } = DateTime.Now.Date;
        public DateTime DataMinima { get; set; } = new DateTime(DateTime.Now.Year, 1, 1);
        public DateTime DataMaxima { get; set; } = DateTime.Now.Date.AddDays(7);
        public List<string> ListaTipMese { get; set; }
        public ICommand AdaugaCommand { get; set; }
        public INavigation Navigation { get; set; }

        public MasaViewModel()
        {
            ListaTipMese = TipMasaEnum.List.OrderBy(e => e.Value).Select(e => e.Name).ToList() ; 
            AdaugaCommand = new Command(Adauga_Click);
        }

        private void Adauga_Click()
        {
            var masa = new Masa()
            {
                TipMasa = TipMasaEnum.FromValue(Int32.Parse(TipMasa)).Name,
                Nume = NumeMancare,
                Calorii = NumarCalorii,
                Data = DataSelectata.Date
            };

            var serviciu = new MasaServiciu();
            serviciu.AdaugaMasa(masa);

            Navigation.PushAsync(new ListaMese());
        }
    }
}
