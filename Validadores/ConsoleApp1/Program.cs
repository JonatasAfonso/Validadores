using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validadores;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var tes = new CadastroPessoaFisica();
            //tes.EstahValido("111.444.777-35");

            tes.GerarValorParaTestes(true);
        }
    }
}
