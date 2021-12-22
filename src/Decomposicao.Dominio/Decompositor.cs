using System;
using System.Collections.Generic;
using System.Linq;

namespace Decomposicao.Dominio
{
    public class Decompositor
    {
      
        public int NumeroDeEntrada { get; private set; }
        public List<int> NumeroDivisores { get; private set; }
        public List<int> DivisoresPrimos { get; private set; }
        public List<int> FatoresPrimos { get; private set; }
        public Decompositor(int numeroDeEntrada)
        {
            ValidarNumeroDeEntrada(numeroDeEntrada);
            NumeroDeEntrada = numeroDeEntrada;
            DecomporNumeroDeEntrada();
        }
        private void DecomporNumeroDeEntrada()
        {
            GerardivisoresPrimos();
            GerarNumerosDivisores();
        }
        private void ValidarNumeroDeEntrada(int numeroDeEntrada)
        {
            if (numeroDeEntrada < 2)
                throw new ArgumentException("O número de entrada deve ser maior ou igual a 2");
        }
        private void GerardivisoresPrimos()
        {
            DivisoresPrimos = new List<int>();
            FatoresPrimos = new List<int>();
            var numeroDeEntrada = NumeroDeEntrada;
            for (int div = 2; div <= numeroDeEntrada; div++)
            {
                while (numeroDeEntrada % div == 0)
                {    
                    if(!DivisoresPrimos.Any(p=> p == div))
                        DivisoresPrimos.Add(div);

                    FatoresPrimos.Add(div);
                    numeroDeEntrada = numeroDeEntrada / div;
                }
            }
           
        }
        private void GerarNumerosDivisores()
        {
            NumeroDivisores = new List<int>();

            NumeroDivisores.Add(1);
           
            int divisor = 0;
            foreach (var item in FatoresPrimos)
            {
                var _divisoresPratico = new List<int>();
                _divisoresPratico.AddRange(NumeroDivisores);
                foreach (var div in _divisoresPratico)
                {
                    divisor = div * item;

                    if (!NumeroDivisores.Any(p => p == divisor))
                        NumeroDivisores.Add(divisor);
                    
                    if (divisor == NumeroDeEntrada)
                        break;
                   
                }
                
            }
            NumeroDivisores = NumeroDivisores.OrderBy(p => p).ToList();
            
        }
       
    }
}
