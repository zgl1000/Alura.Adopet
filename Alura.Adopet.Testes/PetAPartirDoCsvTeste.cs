using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Util;

namespace Alura.Adopet.Testes
{
    public class PetAPartirDoCsvTeste
    {
        [Fact]
        public void QuandoStringForValidaDeveRetornarUmPet()
        {
            //Arrange
            string linha = "456b24f4-19e2-4423-845d-4a80e8854a41;Lima Limão;1";

            //Act
            Pet pet = linha.ConverteDoTexto();

            //Assert
            Assert.NotNull(pet);
        }

        [Fact]
        public void QuandoStringForNulaDeveRetonarExcecao()
        {
            //Arrange
            string linha = null;

            //Act
            //Assert
            Assert.Throws<ArgumentNullException>(() => linha.ConverteDoTexto());
        }

        [Fact]
        public void QuandoStringForVaziaDeveRetonarExcecao()
        {
            //Arrange
            string linha = string.Empty;

            //Act
            //Assert
            Assert.Throws<ArgumentNullException>(() => linha.ConverteDoTexto());
        }

        [Fact]
        public void QuandoStringNaoPossuiTodosCamposDeveRetonarExcecao()
        {
            //Arrange
            string linha = "456b24f4-19e2-4423-845d-4a80e8854a41;Lima Limão";

            //Act
            //Assert
            Assert.ThrowsAny<ArgumentException>(() => linha.ConverteDoTexto());
        }

        [Fact]
        public void QuandoGuidForInvalidoDeveRetonarExcecao()
        {
            //Arrange
            string linha = "456b24f4-19e2-4423-1;Lima Limão;1";

            //Act
            //Assert
            Assert.ThrowsAny<ArgumentException>(() => linha.ConverteDoTexto());
        }

        [Fact]
        public void QuandoTipoForInvalidoDeveRetonarExcecao()
        {
            //Arrange
            string linha = "456b24f4-19e2-4423-1;Lima Limão;4";

            //Act
            //Assert
            Assert.ThrowsAny<ArgumentException>(() => linha.ConverteDoTexto());
        }
    }
}
