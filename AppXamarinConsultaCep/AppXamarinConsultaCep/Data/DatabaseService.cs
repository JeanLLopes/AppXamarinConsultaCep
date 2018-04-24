using AppXamarinConsultaCep.Model;
using AppXamarinConsultaCep.Provider;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppXamarinConsultaCep.Data
{
    public class DatabaseService
    {
        private static Lazy<DatabaseService> _lazy = new Lazy<DatabaseService>(() => new DatabaseService());
        private readonly SQLiteConnection _SQLiteConnection;

        public static DatabaseService Current { get => _lazy.Value;  }

        private DatabaseService()
        {
            //PEGAMOS O CAMINHO DO BANCO
            //QUE É DIFERENTE PARA O IOS E PARA O ANDROID
            var dbPath = Xamarin.Forms.DependencyService.Get<ISQLiteDatabasePathProvider>().GetDatabasePath();
            _SQLiteConnection = new SQLiteConnection(dbPath);

            //CRIAMOS A TABELA NO BANCO
            _SQLiteConnection.CreateTable<ViaCepModel>();
        }

        public bool Save(ViaCepModel dadosCep)
        {
            //CASO ELE TENHA GARAVADO NO BANCO ELE VAI RETORNAR
            //A QUANTIDADE DE LINHA AFETADAS
            //E  NO CASO ABAIXO SE FOR MAIOR QUE 0 ENTÃO 
            //QUER DIZER QUE GRAVOU
            return _SQLiteConnection.InsertOrReplace(dadosCep) > 0;
        }


        public List<ViaCepModel> GetAll()
        {
            return _SQLiteConnection.Table<ViaCepModel>().ToList();
        }

        public ViaCepModel GetCep(Guid id)
        {
            return _SQLiteConnection.Find<ViaCepModel>(id);
        }
    }
}
