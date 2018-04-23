using AppXamarinConsultaCep.Clients;
using System;
using System.Net.Http;
using Xamarin.Forms;

namespace AppXamarinConsultaCep
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}


		protected async void BtnBuscarCep_Clicked(object sender, EventArgs e)
		{
            try
            {
                var result = await ViaCepHttpClient.Current.BuscarCep(txtCep.Text);
                await DisplayAlert("Parabéns", result, "Ok");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", ex.Message, "Ok");
            }
        }

	}
}
