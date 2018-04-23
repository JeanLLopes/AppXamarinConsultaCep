using AppXamarinConsultaCep.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;




namespace AppXamarinConsultaCep.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BuscaCepPage : ContentPage
	{
		public BuscaCepPage ()
		{
			InitializeComponent ();

            //AQUI NOS DEFIMOS QUE VAI FAZER O BINDING
            BindingContext = new BuscaCepPageViewModel();
		}
	}
}