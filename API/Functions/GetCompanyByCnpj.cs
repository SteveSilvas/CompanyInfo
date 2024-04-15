using CompanyInfo.DTOs;
using CompanyInfo.Interfaces;
using Newtonsoft.Json;

namespace CompanyInfo.Functions
{
    public class GetCompanyByCnpj : IGetCompanyInfo
    {
        private readonly HttpClient _httpClient;

        public GetCompanyByCnpj()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://receitaws.com.br/v1/cnpj/");
            _httpClient.Timeout = TimeSpan.FromSeconds(120); 
        }

        public async Task<CompanyInfoDTO> GetAsync(string cnpj)
        {
            try
            {
                cnpj = Helpers.CleanCNPJ(cnpj);
                HttpResponseMessage response = await _httpClient.GetAsync(cnpj);

                response.EnsureSuccessStatusCode();

                string jsonContent = await response.Content.ReadAsStringAsync();

                CompanyInfoDTO? companyInfo = JsonConvert.DeserializeObject<CompanyInfoDTO>(jsonContent);
                
                if (companyInfo == null)
                    throw new Exception("Erro ao obter informações da empresa. Verifique o CNPJ e tente novamente.");

                return companyInfo;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Erro na requisição HTTP: {ex.Message}");
                throw new HttpRequestException("Erro ao obter informações da empresa. Verifique a conexão de rede e tente novamente.");
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Erro ao desserializar JSON: {ex.Message}");
                throw new JsonException("Erro ao processar a resposta JSON.");
            }
        }
    }
}
