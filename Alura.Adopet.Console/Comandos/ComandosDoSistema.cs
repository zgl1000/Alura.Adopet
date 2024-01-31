using Alura.Adopet.Console.Servicos;

namespace Alura.Adopet.Console.Comandos
{
    internal class ComandosDoSistema
    {
        private static readonly HttpClientPet httpClientPet = new HttpClientPet(new AdopetAPIClientFactory().CreateClient("adopet"));

        private Dictionary<string, IComando> comandosDoSistema = new()
        {
            {"help",new Help() },
            {"import",new Import(httpClientPet) },
            {"list",new List(httpClientPet) },
            {"show",new Show() },
        };

        public IComando? this[string key] => comandosDoSistema.ContainsKey(key) ? comandosDoSistema[key] : null;
    }
}
