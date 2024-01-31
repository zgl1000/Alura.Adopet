using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Adopet.Console.Comandos
{
    public class DocumentacaoSistema
    {
        public static Dictionary<string, DocComando> ToDictionary(Assembly assemblyComOTipoDocComando)
        {
            return assemblyComOTipoDocComando.GetTypes()
                        .Where(t => t.GetCustomAttributes<DocComando>().Any())
                        .Select(t => t.GetCustomAttribute<DocComando>()!)
                        .ToDictionary(d => d.Instrucao);
        }
    }
}
