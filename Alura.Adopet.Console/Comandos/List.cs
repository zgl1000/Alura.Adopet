using System.Net.Http.Headers;
using System.Net.Http.Json;
using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos;

namespace Alura.Adopet.Console.Comandos
{
    [DocComando(instrucao: "list", documentacao: "adopet list comando que exibe no terminal o conteúdo cadastrado na base de dados da Adopet.")]
    internal class List : IComando
    {
        private readonly HttpClientPet _clientPet;

        public List(HttpClientPet clientPet)
        {
            _clientPet = clientPet;
        }

        public async Task ExecutarAsync(string[] args)
        {
            await this.ListaDadosPetsDaAPIAsync();
        }

        private async Task ListaDadosPetsDaAPIAsync()
        {
            var pets = await _clientPet.ListPetsAsync();

            foreach (var pet in pets)
            {
                System.Console.WriteLine(pet);
            }
        }
    }
}
