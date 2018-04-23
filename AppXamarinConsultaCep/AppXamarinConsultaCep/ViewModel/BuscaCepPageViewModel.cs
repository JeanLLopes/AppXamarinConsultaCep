using System;
using System.Collections.Generic;
using System.Text;

namespace AppXamarinConsultaCep.ViewModel
{
    public class BuscaCepPageViewModel : ViewModelBase
    {
        public BuscaCepPageViewModel():base()
        {

        }

        private string _Cep { get; set; }

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
    }
}
