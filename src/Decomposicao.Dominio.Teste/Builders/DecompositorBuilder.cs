using System;
using System.Collections.Generic;
using System.Text;

namespace Decomposicao.Dominio.Teste.Builders
{

    public class DecompositorBuilder
    {
        private int _numeroDeEntrada = 45;
        public static DecompositorBuilder Novo()
        {
            return new DecompositorBuilder();
        }
        public DecompositorBuilder ComNumeroDeEntrada(int numeroDeEntrada)
        {
            _numeroDeEntrada = numeroDeEntrada;
            return this;
        }
        public Decompositor Build()
        {
            return new Decompositor(_numeroDeEntrada);
        }
    }
}
