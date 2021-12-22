using Decomposicao.Dominio.Interfaces;

namespace Decomposicao.Dominio
{
    public class Fatoracao : IFatoracao
    {
        public Decompositor DecomporNumero(int numeroDeEntrada)
        {
            return new Decompositor(numeroDeEntrada);
        }
    }
}
