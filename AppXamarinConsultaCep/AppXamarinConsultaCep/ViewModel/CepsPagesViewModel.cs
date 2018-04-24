using AppXamarinConsultaCep.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;
using AppXamarinConsultaCep.ViewModel.Base;
using System.Linq;
using System.Threading.Tasks;
using AppXamarinConsultaCep.Messages;
using AppXamarinConsultaCep.Model;
using AppXamarinConsultaCep.Data;

namespace AppXamarinConsultaCep.ViewModel
{
    public sealed class CepsPagesViewModel : ViewModelBase
    {
        public CepsPagesViewModel():base()
        {
                
        }

        public ObservableCollection<ViaCepModel> Ceps
        {
            get;
            private set;
        } = new ObservableCollection<ViaCepModel>();

        private Command _BuscarCommand;
        private Command _RefreshCommand;

        //Navigation.PushAsync ADICIONAR UM PAGINA NO ITEM DE NAVEGAÇÃO
        //QUE INSERIMOS NO ARQUIVO App.xaml.cs ( new NavigationPage )
        //PUSH - ADICIONAR UM ITEM A NAVIGATION PAGE
        //POP - REMOVE UM ITEM DA NAVEGATION PAGE
        public Command BuscarCommand => _BuscarCommand ?? (_BuscarCommand = new Command(async() => await BuscarCommandExecute()));

        public Command RefreshCommand => _RefreshCommand ?? (_RefreshCommand = new Command(async () => await RefreshCommandExecute()));

        private async Task RefreshCommandExecute()
        {
            try
            {

                await Task.FromResult<object>(null);

                RefreshCommand.ChangeCanExecute();
                
                //LIMPAMOS A LISTA ANTES DE APRESENTAR AO NOSSO CLIENTE
                Ceps.Clear();
                //ADICIONA O NOVO CEP A LISTA QUE VAI PARA A VIEW
                foreach (var item in DatabaseService.Current.GetAll())
                {
                    Ceps.Add(item);
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        private async Task BuscarCommandExecute()
        {
            try
            {
                //AQUI ADICIONAMOS UM SERVIÇO DE MENSAGEM
                //ELE VAI SER RESPONSAVEL POR RECEBER AS MENSAGEM 
                //ENVIADAS PELA BuscaCepPageViewModel
                //COM O TITULO "ADICIONAR_CEP"
                MessagingCenter.Subscribe<BuscaCepPageViewModel>(this, MessagesKey.CepsAtualizados, (sender) =>
                {
                    this.RefreshCommand.Execute(null);


                    //DEPOIS DE RECEBER A MENSAGEM NOS RETIRAMOS DA LITA DE RECEBEDORES
                    MessagingCenter.Unsubscribe<BuscaCepPageViewModel>(this, "");
                });

                await PushAsync(new BuscaCepPage());
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
