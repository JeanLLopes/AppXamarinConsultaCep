using AppXamarinConsultaCep.Clients;
using AppXamarinConsultaCep.ViewModel;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppXamarinConsultaCep.Commands
{
    public class BuscaCepPageCommands
    {
        private Command _BuscarCommand;


        public Command BuscarCommand()
        {
            if (_BuscarCommand != null)
            {
                _BuscarCommand = new Command(async () => await BuscarCommandExecute());
                
            }
            return _BuscarCommand;
        }

        private async Task BuscarCommandExecute()
        {
            try
            {
                var result = await ViaCepHttpClient.Current.BuscarCep(new BuscaCepPageViewModel().Cep);
                await App.Current.MainPage.DisplayAlert("Parabéns", "", "Ok");
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Erro", ex.Message, "Ok");
            }

        }
    }
}
