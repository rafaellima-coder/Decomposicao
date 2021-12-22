using Decomposicao.Dominio;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;

namespace TelaDecompositor
{
    class Program
    {
        static void Main(string[] args)
        {
            int numeroDeEntrada=0;
            try
            {
                Console.WriteLine("Digite o número de entrada e clique enter");                
                numeroDeEntrada = RetornarNumeroDeEntradaValido();
                var decompostior = new Decompositor(numeroDeEntrada);
                Console.WriteLine($@"Número de Entrada: {decompostior.NumeroDeEntrada }");
                Console.WriteLine($@"Números divisores: {NumerosDivisores(decompostior.NumeroDivisores) }");
                Console.WriteLine($@"Divisores Primos: {DivisoresPrimos(decompostior.DivisoresPrimos) }");
            }            
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                Log.Error($@"{DateTime.Now}-- numero de entrada: {numeroDeEntrada} Erro para decompor devisores motivo:{ex.Message} ");
            }
          


        }
        private static int RetornarNumeroDeEntradaValido()
        {
            var _numeroDeEntrada = 0;

            if (!int.TryParse(Console.ReadLine(), out _numeroDeEntrada))
                throw new ArgumentException("Número de entrada é inválido.");
            
            return _numeroDeEntrada;
        }
        private static string NumerosDivisores(List<int> numerosDivisores)
        {
            var _numerosDivisores = new StringBuilder();
            numerosDivisores.ForEach(p => _numerosDivisores.Append($"{p} "));
            return _numerosDivisores.ToString();
        }
        private static string DivisoresPrimos(List<int> divisoresPrimos)
        {
            var _divisoresPrimos = new StringBuilder();
            divisoresPrimos.ForEach(p=> _divisoresPrimos.Append($"{p} "));
            return _divisoresPrimos.ToString();
        }
    }
}
