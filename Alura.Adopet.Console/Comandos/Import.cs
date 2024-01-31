using System.Net.Http.Json;
using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos;
using Alura.Adopet.Console.Util;

namespace Alura.Adopet.Console.Comandos
{
    [DocComando(instrucao: "import", documentacao: "adopet import <arquivo> comando que realiza a importação do arquivo de pets.")]
    public class Import : IComando
    {
        private readonly HttpClientPet _clientPet;

        public Import(HttpClientPet clientPet)
        {
            _clientPet = clientPet;
        }

        public async Task ExecutarAsync(string[] args)
        {
            await this.ImportacaoArquivoPetAsync(caminhoDoArquivoDeImportacao: args[1]);
        }

        private async Task ImportacaoArquivoPetAsync(string caminhoDoArquivoDeImportacao)
        {
            var leitorDeArquivo = new LeitorDeArquivo(caminhoDoArquivoDeImportacao);

            List<Pet> listaDePet = leitorDeArquivo.RealizaLeitura();

            foreach (var pet in listaDePet)
            {
                System.Console.WriteLine(pet);

                try
                {
                    await _clientPet.CreatePetAsync(pet);
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
            }
            System.Console.WriteLine("Importação concluída!");
        }
    }
}
