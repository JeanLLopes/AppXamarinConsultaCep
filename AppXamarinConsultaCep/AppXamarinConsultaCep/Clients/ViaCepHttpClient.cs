using AppXamarinConsultaCep.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AppXamarinConsultaCep.Clients
{
    public class ViaCepHttpClient
    {
        //TRHEAD SAVE SINGTON
        //INICIO
        //LAZY = INICIALIZAÇÃO TARDIA VAI INICIALIZAR E ASSIM QUE ESTIVER PRONTO VAI PARA O CONSTRUTOR
        private static Lazy<ViaCepHttpClient> _lazy = new Lazy<ViaCepHttpClient>(() => new ViaCepHttpClient());
        private readonly HttpClient _httpClient;

        public static ViaCepHttpClient Current { get => _lazy.Value; }

        private ViaCepHttpClient()
        {
            _httpClient = new HttpClient();
        }
        //TRHEAD SAVE SINGTON
        //FINAL


        public async Task<ViaCepModel> BuscarCep(string cep)
        {
            if (!string.IsNullOrEmpty(cep))
            {
                using (var client = new HttpClient())
                {
                    using (var response = await _httpClient.GetAsync(string.Format("https://viacep.com.br/ws/{0}/json/", cep)))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var returno = await response.Content.ReadAsStringAsync();
                            if (!string.IsNullOrWhiteSpace(returno))
                            {
                                return JsonConvert.DeserializeObject<ViaCepModel>(returno);
                            }
                            else
                            {
                                throw new Exception("A API retornou vazio");
                            }
                        }
                        else
                        {
                            throw new InvalidOperationException("Erro ao chamar a API");
                        }
                    }
                }
            }
            else
            {
                throw new InvalidOperationException("Erro ao informar o cep");
            }
        }
    }
}
