using Decomposicao.Dominio.Teste.Builders;
using ExpectedObjects;
using Xunit;

namespace Decomposicao.Dominio.Teste
{
    public class FatoracaoTeste
    {
        [Fact]
        public void DeveCriarDecompositor()
        {
            var decompositorEsperado = DecompositorBuilder.Novo().Build();
            var fatoracao = new Fatoracao();
            decompositorEsperado.ToExpectedObject().ShouldMatch(fatoracao.DecomporNumero(decompositorEsperado.NumeroDeEntrada));
        }
    }
}
