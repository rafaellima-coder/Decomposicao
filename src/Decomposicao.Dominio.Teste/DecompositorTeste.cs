using Bogus;
using Decomposicao.Dominio.Teste.Builders;
using Decomposicao.Dominio.Teste.Extensao;
using ExpectedObjects;
using System;
using Xunit;

namespace Decomposicao.Dominio.Teste
{
    public class DecompositorTeste
    {
        private readonly Faker _faker;  
        public DecompositorTeste()
        {
            _faker = new Faker();
           
        }
        [Fact]
        public void DeveCriarDecompositor()
        {
            var decompositorEsperado = DecompositorBuilder.Novo().Build();
            var decompositor = new Decompositor(decompositorEsperado.NumeroDeEntrada);
            decompositorEsperado.ToExpectedObject().ShouldMatch(decompositor);
        }
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void DeveSerNumeroDeEntradaValida(int numeroDeEntradaInvalida)
        {
            Assert.Throws<ArgumentException>(() => new Decompositor(numeroDeEntradaInvalida))
                .ComMensagem("O número de entrada deve ser maior ou igual a 2");
            
           
        }
        [Theory]
        [InlineData(2, new int[] { 2 })]
        [InlineData(3, new int[] { 3 })]
        [InlineData(7, new int[] { 7 })]
        [InlineData(9, new int[] { 3,3 })]
        [InlineData(45, new int[] { 3,3, 5 })]
        public void DeveRetornarFatoresPrimosValidos(int numeroDeEntrada, int[] fatoresPrimosEsperados)
        {
            var decompositor = new Decompositor(numeroDeEntrada);
            Assert.Equal(fatoresPrimosEsperados, decompositor.FatoresPrimos);
        }
        [Theory]        
        [InlineData(2, new int[] {2})]
        [InlineData(3, new int[] {3})]
        [InlineData(7, new int[] {7})]
        [InlineData(9, new int[] {3})]
        [InlineData(45, new int[] {3,5})]
        public void DeveRetornarDivisoresPrimosValidos(int numeroDeEntrada, int[] divisoresPrimosEsperados)
        {
            var decompositor = new Decompositor(numeroDeEntrada);
            Assert.Equal(divisoresPrimosEsperados, decompositor.DivisoresPrimos);
        }
        [Theory]        
        [InlineData(2, new int[] {1,2})]
        [InlineData(3, new int[] {1,3})]
        [InlineData(7, new int[] {1,7})]
        [InlineData(9, new int[] {1,3,9})]
        [InlineData(45, new int[]{1,3,5,9,15,45})]
        public void DeveRetornarNumerosDivisoresValidos(int numeroDeEntrada,int[] numerosDivisoresEsperados)
        {          
            var decompositor =new Decompositor(numeroDeEntrada);
            Assert.Equal(numerosDivisoresEsperados, decompositor.NumeroDivisores);
        }
      
    }
}
