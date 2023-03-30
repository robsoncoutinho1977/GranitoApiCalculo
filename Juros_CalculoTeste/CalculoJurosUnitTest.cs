using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Juros_CalculoTeste
{
    public class CalculoJurosUnitTest
    {
        [Fact]
        public void Somar_DoisDouble_RetornaDouble()
        {
            // Arrange  
            var num1 = 2.9;
            var num2 = 3.1;
            var valorEsperado = 6;
            // Act  
            var soma = Calculo.Somar(num1, num2);
            //Assert  
            Assert.Equal(valorEsperado, soma);
        }
    }
}
