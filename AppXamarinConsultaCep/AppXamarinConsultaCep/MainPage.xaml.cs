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
				if (!string.IsNullOrEmpty(txtCep.Text))
				{
					using (var client = new HttpClient())
					{
						using (var response = await client.GetAsync(string.Format("https://viacep.com.br/ws/{0}/json/", txtCep.Text)))
						{
							if (response.IsSuccessStatusCode)
							{
								var result = await response.Content.ReadAsStringAsync();

								if (!string.IsNullOrEmpty(result))
								{
									await DisplayAlert("Parabéns", result, "Ok");
								}
								else
								{
									throw new InvalidOperationException("Não tivemos retorno da API");
								}
							}
							else
							{
								throw new InvalidOperationException("Erro ao chamar a API");
							}
						}
					}
				}
				else
				{
					throw new InvalidOperationException("Erro ao informar o cep");
				}
			}
			catch (Exception ex)
			{
				await DisplayAlert("Erro", ex.Message, "Ok");
			}
		}

	}
}
