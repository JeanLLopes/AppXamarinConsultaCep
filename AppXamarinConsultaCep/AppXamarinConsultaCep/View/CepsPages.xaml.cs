using AppXamarinConsultaCep.ViewModel;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppXamarinConsultaCep.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CepsPages : ContentPage
    {
        public ObservableCollection<string> Items { get; set; }

        public CepsPages()
        {
            InitializeComponent();
            BindingContext = new CepsPagesViewModel();
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
    }
}
