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
    public class MasaViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        public string NumeMancare { get; set; }
        public int NumarCalorii { get; set; }
        public string TipMasa { get; set; }
        public List<string> ListaTipMese { get; set; }
        public ICommand AdaugaCommand { get; set; }
        public INavigation Navigation { get; set; }

        public MasaViewModel()
        {
            ListaTipMese = Enum.GetNames(typeof(TipMasa)).ToList(); 
            AdaugaCommand = new Command(Adauga_Click);
        }

        private void Adauga_Click()
        {
            Enum.TryParse(TipMasa, out TipMasa tipMasa);
            var masa = new Masa() { 
                TipMasa = tipMasa,
                Nume = NumeMancare,
                Calorii = NumarCalorii,
                Data = DateTime.Now.Date
            };

            var serviciu = new MasaServiciu();
            serviciu.AdaugaMasa(masa);

            Navigation.PushAsync(new ListaMese());
        }
    }
}
