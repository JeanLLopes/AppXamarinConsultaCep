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
            await DisplayAlert("Parabéns", result, "Ok");
        }

	}
}
