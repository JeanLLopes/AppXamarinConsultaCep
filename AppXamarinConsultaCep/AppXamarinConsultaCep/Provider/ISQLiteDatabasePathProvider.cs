using System;
using System.Collections.Generic;
using System.Text;

namespace AppXamarinConsultaCep.Provider
{
    public interface ISQLiteDatabasePathProvider
    {
        //AQUI NOS CRIAMOS UM METODO QUE VAI RETORNAR O CAMINHO DO NOSSO DATABASE
        string GetDatabasePath();
    }
}
