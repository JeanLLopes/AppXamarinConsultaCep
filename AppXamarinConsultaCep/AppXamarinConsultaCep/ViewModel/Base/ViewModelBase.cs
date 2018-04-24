using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppXamarinConsultaCep.ViewModel.Base
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        //AQUI NOS IMPLEMENTAMOS A INTERFACE PARA QUE AUTOMATICAMENTE 
        //ELE ATUALIZE A VIEW E A MODEL CASO TENHAM MUDANÇAS NA VIEW
        public event PropertyChangedEventHandler PropertyChanged;


        //ESTE É O RESPONSAVEL POR EFETUAR AS ATUALIZAÇÕES
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        #region NAVEGAÇÂO

        //AQUI NOS DEFINIMOS COMO VAI SER A BASE DA NAVEGAÇÃO DE NOSSO SITE
        protected Task PushAsync(Page page,bool animated = true) => App.Current.MainPage.Navigation.PushAsync(page, animated);
        #endregion
    }
}
