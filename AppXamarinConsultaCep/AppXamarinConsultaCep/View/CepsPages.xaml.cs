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
        private bool _FirtRun = true;

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


        protected override void OnAppearing()
        {
            if (_FirtRun)
            {
                ((CepsPagesViewModel)BindingContext).RefreshCommand.Execute(null);
                _FirtRun = false;
            }
            base.OnAppearing();
        }
    }
}
