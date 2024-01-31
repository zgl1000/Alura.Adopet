using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Adopet.Console.Comandos
{
    [DocComando(instrucao: "help", documentacao: "adopet help comando que exibe informações de ajuda dos comandos.\n" +
        "adopet help <NOME_COMANDO> para acessar a ajuda de um comando específico.")]
    internal class Help : IComando
    {
        private Dictionary<string, DocComando> docs;

        public Help()
        {
            docs = DocumentacaoSistema.ToDictionary(Assembly.GetExecutingAssembly());
        }

        public Task ExecutarAsync(string[] args)
        {
            this.ExibeDocumentacao(args);

            return Task.CompletedTask;
        }

        public void ExibeDocumentacao(string[] comandos)
        {
            System.Console.WriteLine("Lista de comandos.");
            // se não passou mais nenhum argumento mostra help de todos os comandos
            if (comandos.Length == 1)
            {

                System.Console.WriteLine("Adopet (1.0) - Aplicativo de linha de comando (CLI).");
                System.Console.WriteLine("Realiza a importação em lote de um arquivos de pets.");
                System.Console.WriteLine("Comando possíveis: ");
                //System.Console.WriteLine($" adopet help comando que exibe informações de ajuda dos comandos.");
                //System.Console.WriteLine($" adopet import <arquivo> comando que realiza a importação do arquivo de pets.");
                //System.Console.WriteLine($" adopet show   <arquivo> comando que exibe no terminal o conteúdo do arquivo importado.");
                //System.Console.WriteLine($" adopet list comando que exibe no terminal o conteúdo cada arquivo importado.");
                foreach (var doc in docs.Values)
                {
                    System.Console.WriteLine(doc.Documentacao);
                }
            }
            // exibe o help daquele comando específico
            else if (comandos.Length == 2)
            {
                string comandoASerExibido = comandos[1];

                if (docs.ContainsKey(comandoASerExibido))
                {
                    var comando = docs[comandoASerExibido];

                    System.Console.WriteLine(comando.Documentacao);
                }

                //if (comandoASerExibido.Equals("import"))
                //{
                //    System.Console.WriteLine(" adopet import <arquivo> " +
                //        "comando que realiza a importação do arquivo de pets.");
                //}
                //if (comandoASerExibido.Equals("show"))
                //{
                //    System.Console.WriteLine(" adopet show <arquivo>  comando que " +
                //        "exibe no terminal o conteúdo do arquivo importado.");
                //}
                //if (comandoASerExibido.Equals("list"))
                //{
                //    System.Console.WriteLine(" adopet list comando que " +
                //                            "exibe no terminal o conteúdo cada arquivo importado.");
                //}
            }
        }
    }
}
