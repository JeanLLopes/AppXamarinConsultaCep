using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppXamarinConsultaCep
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}


        private async void BtnBuscarCep_Clicked(object sender, System.EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtCep.Text))
                {
                    using (var client = new HttpClient())
                    {
                        using (var response = await client.GetAsync(string.Format("ssd{0}", txtCep.Text)))
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
                                    throw new Exception("Não tivemos retorno da API");
                                }
                            }
                            else
                            {
                                throw new Exception("Erro ao chamar a API");
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
