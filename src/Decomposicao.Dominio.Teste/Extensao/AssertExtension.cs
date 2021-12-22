using System;
using Xunit;

namespace Decomposicao.Dominio.Teste.Extensao
{
    public static class AssertExtension
    {
        public static void ComMensagem(this ArgumentException exception, string mensagem)
        {
            if (exception.Message.Contains(mensagem))
                Assert.True(true);
            else
                Assert.False(true, $"Esperava mensagem: '{mensagem}'");
        }
    }
}
