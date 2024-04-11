namespace CompanyInfo.Functions
{
    public class Helpers
    {
        static public string CleanCNPJ(string cnpjCPF)
        {
            cnpjCPF = cnpjCPF.Trim();
            cnpjCPF = cnpjCPF.Replace(".", "");
            cnpjCPF = cnpjCPF.Replace("-", "");
            cnpjCPF = cnpjCPF.Replace("/", "");

            return cnpjCPF;
        }
    }
}
