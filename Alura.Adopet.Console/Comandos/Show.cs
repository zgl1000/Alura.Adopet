using Alura.Adopet.Console.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Adopet.Console.Comandos
{
    [DocComando(instrucao: "show", documentacao: "adopet show   <arquivo> comando que exibe no terminal o conteúdo do arquivo importado.")]
    internal class Show : IComando
    {
        public Task ExecutarAsync(string[] args)
        {
            this.ExibeConteudoArquivo(caminhoDoArquivoASerExibido: args[1]);

            return Task.CompletedTask;
        }

        private void ExibeConteudoArquivo(string caminhoDoArquivoASerExibido)
        {
            var leitorDeArquivo = new LeitorDeArquivo(caminhoDoArquivoASerExibido);

            var listaPets = leitorDeArquivo.RealizaLeitura();

            foreach (var pet in listaPets)
            {
                System.Console.WriteLine(pet);
            }
        }
    }
}
