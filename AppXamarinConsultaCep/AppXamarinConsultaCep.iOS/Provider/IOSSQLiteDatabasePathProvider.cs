using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AppXamarinConsultaCep.iOS.Provider;
using AppXamarinConsultaCep.Provider;
using Foundation;
using SQLite;
using UIKit;
[assembly: Xamarin.Forms.Dependency(typeof(IOSSQLiteDatabasePathProvider))]

namespace AppXamarinConsultaCep.iOS.Provider
{
    class IOSSQLiteDatabasePathProvider : ISQLiteDatabasePathProvider
    {
        public IOSSQLiteDatabasePathProvider()
        {

        }

        //AQUI NOS RETORNAMOS A PASTA ONDE SERÁ CRIADO DATABASE
        //OU ACESSADO
        public string GetDatabasePath()
        {
            var databasePath =  Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "..", "Library", "Batabases");
            if (!Directory.Exists(databasePath))
            {
                Directory.CreateDirectory(databasePath);
            }

            return Path.Combine(databasePath, "BuscaCep.db3");
        }
    }
}