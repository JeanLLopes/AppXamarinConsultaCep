using AppXamarinConsultaCep.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;
using AppXamarinConsultaCep.ViewModel.Base;

namespace AppXamarinConsultaCep.ViewModel
{
    public sealed class CepsPagesViewModel : ViewModelBase
    {
        public CepsPagesViewModel():base()
        {
                
        }

        public ObservableCollection<string> Ceps
        {
            get;
            private set;
        } = new ObservableCollection<string>();

        private Command _BuscarCommand;

        //Navigation.PushAsync ADICIONAR UM PAGINA NO ITEM DE NAVEGAÇÃO
        //QUE INSERIMOS NO ARQUIVO App.xaml.cs ( new NavigationPage )
        //PUSH - ADICIONAR UM ITEM A NAVIGATION PAGE
        //POP - REMOVE UM ITEM DA NAVEGATION PAGE
        public Command BuscarCommand => _BuscarCommand ?? (_BuscarCommand = new Command(async() => await PushAsync(new BuscaCepPage())));
    }
}
