using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alura.Adopet.Console.Modelos;

namespace Alura.Adopet.Console.Util
{
    public class LeitorDeArquivo
    {
        private string _caminhoArquivo;

        public LeitorDeArquivo(string caminhoArquivo)
        {
            _caminhoArquivo = caminhoArquivo;
        }

        public List<Pet> RealizaLeitura()
        {
            List<Pet> listaDePet = new List<Pet>();

            if (string.IsNullOrEmpty(_caminhoArquivo))
                return null;

            using (StreamReader sr = new StreamReader(_caminhoArquivo))
            {

                System.Console.WriteLine("----- Serão importados os dados abaixo -----");
                while (!sr.EndOfStream)
                {
                    var pet = sr.ReadLine().ConverteDoTexto();
                    listaDePet.Add(pet);
                }
            }

            return listaDePet;
        }
    }
}
