using Alura.Adopet.Console.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Adopet.Console.Util
{
    public static class PetAPartirDoCsv
    {
        public static Pet ConverteDoTexto(this string linha)
        {
            if (string.IsNullOrEmpty(linha))
                throw new ArgumentNullException("Linha não pode ser nula ou vazia.");

            string[] propriedades = linha.Split(';');

            if (propriedades.Length != 3)
                throw new ArgumentException("Texto inválido!");

            if(!Guid.TryParse(propriedades[0], out var petId))
            {
                throw new ArgumentException("Guid Inválido");
            }

            if (!int.TryParse(propriedades[2], out int tipoPet))
            {
                throw new ArgumentException("Tipo de Pet inválido!");
            }

            if (tipoPet != 1 && tipoPet != 2 )
                throw new ArgumentException("Tipo de Pet inválido!");

            return new Pet(petId,
            propriedades[1],
            int.Parse(propriedades[2]) == 1 ? TipoPet.Gato : TipoPet.Cachorro
            );
        }
    }
}
