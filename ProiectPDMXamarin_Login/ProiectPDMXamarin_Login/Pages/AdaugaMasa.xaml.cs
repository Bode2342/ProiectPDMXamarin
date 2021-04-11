using ProiectPDMXamarin.ViewModels;
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
    public partial class AdaugaMasa : ContentPage
    {
        public AdaugaMasa()
        {
            InitializeComponent();
            MasaViewModel masaViewModel = new MasaViewModel();
            masaViewModel.Navigation = Navigation;
            BindingContext = masaViewModel;
        }
    }
}