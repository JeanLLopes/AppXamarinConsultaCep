using AppXamarinConsultaCep.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;
using AppXamarinConsultaCep.ViewModel.Base;
using System.Linq;

namespace AppXamarinConsultaCep.ViewModel
{
    public sealed class CepsPagesViewModel : ViewModelBase
    {
        public CepsPagesViewModel():base()
        {
            //AQUI ADICIONAMOS UM SERVIÇO DE MENSAGEM
            //ELE VAI SER RESPONSAVEL POR RECEBER AS MENSAGEM 
            //ENVIADAS PELA BuscaCepPageViewModel
            //COM O TITULO "ADICIONAR_CEP"
            MessagingCenter.Subscribe<BuscaCepPageViewModel>(this, "ADICIONAR_CEP", (sender) =>
            {
                //VERIFICA SE JÁ EXISTE NA LISTA
                //CASO NAO EXISTA NA LISTA QUE VAI PARA A TELA
                //ELE ADICIONA
                if (!Ceps.Any(x => x.Equals(sender.Cep)))
                {
                    //ADICIONA O NOVO CEP A LISTA QUE VAI PARA A VIEW
                    Ceps.Add(sender.Cep);
                }
            });
                
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
