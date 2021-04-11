using ProiectPDMXamarin.Services;
using ProiectPDMXamarin_Login.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProiectPDMXamarin.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaMese : ContentPage
    {
        List<Masa> listaMese;

        public ListaMese(DateTime? data = null)
        {
            InitializeComponent();
            data = data ?? DateTime.Now.Date;
            MasaServiciu serviciu = new MasaServiciu();
            listaMese = serviciu.ObtineMese(data.Value);
            listViewMese.ItemsSource = listaMese;
        }
    }
}