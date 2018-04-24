using AppXamarinConsultaCep.Clients;
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
        private string _Cep { get; set; }
        private string _CepBusca { get; set; }
        private string _Logradouro { get; set; }
        private string _Bairro { get; set; }
        private string _Localidade { get; set; }
        private string _Uf { get; set; }

        private bool _IsBusy = false;

        //AQUI NOS ALTERAMOS O GET E O SETER POR UM MOTIVO
        //QUANDO EU SETAR UM VALOR NOVO NA CAMPO DE Cep
        //NA TELA ELE VAI ATUALIZAR A PROPRIEDADE PRIVADA
        //E DEPOSI ATUALIZAR A TELA USANDO O OnPropertyChanged(); 
        public string Cep
        {
            get => _Cep;
            set
            {
                _Cep = value;
                OnPropertyChanged();
            }
        }
        public string CepBusca
        {
            get => _CepBusca;
            set
            {
                _CepBusca = value;
                OnPropertyChanged();
            }
        }
        public string Logradouro
        {
            get => _Logradouro;
            set
            {
                _Logradouro = value;
                OnPropertyChanged();
            }
        }
        public string Localidade
        {
            get => _Localidade;
            set
            {
                _Localidade = value;
                OnPropertyChanged();
            }
        }
        public string Bairro
        {
            get => _Bairro;
            set
            {
                _Bairro = value;
                OnPropertyChanged();
            }
        }
        public string Uf
        {
            get => _Uf;
            set
            {
                _Uf = value;
                OnPropertyChanged();
            }
        }
        public bool IsNotBusy { get => !IsBusy; }
        public bool HasCep
        {
            get => !string.IsNullOrWhiteSpace(_Cep);
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
                }


                //CONFIGURAMOS A MENSAGEM QUE VAI SER ENVIADA PARA A VIEWMODEL
                MessagingCenter.Send(this, "ADICIONAR_CEP");

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


                var result = await ViaCepHttpClient.Current.BuscarCep(CepBusca);
                Cep = result.Cep;
                if (HasCep)
                {
                    Logradouro = result.Logradouro;
                    Localidade = result.Localidade;
                    Bairro = result.Bairro;
                    Uf = result.Uf;
                }
                
                //CHAMAMOS O HASCEP AQUIP PARA ELE ATUALIZAR PARA TRUE
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
