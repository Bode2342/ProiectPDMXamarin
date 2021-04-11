using ProiectPDMXamarin_Login.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProiectPDMXamarin.ViewModels
{
    public class ListaMeseViewModel: List<Masa>
    {
        public string Nume { get; set; }

        public int TotalCalorii
        {
            get
            {
                return Mese.Sum(m => m.Calorii);
            }
        }

        public string Titlu
        {
            get
            {
                return $"{Nume} - {TotalCalorii} calorii";
            }
        }

        public List<Masa> Mese => this;
    }
}
