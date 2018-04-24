using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppXamarinConsultaCep.Model
{
    [Table("CEP")]
    public class ViaCepModel
    {
        [PrimaryKey]
        public Guid Id { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Localidade { get; set; }
        public string Uf { get; set; }
        public string Unidade { get; set; }
        public string Ibge { get; set; }
        public string Gia { get; set; }

    }
}
