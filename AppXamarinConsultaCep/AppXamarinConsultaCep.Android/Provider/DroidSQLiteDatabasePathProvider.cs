using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AppXamarinConsultaCep.Droid.Provider;
using AppXamarinConsultaCep.Provider;
[assembly: Xamarin.Forms.Dependency(typeof(DroidSQLiteDatabasePathProvider))]

namespace AppXamarinConsultaCep.Droid.Provider
{
    class DroidSQLiteDatabasePathProvider : ISQLiteDatabasePathProvider
    {
        public DroidSQLiteDatabasePathProvider()
        {

        }

        //AQUI NOS RETORNAMOS A PASTA ONDE SERÁ CRIADO DATABASE
        //OU ACESSADO
        public string GetDatabasePath()
        {
            return Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "BuscaCep.db3");
        }
    }
}