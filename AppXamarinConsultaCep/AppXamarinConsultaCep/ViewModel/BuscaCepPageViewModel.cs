using AppXamarinConsultaCep.Clients;
using AppXamarinConsultaCep.Messages;
using AppXamarinConsultaCep.Model;
using AppXamarinConsultaCep.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppXamarinConsultaCep.ViewModel
{
    public class BuscaCepPageViewModel : ViewModelBase
    {
        public BuscaCepPageViewModel():base()
        {

        }

        #region VIEWMODEL
        public ViaCepModel _ViaCep { get; set; } = null;
        private string _Cep { get; set; }
        private string _CepBusca { get; set; }

        private bool _IsBusy = false;

        //AQUI NOS ALTERAMOS O GET E O SETER POR UM MOTIVO
        //QUANDO EU SETAR UM VALOR NOVO NA CAMPO DE Cep
        //NA TELA ELE VAI ATUALIZAR A PROPRIEDADE PRIVADA
        //E DEPOSI ATUALIZAR A TELA USANDO O OnPropertyChanged(); 
        public string Cep { get => _ViaCep?.Cep;}
        public string Logradouro { get => _ViaCep?.Logradouro; }
        public string Localidade { get => _ViaCep?.Localidade; }
        public string Bairro { get => _ViaCep?.Bairro; }
        public string Uf { get => _ViaCep?.Uf; }
        public string CepBusca
        {
            get => _CepBusca;
            set
            {
                _CepBusca = value;
                OnPropertyChanged();
            }
        }
        public bool IsNotBusy { get => !IsBusy; }
        public bool HasCep
        {
            get => _ViaCep != null;
        }
        public bool IsBusy
        {
            get => _IsBusy;
            set
            {
                _IsBusy = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsNotBusy));
            }
        }

        #endregion



        #region COMMAND
        private Command _BuscarCommand;
        private Command _AdicionarCepCommand;
        //PASSAMOS UM PARAMETRO A MAIS PARA VERIFICAR SE O BOTAO FOI CLICADO
        public Command BuscarCommand => _BuscarCommand ?? (_BuscarCommand = new Command(async () => await BuscarCommandExecute(), () => IsNotBusy));

        public Command AdicionarCepCommand => _AdicionarCepCommand ?? (_AdicionarCepCommand = new Command(async() => await AdicionarCepCommandExecute(), () => IsNotBusy));
        
        private async Task AdicionarCepCommandExecute()
        {
            try
            {
                if (IsBusy)
                {
                    return;
                }
                else
                {
                    IsBusy = true;
                    BuscarCommand.ChangeCanExecute();
                    AdicionarCepCommand.ChangeCanExecute();

                    //SALVAMOS O CEP NO BANCO DE DADOS
                    Data.DatabaseService.Current.Save(_ViaCep);
                }


                //CONFIGURAMOS A MENSAGEM QUE VAI SER ENVIADA PARA A VIEWMODEL
                MessagingCenter.Send(this, MessagesKey.CepsAtualizados);

                //REMOVEMOS A PAGINA DA PILHA
                await PopAsync();

                //VAMOS AVISAR A TELA DE LISTA DE CEPS QUE UM NOVO CEP DEVE SER ADICIONADO
                await Task.FromResult<object>(null);
            }
            catch (Exception)
            {


            }
            finally
            {
                IsBusy = false;
                BuscarCommand.ChangeCanExecute();
                AdicionarCepCommand.ChangeCanExecute();
            }
        }

        private async Task BuscarCommandExecute()
        {
            try
            {
                //CASO O USUARIO CLIQUE POR VARIAS VEZES NO BOTAO;
                //E ALTERAMOS O ESTADO DELE
                if (IsBusy)
                {
                    return;
                }
                else
                {
                    IsBusy = true;
                    BuscarCommand.ChangeCanExecute();
                    AdicionarCepCommand.ChangeCanExecute();
                }


                _ViaCep = await ViaCepHttpClient.Current.BuscarCep(CepBusca);
                _ViaCep.Id = new Guid();


                //CHAMAMOS O HASCEP AQUIP PARA ELE ATUALIZAR PARA TRUE
                OnPropertyChanged(nameof(Cep));
                OnPropertyChanged(nameof(Localidade));
                OnPropertyChanged(nameof(Logradouro));
                OnPropertyChanged(nameof(Bairro));
                OnPropertyChanged(nameof(Uf));
                OnPropertyChanged(nameof(HasCep));
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Erro", ex.Message, "Ok");
            }
            finally
            {
                //AQUI NOS REABILITAMOS O BOTAO
                IsBusy = false;
                BuscarCommand.ChangeCanExecute();
                AdicionarCepCommand.ChangeCanExecute();
            }

        }
  
        #endregion
    }
}
