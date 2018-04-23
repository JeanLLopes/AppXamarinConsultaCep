using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace AppXamarinConsultaCep.ViewModel
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
    }
}
