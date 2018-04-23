using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AppXamarinConsultaCep.Clients
{
    class ViaCepHttpClient
    {
        private static Lazy<ViaCepHttpClient> _lazy = new Lazy<ViaCepHttpClient>(() => new ViaCepHttpClient());
        private readonly HttpClient _httpClient;

        public static ViaCepHttpClient Current { get => _lazy.Value; }

        private ViaCepHttpClient()
        {
            _httpClient = new HttpClient();
        }

        public async Task<string> BuscarCep(string cep)
        {
            try
            {
                if (!string.IsNullOrEmpty(cep))
                {
                    using (var client = new HttpClient())
                    {
                        using (var response = await _httpClient.GetAsync(string.Format("https://viacep.com.br/ws/{0}/json/", cep)))
                        {
                            if (response.IsSuccessStatusCode)
                            {
                                return await response.Content.ReadAsStringAsync();
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
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
    }
}
