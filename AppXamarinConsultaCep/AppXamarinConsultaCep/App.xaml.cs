using AppXamarinConsultaCep.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace AppXamarinConsultaCep
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

            //CRIAMOS UMA PILHA DE NAVEGAÇÃO
            //E COLOCAMOS COMO PAGINA INICIAL A CepsPage()
			MainPage = new NavigationPage(new CepsPages());
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
