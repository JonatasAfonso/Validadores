using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validadores;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            var cnpkj = new CadastroNacionalPessoaJuridica();
            cnpkj.GerarValorParaTestes(false);
        }
    }
}
